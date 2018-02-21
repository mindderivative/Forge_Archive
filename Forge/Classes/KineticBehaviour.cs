using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forge.Classes
{
    public class KineticBehaviour
    {
        #region Friction
        public static readonly DependencyProperty FrictionProperty = DependencyProperty.RegisterAttached("Friction", typeof(double), typeof(KineticBehaviour), new FrameworkPropertyMetadata((double)0.95));

        public static double GetFriction(DependencyObject d)
        {
            return (double)d.GetValue(FrictionProperty);
        }

        public static void SetFriction(DependencyObject d, double value)
        {
            d.SetValue(FrictionProperty, value);
        }
        #endregion

        #region ScrollStartPoint
        private static readonly DependencyProperty ScrollStartPointProperty = DependencyProperty.RegisterAttached("ScrollStartPoint", typeof(Point), typeof(KineticBehaviour), new FrameworkPropertyMetadata((Point)new Point()));

        private static Point GetScrollStartPoint(DependencyObject d)
        {
            return (Point)d.GetValue(ScrollStartPointProperty);
        }

        private static void SetScrollStartPoint(DependencyObject d, Point value)
        {
            d.SetValue(ScrollStartPointProperty, value);
        }
        #endregion

        #region ScrollStartOffset
        private static readonly DependencyProperty ScrollStartOffsetProperty = DependencyProperty.RegisterAttached("ScrollStartOffset", typeof(Point), typeof(KineticBehaviour), new FrameworkPropertyMetadata((Point)new Point()));

        private static Point GetScrollStartOffset(DependencyObject d)
        {
            return (Point)d.GetValue(ScrollStartOffsetProperty);
        }

        private static void SetScrollStartOffset(DependencyObject d, Point value)
        {
            d.SetValue(ScrollStartOffsetProperty, value);
        }
        #endregion

        #region InertiaProcessor
        private static readonly DependencyProperty InertiaProcesssorProperty = DependencyProperty.RegisterAttached("InertiaProcessor", typeof(InertiaHandler), typeof(KineticBehaviour), new FrameworkPropertyMetadata((InertiaHandler)null));

        private static InertiaHandler GetInertiaProcessor(DependencyObject d)
        {
            return (InertiaHandler)d.GetValue(InertiaProcesssorProperty);
        }

        private static void SetInertiaProcessor(DependencyObject d, InertiaHandler value)
        {
            d.SetValue(InertiaProcesssorProperty, value);
        }
        #endregion

        #region HandleKineticScrolling
        public static readonly DependencyProperty HandleKineticScrollingProperty = DependencyProperty.RegisterAttached("HandleKineticScrolling", typeof(bool), typeof(KineticBehaviour), new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnHandleKineticScrollingChanged)));

        public static bool GetHandleKineticScrolling(DependencyObject d)
        {
            return (bool)d.GetValue(HandleKineticScrollingProperty);
        }

        public static void SetHandleKineticScrolling(DependencyObject d, bool value)
        {
            d.SetValue(HandleKineticScrollingProperty, value);
        }

        private static void OnHandleKineticScrollingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollViewer scroller = d as ScrollViewer;
            if((bool)e.NewValue)
            {
                scroller.PreviewMouseDown += OnPreviewMouseDown;
                scroller.PreviewMouseMove += OnPreviewMouseMove;
                scroller.PreviewMouseUp += OnPreviewMouseUp;
                SetInertiaProcessor(scroller, new InertiaHandler(scroller));
            }
            else
            {
                scroller.PreviewMouseDown -= OnPreviewMouseDown;
                scroller.PreviewMouseMove -= OnPreviewMouseMove;
                scroller.PreviewMouseUp -= OnPreviewMouseUp;
                var inertia = GetInertiaProcessor(scroller);
                if (inertia != null)
                    inertia.Dispose();
            }
        }
        #endregion

        #region Mouse Events
        private static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if(scrollViewer.IsMouseOver)
            {
                SetScrollStartPoint(scrollViewer, e.GetPosition(scrollViewer));
                SetScrollStartOffset(scrollViewer, new Point(scrollViewer.HorizontalOffset, scrollViewer.VerticalOffset));
                scrollViewer.CaptureMouse();
            }
        }

        private static void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if(scrollViewer.IsMouseCaptured)
            {
                Point currentPoint = e.GetPosition(scrollViewer);

                var scrollStartPoint = GetScrollStartPoint(scrollViewer);

                Point delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);

                var scrollStartOffset = GetScrollStartOffset(scrollViewer);
                Point scrollTarget = new Point(scrollStartOffset.X + delta.X, scrollStartOffset.Y + delta.Y);

                var inertiaProcessor = GetInertiaProcessor(scrollViewer);
                if (inertiaProcessor != null)
                    inertiaProcessor.ScrollTarget = scrollTarget;

                scrollViewer.ScrollToHorizontalOffset(scrollTarget.X);
                scrollViewer.ScrollToVerticalOffset(scrollTarget.Y);
            }
        }

        private static void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer.IsMouseCaptured)
                scrollViewer.ReleaseMouseCapture();
        }
        #endregion

        #region Inertia Stuff
        class InertiaHandler : IDisposable
        {
            private Point previousPoint;
            private Vector velocity;
            ScrollViewer scroller;
            DispatcherTimer animationTimer;

            private Point scrollTarget;
            public Point ScrollTarget
            {
                get { return scrollTarget; }
                set { scrollTarget = value; }
            }

            public InertiaHandler(ScrollViewer scroller)
            {
                this.scroller = scroller;
                animationTimer = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 0, 0, 10)
                };
                animationTimer.Tick += new EventHandler(HandleWorldTimerTick);
                animationTimer.Start();
            }

            private void HandleWorldTimerTick(object sender, EventArgs e)
            {
                if(scroller.IsMouseCaptured)
                {
                    Point currentPoint = Mouse.GetPosition(scroller);
                    velocity = previousPoint - currentPoint;
                    previousPoint = currentPoint;
                }
                else
                {
                    if(velocity.Length > 1)
                    {
                        scroller.ScrollToHorizontalOffset(ScrollTarget.X);
                        scroller.ScrollToVerticalOffset(ScrollTarget.Y);
                        scrollTarget.X += velocity.X;
                        scrollTarget.Y += velocity.Y;
                        velocity *= KineticBehaviour.GetFriction(scroller);
                    }
                }
            }

            #region IDisposable Members
            public void Dispose()
            {
                animationTimer.Stop();
            }
            #endregion
        }
        #endregion
    }
}
