using Caliburn.Micro;

namespace Forge.Classes
{
    public class NameSuffix : PropertyChangedBase
    {
        private int _id;
        private string _suffix;
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
        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    NotifyOfPropertyChange(() => Suffix);
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
                if (_firstLast != value)
                {
                    _firstLast = value;
                    NotifyOfPropertyChange(() => FirstLast);
                }
            }
        }
    }
}
