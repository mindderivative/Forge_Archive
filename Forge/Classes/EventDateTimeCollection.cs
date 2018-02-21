using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class EventDateTimeCollection : PropertyChangedBase
    {
        private int _year;
        private BindableCollection<EventDateTimeMonth> _month = new BindableCollection<EventDateTimeMonth>();

        public int Year
        {
            get { return _year; }
            set
            {
                if(_year != value)
                {
                    _year = value;
                    NotifyOfPropertyChange(() => Year);
                }
            }
        }
        public BindableCollection<EventDateTimeMonth> Month
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
        
    }
}
