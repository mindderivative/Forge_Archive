using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class EventDateTimeMonth : PropertyChangedBase
    {
        private string _month;
        private BindableCollection<EventDateTimeDay> _day = new BindableCollection<EventDateTimeDay>();

        public string Month
        {
            get { return _month; }
            set
            {
                if(_month != value)
                {
                    _month = value;
                    NotifyOfPropertyChange(() => Month);
                }
            }
        }

        public BindableCollection<EventDateTimeDay> Day
        {
            get { return _day; }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    NotifyOfPropertyChange(() => Day);
                }
            }
        }
    }
}
