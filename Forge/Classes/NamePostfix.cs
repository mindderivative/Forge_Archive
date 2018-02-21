using Caliburn.Micro;

namespace Forge.Classes
{
    public class NamePostfix : PropertyChangedBase
    {
        private int _id;
        private string _postfix;
        private string _race;
        private string _sex;

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
        public string Postfix
        {
            get { return _postfix; }
            set
            {
                if (_postfix != value)
                {
                    _postfix = value;
                    NotifyOfPropertyChange(() => Postfix);
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
    }
}
