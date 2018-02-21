using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class PlayerFactionCollection : PropertyChangedBase
    {
        private int _id;
        private string _factionName;
        private string _factionDescription;
        private string _factionStatus;

        public int ID
        {
            get { return _id; }
            set
            {
                if(_id != value)
                {
                    _id = value;
                    NotifyOfPropertyChange(() => ID);
                }
            }
        }
        public string FactionName
        {
            get { return _factionName; }
            set
            {
                if (_factionName != value)
                {
                    _factionName = value;
                    NotifyOfPropertyChange(() => FactionName);
                }
            }
        }
        public string FactionDescription
        {
            get { return _factionDescription; }
            set
            {
                if (_factionDescription != value)
                {
                    _factionDescription = value;
                    NotifyOfPropertyChange(() => FactionDescription);
                }
            }
        }
        public string FactionStatus
        {
            get { return _factionStatus; }
            set
            {
                _factionStatus = value;
                NotifyOfPropertyChange(() => FactionStatus);
            }
        }
    }
}
