using Caliburn.Micro;

namespace Forge.Classes
{
    public class NameAffix : PropertyChangedBase
    {
        private int _id;
        private string _affix;
        private string _race;
        private string _sex;

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
        public string Affix
        {
            get { return _affix; }
            set
            {
                if(_affix != value)
                {
                    _affix = value;
                    NotifyOfPropertyChange(() => Affix);
                }
            }
        }
        public string Race
        {
            get { return _race; }
            set
            {
                if(_race != value)
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
    }
}
