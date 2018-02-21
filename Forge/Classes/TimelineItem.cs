using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class TimelineItem : PropertyChangedBase
    {
        private string _name;
        private DateTime _date;
        private DateTime _dateEnd;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set
            {
                _dateEnd = value;
                NotifyOfPropertyChange(() => DateEnd);
            }
        }
    }
}
