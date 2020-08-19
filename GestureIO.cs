/**
    Gesture IO to handle the Windows Coordinate system (Top-Left 
**/

using Newtonsoft.Json;

using PDollarGestureRecognizer;

using System.Collections.Generic;
using System.IO;


namespace GestureMaker
{
    /// <summary>
    /// Represents a point that has been normalised.
    /// </summary>
    public struct PointData
    {
        public float X;
        public float Y;
        public static implicit operator Point ( PointData p ) => new Point ( p.X, p.Y, -1 );
        public static implicit operator PointData ( Point p ) => new PointData { X = p.X, Y = p.Y };
    }


    /// <summary>
    /// Unity's poor Json implementation requires a list of items, instead of a list collections.
    /// Otherwise the Json could have been much simpler.
    /// </summary>
    public struct StrokeData
    {
        public List<PointData> Points;
    }


    /// <summary>
    /// Represents Gesture data that has already been normalised and is ready for serialisation.
    /// </summary>
    public struct GestureData
    {
        public string Name;
        public List<StrokeData> Strokes;

        public static implicit operator Gesture ( GestureData g )
        {
            var pointCount = 0;
            for ( var strokeIndex = 0; strokeIndex < g.Strokes.Count; strokeIndex++ )
                pointCount += g.Strokes [ strokeIndex ].Points.Count;
            var newGesture = new Gesture ( )
            {
                Name = g.Name,
                Points = new Point [ pointCount ]
            };

            var index = 0;
            for ( var strokeIndex = 0; strokeIndex < g.Strokes.Count; strokeIndex++ )
                for ( var pointIndex = 0; pointIndex < g.Strokes [ strokeIndex ].Points.Count; pointIndex++ )
                {
                    var originalPoint = g.Strokes [ strokeIndex ].Points [ pointIndex ];
                    var newPoint = new Point ( originalPoint.X, originalPoint.Y, strokeIndex );
                    newGesture.Points[index++] = newPoint;
                }
            newGesture.TransformCoordinatesToIntegers ( );
            newGesture.ConstructLUT ( );
            return newGesture;
        }
    }





    public class GestureIO
    {
        public static Gesture ReadGesture ( string fileName )
        {
            using ( StreamReader file = File.OpenText ( fileName ) )
            {
                JsonSerializer serializer = new JsonSerializer ( );
                return ( GestureData ) serializer.Deserialize ( file, typeof ( GestureData ) );
            }
        }


        public static bool WriteGesture ( Gesture gesture, string directory, string fileName )
        {
            var points = gesture.Points;
            var gestureAsJson = new GestureData { Name = gesture.Name };
            gestureAsJson.Strokes = new List<StrokeData> ( );
            var strokeIndex = -1;

            for ( var pointIndex = 0; pointIndex < points.Length; pointIndex++ )
            {
                if ( points [ pointIndex ].StrokeID != strokeIndex )
                {
                    ++strokeIndex;
                    gestureAsJson.Strokes.Add ( new StrokeData ( ) { Points = new List<PointData> ( ) } );
                }
                gestureAsJson.Strokes[ strokeIndex ].Points.Add ( points [ pointIndex ] );
            }

            using StreamWriter file = File.CreateText ( $"{directory}\\{fileName}.json" );
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            
            try
            {
                serializer.Serialize ( file, gestureAsJson );
            }
            catch
            {
                return false;
            }
            return true;
        }



        public static bool WriteGestures ( List<Gesture> gestures, string directory, out int filesWritten )
        {
            filesWritten = 0;
            for ( var gestureIndex = 0; gestureIndex < gestures.Count; gestureIndex++ )
            {
                var gesture = gestures [ gestureIndex ];
                var points = gesture.Points;
                var gestureAsJson = new GestureData { Name = gesture.Name };
                gestureAsJson.Strokes = new List<StrokeData> ( );
                var strokeIndex = -1;

                for ( var pointIndex = 0; pointIndex < points.Length; pointIndex++ )
                {
                    if ( points [ pointIndex ].StrokeID != strokeIndex )
                    {
                        ++strokeIndex;
                        gestureAsJson.Strokes.Add ( new StrokeData ( ) { Points = new List<PointData> ( ) } );
                    }
                    gestureAsJson.Strokes [ strokeIndex ].Points.Add ( points [ pointIndex ] );
                }

                using StreamWriter file = File.CreateText ( $"{directory}\\{gesture.Name}[{gestureIndex}].json" );
                var serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                try
                {
                    serializer.Serialize ( file, gestureAsJson );
                }
                catch
                {
                    return false;
                }
                filesWritten++;
            }
            return true;
        }
    }
}