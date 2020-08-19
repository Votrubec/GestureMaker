/**
 * The $P Point-Cloud Recognizer (.NET Framework C# version)
 *
 * 	    Radu-Daniel Vatavu, Ph.D.
 *	    University Stefan cel Mare of Suceava
 *	    Suceava 720229, Romania
 *	    vatavu@eed.usv.ro
 *
 *	    Lisa Anthony, Ph.D.
 *      UMBC
 *      Information Systems Department
 *      1000 Hilltop Circle
 *      Baltimore, MD 21250
 *      lanthony@umbc.edu
 *
 *	    Jacob O. Wobbrock, Ph.D.
 * 	    The Information School
 *	    University of Washington
 *	    Seattle, WA 98195-2840
 *	    wobbrock@uw.edu
 *
 * The academic publication for the $P recognizer, and what should be 
 * used to cite it, is:
 *
 *	Vatavu, R.-D., Anthony, L. and Wobbrock, J.O. (2012).  
 *	  Gestures as point clouds: A $P recognizer for user interface 
 *	  prototypes. Proceedings of the ACM Int'l Conference on  
 *	  Multimodal Interfaces (ICMI '12). Santa Monica, California  
 *	  (October 22-26, 2012). New York: ACM Press, pp. 273-280.
 *
 * This software is distributed under the "New BSD License" agreement:
 *
 * Copyright (c) 2012, Radu-Daniel Vatavu, Lisa Anthony, and 
 * Jacob O. Wobbrock. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *    * Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 *    * Redistributions in binary form must reproduce the above copyright
 *      notice, this list of conditions and the following disclaimer in the
 *      documentation and/or other materials provided with the distribution.
 *    * Neither the names of the University Stefan cel Mare of Suceava, 
 *	    University of Washington, nor UMBC, nor the names of its contributors 
 *	    may be used to endorse or promote products derived from this software 
 *	    without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS
 * IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Radu-Daniel Vatavu OR Lisa Anthony
 * OR Jacob O. Wobbrock BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
 * OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
**/

/**
Milan Egon Votrubec
- Using readonly structs for Point instead of class.
- Made the whole class more "Unity friendly".
- Removed some of the garbage creation.
- Some methods made static.
**/

using System;

namespace PDollarGestureRecognizer
{
    /// <summary>
    /// Implements a gesture as a cloud of points (i.e., an unordered set of points).
    /// For $P, gestures are normalized with respect to scale, translated to origin, and resampled into a fixed number of 32 points.
    /// For $Q, a LUT is also computed.
    /// </summary>
    public class Gesture
    {
        public Point [ ] Points = null;                                         // gesture points (normalized)
        public string Name = "";                                                // gesture class
        private const int SAMPLING_RESOLUTION = 64;                             // default number of points on the gesture path
        private const int MAX_INT_COORDINATES = 1024;                           // $Q only: each point has two additional x and y integer coordinates in the interval [0..MAX_INT_COORDINATES-1] used to operate the LUT table efficiently (O(1))
        public static int LUT_SIZE = 64;                                        // $Q only: the default size of the lookup table is 64 x 64
        public static int LUT_SCALE_FACTOR = MAX_INT_COORDINATES / LUT_SIZE;    // $Q only: scale factor to convert between integer x and y coordinates and the size of the LUT
        public int [ ] [ ] LUT = null;                                          // lookup table

        public Gesture ( ) { }

        /// <summary>
        /// Constructs a gesture from an array of points
        /// </summary>
        public Gesture ( Point [ ] rawPoints, string gestureName = "" )
        {
            Name = gestureName;
            Points = Gesture.Resample ( rawPoints, SAMPLING_RESOLUTION );
            Gesture.Scale ( Points );
            Gesture.TranslateTo ( Points, Centroid ( Points ) );
            TransformCoordinatesToIntegers ( );
            ConstructLUT ( );
        }

#region gesture pre-processing steps: scale normalization, translation to origin, and resampling
        /// <summary>
        /// Performs scale normalization with shape preservation into [0..1]x[0..1]
        /// </summary>
        public static void Scale ( Point[] points )
        {
            float minx = float.MaxValue, miny = float.MaxValue, maxx = float.MinValue, maxy = float.MinValue;
            var count = points.Length;
            for ( int i = 0; i < count; i++ )
            {
                if ( minx > points [ i ].X ) minx = points [ i ].X;
                if ( miny > points [ i ].Y ) miny = points [ i ].Y;
                if ( maxx < points [ i ].X ) maxx = points [ i ].X;
                if ( maxy < points [ i ].Y ) maxy = points [ i ].Y;
            }

            var scale = Math.Max ( maxx - minx, maxy - miny );
            for ( int i = 0; i < count; i++ )
                points [ i ] = new Point ( ( points [ i ].X - minx ) / scale, ( points [ i ].Y - miny ) / scale, points [ i ].StrokeID );
        }


