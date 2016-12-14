using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using GMap.NET.WindowsPresentation;
using ParkInspect.View;

namespace ParkInspect.MapPointer
{
    public partial class Red
    {
        Popup Popup;
        Label Label;
        GMapMarker Marker;
        MainWindow MainWindow;

        public Red(MainWindow window, GMapMarker marker, string title)
        {
            this.InitializeComponent();

            this.MainWindow = window;
            this.Marker = marker;

            Popup = new Popup();
            Label = new Label();

            this.Loaded += new RoutedEventHandler(Red_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(Red_SizeChanged);
            this.MouseEnter += new MouseEventHandler(Red_MouseEnter);
            this.MouseLeave += new MouseEventHandler(Red_MouseLeave);
            // Disable movement.
            // this.MouseMove += new MouseEventHandler(Red_MouseMove);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Red_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Red_MouseLeftButtonDown);

            Popup.Placement = PlacementMode.Mouse;
            {
                Label.Background = Brushes.White;
                Label.Foreground = Brushes.Black;
                Label.BorderBrush = Brushes.Black;
                Label.BorderThickness = new Thickness(1);
                Label.Padding = new Thickness(5);
                Label.FontSize = 12;
                Label.Content = title;
            }
            Popup.Child = Label;
        }

        void Red_Loaded(object sender, RoutedEventArgs e)
        {
            if (icon.Source.CanFreeze)
            {
                icon.Source.Freeze();
            }
        }

        void Red_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Marker.Offset = new Point(-e.NewSize.Width / 2, -e.NewSize.Height);
        }

        void Red_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                Point p = e.GetPosition(MainWindow.MainMap);
                Marker.Position = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            }
        }

        void Red_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(this);
            }
        }

        void Red_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Mouse.Capture(null);
            }
        }

        void Red_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        void Red_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }
    }
}