using Caliburn.Micro;

namespace Forge.Classes
{
    public class NamePrefix : PropertyChangedBase
    {
        private int _id;
        private string _prefix;
        private string _race;
        private string _sex;
        private string _firstLast;

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyOfPropertyChange(() => ID);
                }
            }
        }
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                if (_prefix != value)
                {
                    _prefix = value;
                    NotifyOfPropertyChange(() => Prefix);
                }
            }
        }
        public string Race
        {
            get { return _race; }
            set
            {
                if (_race != value)
                {
                    _race = value;
                    NotifyOfPropertyChange(() => Race);
                }
            }
        }
        public string Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    NotifyOfPropertyChange(() => Sex);
                }
            }
        }
        public string FirstLast
        {
            get { return _firstLast; }
            set
            {
                if(_firstLast != value)
                {
                    _firstLast = value;
                    NotifyOfPropertyChange(() => FirstLast);
                }
            }
        }
    }
}