        /// <summary>
        /// Translates the array of points by p
        /// </summary>
        public static void TranslateTo ( Point [ ] points, Point p )
        {
            for ( int i = 0, count = points.Length; i < count; i++ )
                points [ i ] = new Point ( points [ i ].X - p.X, points [ i ].Y - p.Y, points [ i ].StrokeID );
        }


        /// <summary>
        /// Computes the centroid for an array of points
        /// </summary>
        public static Point Centroid ( Point [ ] points )
        {
            float cx = 0, cy = 0;
            var count = points.Length;
            for ( int i = 0; i < count; i++ )
            {
                cx += points [ i ].X;
                cy += points [ i ].Y;
            }
            return new Point ( cx / count, cy / count, 0 );
        }


        /// <summary>
        /// Resamples the array of points into n equally-distanced points
        /// </summary>
        public static Point [ ] Resample ( Point [ ] points, int n )
        {
            var newPoints = new Point [ n ];
            newPoints [ 0 ] = new Point ( points [ 0 ].X, points [ 0 ].Y, points [ 0 ].StrokeID );
            var numPoints = 1;

            var I = PathLength ( points ) / ( n - 1 ); // computes interval length
            var D = 0f;
            for ( int i = 1, count = points.Length; i < count; i++ )
            {
                if ( points [ i ].StrokeID == points [ i - 1 ].StrokeID )
                {
                    var d = Geometry.EuclideanDistance ( points [ i - 1 ], points [ i ] );
                    if ( D + d >= I )
                    {
                        var firstPoint = points [ i - 1 ];
                        while ( D + d >= I )
                        {
                            // add interpolated point
                            var t = Math.Min ( Math.Max ( ( I - D ) / d, 0.0f ), 1.0f );
                            if ( float.IsNaN ( t ) ) t = 0.5f;
                            newPoints [ numPoints++ ] = new Point (
                                ( 1.0f - t ) * firstPoint.X + t * points [ i ].X,
                                ( 1.0f - t ) * firstPoint.Y + t * points [ i ].Y,
                                points [ i ].StrokeID );

                            // update partial length
                            d = D + d - I;
                            D = 0;
                            firstPoint = newPoints [ numPoints - 1 ];
                        }
                        D = d;
                    }
                    else D += d;
                }
            }

            if ( numPoints == n - 1 ) // sometimes we fall a rounding-error short of adding the last point, so add it if so
                newPoints [ numPoints++ ] = new Point ( 
                    points [ points.Length - 1 ].X, 
                    points [ points.Length - 1 ].Y, 
                    points [ points.Length - 1 ].StrokeID );
            return newPoints;
        }


        /// <summary>
        /// Computes the path length for an array of points
        /// </summary>
        public static float PathLength ( Point [ ] points )
        {
            var length = 0f;
            for ( int i = 1, count = points.Length; i < count; i++ )
                if ( points [ i ].StrokeID == points [ i - 1 ].StrokeID )
                    length += Geometry.EuclideanDistance ( points [ i - 1 ], points [ i ] );
            return length;
        }


        /// <summary>
        /// Scales point coordinates to the integer domain [0..MAXINT-1] x [0..MAXINT-1]
        /// </summary>
        public void TransformCoordinatesToIntegers ( )
        {
            if ( Points == null ) return;
            for ( int i = 0, count = Points.Length; i < count; i++ )
            {
                var intx = ( int ) ( ( Points [ i ].X + 1.0f ) / 2.0f * ( MAX_INT_COORDINATES - 1 ) );
                var inty = ( int ) ( ( Points [ i ].Y + 1.0f ) / 2.0f * ( MAX_INT_COORDINATES - 1 ) );
                Points [ i ] = new Point ( Points [ i ].X, Points [ i ].Y, Points [ i ].StrokeID, intx, inty );
            }
        }


        /// <summary>
        /// Constructs a Lookup Table that maps grip points to the closest point from the gesture path
        /// </summary>
        public void ConstructLUT ( )
        {
            if ( Points == null ) return;
            this.LUT = new int [ LUT_SIZE ] [ ];
            for ( int i = 0; i < LUT_SIZE; i++ )
                LUT [ i ] = new int [ LUT_SIZE ];

            for ( int i = 0; i < LUT_SIZE; i++ )
                for ( int j = 0; j < LUT_SIZE; j++ )
                {
                    int minDistance = int.MaxValue;
                    int indexMin = -1;
                    for ( int t = 0, count = Points.Length; t < count; t++ )
                    {
                        int row = Points [ t ].intY / LUT_SCALE_FACTOR;
                        int col = Points [ t ].intX / LUT_SCALE_FACTOR;
                        int dist = ( row - i ) * ( row - i ) + ( col - j ) * ( col - j );
                        if ( dist < minDistance )
                        {
                            minDistance = dist;
                            indexMin = t;
                        }
                    }
                    LUT [ i ] [ j ] = indexMin;
                }
        }

#endregion
    }
}