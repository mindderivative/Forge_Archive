using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class PlayerLanguageCollection : PropertyChangedBase
    {
        private int _id;
        private string _languageName;
        private string _languageDescription;

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
        public string LanguageName
        {
            get { return _languageName; }
            set
            {
                if (_languageName != value)
                {
                    _languageName = value;
                    NotifyOfPropertyChange(() => LanguageName);
                }
            }
        }
        public string LanguageDescription
        {
            get { return _languageDescription; }
            set
            {
                if (_languageDescription != value)
                {
                    _languageDescription = value;
                    NotifyOfPropertyChange(() => LanguageDescription);
                }
            }
        }
    }
}
