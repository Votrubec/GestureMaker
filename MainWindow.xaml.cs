using PDollarGestureRecognizer;

using QDollarGestureRecognizer;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

using Ookii.Dialogs.Wpf;

using Point = PDollarGestureRecognizer.Point;

namespace GestureMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string INVALID_FILENAME = "Please enter a valid gesture (file) name.";
        const string GESTURE_SET_ALREADY_EXISTS = "The Gesture Name already exists. Either add to the existing set, or rename the Gesture.";
        const string NO_GESTURES_LOADED = "There are no Gestures loaded.";

        readonly List<Gesture> gestures;                            // Full list of all Gestures.
        readonly Dictionary<string, List<Gesture>> gesturesByName;  // Gesture sets, by Gesture name.
        readonly List<Point> points;                                // Gesture points acquired from the user.
        private int strokeIndex = -1;                               // Current stroke index from user.
        private bool readingPointer;

        private Gesture currentMatchedGesture;
        private Gesture candidateGesture;
        private float closestDistance;
        private bool finishedGesture;
        private readonly float canvasWidth;
        private readonly float canvasHeight;
        private readonly float canvasHalfWidth;
        private readonly float canvasHalfHeight;
        public string DirectoryPath { get; private set; }


        public MainWindow ( )
        {
            InitializeComponent ( );

            gestures = new List<Gesture> ( );
            gesturesByName = new Dictionary<string, List<Gesture>> ( );
            points = new List<Point> ( );
            canvasWidth = ( float ) GestureImage.Width;
            canvasHeight = ( float ) GestureImage.Height;
            canvasHalfWidth = ( float ) ( GestureImage.Width / 2 );
            canvasHalfHeight = ( float ) ( GestureImage.Height / 2 );
            readingPointer = false;

            QPointCloudRecognizer.UseEarlyAbandoning = true;
            QPointCloudRecognizer.UseLowerBounding = true;
        }


        private void Image_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
        {
            if ( finishedGesture )
            {
                GestureImage.Children.Clear ( );
                points.Clear ( );
                finishedGesture = false;
            }

            if ( candidateGesture != null ) candidateGesture = null;
            ++strokeIndex;
            readingPointer = true;
        }


        private void Image_MouseLeftButtonUp ( object sender, MouseButtonEventArgs e )
        {
            readingPointer = false;
        }


        private void GestureImage_MouseLeave ( object sender, MouseEventArgs e )
        {
            readingPointer = false;
        }


        private void Image_MouseMove ( object sender, MouseEventArgs e )
        {
            //if ( e.LeftButton != MouseButtonState.Pressed ) return;
            if ( !readingPointer ) return;

            var canvas = ( Canvas ) sender;
            var mousePosition = e.GetPosition ( canvas );
            var mouseX = ( float ) mousePosition.X;
            var mouseY = ( float ) mousePosition.Y;

            var newPoint = new Point ( mouseX, mouseY, strokeIndex );

            Coordinates.Text = $"[{mouseX}, {mouseY}]";

            points.Add ( newPoint );

            if ( points.Count < 2 ) return;
            var previousPoint = points [ ^2 ];
            if ( previousPoint.StrokeID == newPoint.StrokeID )
                GestureImage.Children.Add ( new Line
                {
                    Stroke = Brushes.Green,
                    StrokeThickness = 2,
                    X1 = previousPoint.X,
                    Y1 = previousPoint.Y,
                    X2 = newPoint.X,
                    Y2 = newPoint.Y
                } );
        }


        private void Image_MouseRightButtonUp ( object sender, MouseButtonEventArgs e )
        {
            CheckGesture ( );

            // Check to see if we have Gestures to compare against. This may not be true if all new gestures are being created.
            if ( gestures?.Count != 0 )
            {
                (currentMatchedGesture, closestDistance) = QPointCloudRecognizer.Classify ( candidateGesture, gestures );

                var likelihood = closestDistance < 2f ? "Almost Certain" :
                    closestDistance < 5f ? "Very Likely" :
                    closestDistance < 22f ? "Likely" :
                    closestDistance < 30f ? "Caution" : "Not Likely";

                Results.Text = $"Matched Gesture Name : {currentMatchedGesture.Name}\n" +
                    $"Distance : {closestDistance}\n" +
                    $"{likelihood}";
            }
            else
            {
                Results.Text = "There are no loaded Gestures to compare this Gesture against. You can save this as a New Gesture.";
            }
        }

        private void CheckGesture ( )
        {
            finishedGesture = true;
            strokeIndex = -1;

            // We massage the points to conform to the Unity XY screen, with 0,0 being bottm-left, not top-left.
            var count = points.Count;
            var p = new Point [ points.Count ];
            for ( int i = 0; i < count; ++i )
                p [ i ] = new Point ( points [ i ].X, canvasHeight - points [ i ].Y, points [ i ].StrokeID );

            candidateGesture = new Gesture ( p );
        }


        private void LoadGestures ( object sender, RoutedEventArgs e )
        {
            var d = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
            {
                Description = "Select Folder Containing Gesture Data",
                UseDescriptionForTitle = true
            };
            d.ShowDialog ( );
            DirectoryPath = d.SelectedPath;

            gestures.Clear ( );
            gesturesByName.Clear ( );
            ExistingGestures.Items.Clear ( );

            string [ ] gestureFiles = Directory.GetFiles ( DirectoryPath, "*.json" );
            foreach ( string file in gestureFiles )
            {
                var g = GestureIO.ReadGesture ( file );
                gestures.Add ( g );
                if ( !gesturesByName.TryGetValue ( g.Name, out var gList ) )
                {
                    gList = new List<Gesture> ( );
                    gesturesByName [ g.Name ] = gList;
                }
                gList.Add ( g );
            }

            if ( gestures.Count == 0 )
            {
                Results.Text = $"No Gesture Files found at:\n{DirectoryPath}";
                return;
            }

            foreach ( var k in gesturesByName.Keys )
                ExistingGestures.Items.Add ( k );
            ExistingGestures.SelectedIndex = 0;
            Results.Text = $"{gestures.Count} Gestures Loaded.\n{ExistingGestures.Items.Count} Gesture Sets Found.";
        }


        private void About ( object sender, RoutedEventArgs e )
        {
            var about = new AboutWindow
            {
                Owner = this
            };
            about.ShowDialog ( );
        }


        private void AddGesture ( object sender, RoutedEventArgs e )
        {
            if ( gestures?.Count == 0 )
            {
                Results.Text = NO_GESTURES_LOADED;
                MessageBox.Show ( NO_GESTURES_LOADED, "Info" );
                return;
            }

            if ( candidateGesture == null )
                CheckGesture ( );

            var gestureName = ExistingGestures.SelectedValue as string;
            candidateGesture.Name = gestureName;
            gestures.Add ( candidateGesture );
            gesturesByName [ gestureName ].Add ( candidateGesture );
            SaveGestures ( gestureName );
        }


        private void AddNewGesture ( object sender, RoutedEventArgs e )
        {
            var gestureName = NewGesture.Text.Trim ( );
            if ( gestureName.Length == 0 )
            {
                Results.Text = INVALID_FILENAME;
                return;
            }
            char [ ] invalidChars = System.IO.Path.GetInvalidFileNameChars ( );
            foreach ( char c in gestureName )
                if ( invalidChars.Contains ( c ) )
                {
                    Results.Text = INVALID_FILENAME;
                    return;
                }

            if ( gesturesByName.TryGetValue ( gestureName, out _ ) )
            {
                Results.Text = GESTURE_SET_ALREADY_EXISTS;
                MessageBox.Show ( GESTURE_SET_ALREADY_EXISTS, "Info" );
                return;
            }

            candidateGesture.Name = gestureName;
            gestures.Add ( candidateGesture );
            gesturesByName [ gestureName ] = new List<Gesture> { candidateGesture };
            SaveGestures ( gestureName );
            ExistingGestures.Items.Add ( gestureName );
            ExistingGestures.SelectedIndex = ExistingGestures.Items.Count - 1;
            NewGesture.Text = "";
        }


        private bool SaveGestures ( string gestureSet )
        {
            if ( points.Count == 0 ) return false;
            if ( string.IsNullOrEmpty ( DirectoryPath ) )
            {
                var d = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog
                {
                    Description = "Select Folder For Gesture Data",
                    UseDescriptionForTitle = true
                };
                d.ShowDialog ( );
                DirectoryPath = d.SelectedPath;
                if ( string.IsNullOrEmpty ( DirectoryPath ) ) return false;
            }

            if ( !gesturesByName.TryGetValue ( gestureSet, out var gList ) )
            {
                Results.Text = INVALID_FILENAME;
                MessageBox.Show ( INVALID_FILENAME, "Info" );
                return false;
            }
            var success = GestureIO.WriteGestures ( gList, DirectoryPath, out var writtenCount );
            Results.Text = $"{writtenCount}/{gList.Count} '{gestureSet}' files written.";
            return success;
        }
    }
}
