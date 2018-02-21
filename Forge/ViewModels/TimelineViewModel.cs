using Caliburn.Micro;
using Forge.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TimelinePanel;

namespace Forge.ViewModels
{
    [Export(typeof(TimelineViewModel))]
    public class TimelineViewModel : Screen
    {
        #region Private Variables
        private BindableCollection<TimelineItem> _events = new BindableCollection<TimelineItem>();
        private ScrollViewer _scrollViewer = new ScrollViewer();
        private ScrollViewer _scrollViewerYear = new ScrollViewer();
        private TimelinePanel.TimelinePanel _timeline = new TimelinePanel.TimelinePanel();
        private Point _oldMousePosition = new Point();
        private Point _scrollViewerMousePosition = new Point();
        private double _hOff = 1;
        private double _vOff = 1;
        private BindableCollection<EventDateTimeCollection> _eventDateTimeCollection = new BindableCollection<EventDateTimeCollection>();
        #endregion

        #region Public Variables
        public BindableCollection<TimelineItem> Events
        {
            get { return _events; }
            set
            {
                if(_events != value)
                {
                    _events = value;
                    NotifyOfPropertyChange(() => Events);
                }
            }
        }
        public BindableCollection<EventDateTimeCollection> EventDateTimeCollection
        {
            get { return _eventDateTimeCollection; }
            set
            {
                if(_eventDateTimeCollection != value)
                {
                    _eventDateTimeCollection = value;
                    NotifyOfPropertyChange(() => EventDateTimeCollection);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public TimelineViewModel()
        {
            PopulateEventsCollection();
            PopulateDates();
            
        }

        #region Private Methods
        private void PopulateEventsCollection()
        {
            Events = new BindableCollection<TimelineItem>
            {
                new TimelineItem
                {
                    Name = "Test 01",
                    Date = DateTime.Parse("1/16/2018"),
                    DateEnd = DateTime.Parse("1/16/2018")
                },
                new TimelineItem
                {
                    Name = "Test 02",
                    Date = DateTime.Parse("1/16/2018"),
                    DateEnd = DateTime.Parse("1/19/2018")
                },
                new TimelineItem
                {
                    Name = "Test 03",
                    Date = DateTime.Parse("1/16/2018"),
                    DateEnd = DateTime.Parse("1/20/2018")
                },
                new TimelineItem
                {
                    Name = "Test 04",
                    Date = DateTime.Parse("1/16/2018"),
                    DateEnd = DateTime.Parse("1/21/2018")
                },
                new TimelineItem
                {
                    Name = "Test 05",
                    Date = DateTime.Parse("1/20/2018"),
                    DateEnd = DateTime.Parse("1/22/2018")
                },
                new TimelineItem
                {
                    Name = "Test 06",
                    Date = DateTime.Parse("1/21/2018"),
                    DateEnd = DateTime.Parse("1/23/2018")
                },
                new TimelineItem
                {
                    Name = "Test 07",
                    Date = DateTime.Parse("1/22/2018"),
                    DateEnd = DateTime.Parse("1/24/2018")
                },
                new TimelineItem
                {
                    Name = "Test 08",
                    Date = DateTime.Parse("1/23/2018"),
                    DateEnd = DateTime.Parse("1/24/2018")
                },
                new TimelineItem
                {
                    Name = "Test 09",
                    Date = DateTime.Parse("1/24/2018"),
                    DateEnd = DateTime.Parse("1/25/2018")
                },
                new TimelineItem
                {
                    Name = "Test 10",
                    Date = DateTime.Parse("1/25/2018"),
                    DateEnd = DateTime.Parse("1/26/2018")
                },
                new TimelineItem
                {
                    Name = "Test 11",
                    Date = DateTime.Parse("1/26/2018"),
                    DateEnd = DateTime.Parse("1/27/2018")
                },
                new TimelineItem
                {
                    Name = "Test 12",
                    Date = DateTime.Parse("1/27/2018"),
                    DateEnd = DateTime.Parse("1/28/2018")
                },
                new TimelineItem
                {
                    Name = "Test 13",
                    Date = DateTime.Parse("1/28/2018"),
                    DateEnd = DateTime.Parse("2/4/2018")
                },
                new TimelineItem
                {
                    Name = "Test 14",
                    Date = DateTime.Parse("2/14/2018"),
                    DateEnd = DateTime.Parse("2/16/2018")
                }
            };
        }

        private void PopulateDates()
        {
            DateTime starting = new DateTime(2017, 1, 1);
            DateTime ending = new DateTime(2018, 12, 30);

            List<DateTime> days = GetDaysBetween(starting, ending).ToList();
            List<DateTime> months = GetMonthsBetween(starting, ending).ToList();
            List<DateTime> years = GetYearsBetween(starting, ending).ToList();

            List<EventDateTimeDay> allDays = new List<EventDateTimeDay>();
            List<EventDateTimeMonth> allMonths = new List<EventDateTimeMonth>();

            EventDateTimeCollection = new BindableCollection<EventDateTimeCollection>();


            foreach(DateTime year in years)
            {
                allMonths = new List<EventDateTimeMonth>();
                foreach (var month in months.Where(x => x.Year == year.Year))
                {
                    allDays = new List<EventDateTimeDay>();
                    foreach (var day in days.Where(x => x.Month == month.Month && x.Year == year.Year))
                    {
                        allDays.Add(new EventDateTimeDay
                        {
                            Day = day.Day,
                            DayOfTheWeek = day.DayOfWeek.ToString()
                        });
                    }

                    allMonths.Add(new EventDateTimeMonth
                    {
                        Month = ConvertMonth(month.Month),
                        Day = new BindableCollection<EventDateTimeDay>(allDays)
                    });
                }

                EventDateTimeCollection.Add(new EventDateTimeCollection
                {
                    Year = year.Year,
                    Month = new BindableCollection<EventDateTimeMonth>(allMonths)
                });
            }
        }

        private DateTime[] GetDaysBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDays = new List<DateTime>();
            for(DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                allDays.Add(date);
            }
            return allDays.ToArray();
        }

        private DateTime[] GetMonthsBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allMonths = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
                allMonths.Add(date);

            return allMonths.ToArray();
        }

        private DateTime[] GetYearsBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allYears = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddYears(1))
                allYears.Add(date);

