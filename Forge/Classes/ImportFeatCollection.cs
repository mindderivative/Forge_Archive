using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class ImportFeatCollection : PropertyChangedBase
    {
        private string _featName;
        private string _featDescription;
        private string _featBenefit;
        private string _featPrerequisites;
        private string _featSpecial;
        private string _featType;
        private string _featNormal;

        public string FeatName
        {
            get { return _featName; }
            set
            {
                if (_featName != value)
                {
                    _featName = value;
                    NotifyOfPropertyChange(() => FeatName);
                }
            }
        }
        public string FeatDescription
        {
            get { return _featDescription; }
            set
            {
                if (_featDescription != value)
                {
                    _featDescription = value;
                    NotifyOfPropertyChange(() => FeatDescription);
                }
            }
        }
        public string FeatBenefit
        {
            get { return _featBenefit; }
            set
            {
                if (_featBenefit != value)
                {
                    _featBenefit = value;
                    NotifyOfPropertyChange(() => FeatBenefit);
                }
            }
        }
        public string FeatPrerequisites
        {
            get { return _featPrerequisites; }
            set
            {
                if (_featPrerequisites != value)
                {
                    _featPrerequisites = value;
                    NotifyOfPropertyChange(() => FeatPrerequisites);
                }
            }
        }
        public string FeatSpecial
        {
            get { return _featSpecial; }
            set
            {
                if (_featSpecial != value)
                {
                    _featSpecial = value;
                    NotifyOfPropertyChange(() => FeatSpecial);
                }
            }
        }
        public string FeatType
        {
            get { return _featType; }
            set
            {
                if (_featType != value)
                {
                    _featType = value;
                    NotifyOfPropertyChange(() => FeatType);
                }
            }
        }
        public string FeatNormal
        {
            get { return _featNormal; }
            set
            {
                if (_featNormal != value)
                {
                    _featNormal = value;
                    NotifyOfPropertyChange(() => FeatNormal);
                }
            }
        }
    }
}
