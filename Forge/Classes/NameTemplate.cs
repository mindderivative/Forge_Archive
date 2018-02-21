using Caliburn.Micro;

namespace Forge.Classes
{
    public class NameTemplate : PropertyChangedBase
    {
        private string _firstName;
        private string _lastName;
        private string _affix;
        private string _postfix;
        private string _fullName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if(_firstName != value)
                {
                    _firstName = value;
                    NotifyOfPropertyChange(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if(_lastName != value)
                {
                    _lastName = value;
                    NotifyOfPropertyChange(() => LastName);
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
        public string Postfix
        {
            get { return _postfix; }
            set
            {
                if(_postfix != value)
                {
                    _postfix = value;
                    NotifyOfPropertyChange(() => Postfix);
                }
            }
        }
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if(_fullName != value)
                {
                    _fullName = value;
                    NotifyOfPropertyChange(() => FullName);
                }
            }
        }
    }
}