            return allYears.ToArray();
        }

        private string ConvertMonth(int month)
        {
            switch(month)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return string.Empty;
            }
        }
        #endregion

        #region Public Methods
        public void SetScrollViewer(object sender, EventArgs e)
        {
            _scrollViewer = sender as ScrollViewer;
        }

        public void SetTimeline(object sender, EventArgs e)
        {
            _timeline = (sender as TimelinePanel.TimelinePanel);
            _timeline.UnitSize = 3;
            _timeline.UnitTimeSpan = new TimeSpan(1, 0, 0);

            if (_timeline.Children != null)
            {
                _scrollViewer.ScrollToHorizontalOffset(_timeline.Children.OfType<FrameworkElement>().FirstOrDefault().TranslatePoint(new Point(), _timeline).X - (_timeline.Children.OfType<FrameworkElement>().FirstOrDefault().ActualWidth * 2));
            }
               
        }

        public void UserControlMouseMove(object sender, MouseEventArgs e)
        {
            if(e != null)
                _oldMousePosition = e.GetPosition((UserControl)sender);
        }

        public void scrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _scrollViewerMousePosition = e.GetPosition(_scrollViewer);
            _hOff = _scrollViewer.HorizontalOffset;
            _vOff = _scrollViewer.VerticalOffset;
            _scrollViewer.CaptureMouse();
        }

        public void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if(_scrollViewer.IsMouseCaptured)
            {
                _scrollViewer.ScrollToHorizontalOffset(_hOff + (_scrollViewerMousePosition.X - e.GetPosition(_scrollViewer).X));
                _scrollViewer.ScrollToVerticalOffset(_vOff + (_scrollViewerMousePosition.Y - e.GetPosition(_scrollViewer).Y));
            }
        }

        public void scrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _scrollViewer.ReleaseMouseCapture();
        }

        public void scrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _scrollViewer.ScrollToHorizontalOffset(_scrollViewer.HorizontalOffset - e.Delta);
        }
        #endregion
    }
}
