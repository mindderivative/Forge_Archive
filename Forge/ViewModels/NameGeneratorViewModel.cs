using Caliburn.Micro;
using System.ComponentModel.Composition;
using MaterialDesignColors;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SQLite;
using Forge.Classes;
using System.Windows;

namespace Forge.ViewModels
{
    [Export(typeof(NameGeneratorViewModel))]
    public class NameGeneratorViewModel : Screen
    {
        #region Private Variables
        private List<string> _elfPrefixes = new List<string>();
        private List<string> _elfHouseSuffixes = new List<string>();
        private List<string> _elfHousePrefixes = new List<string>();
        private List<string> _elfSuffixes = new List<string>();
        private List<string> _drowPrefixes = new List<string>();
        private List<string> _drowSuffixes = new List<string>();
        private List<string> _drowHouseSuffixes = new List<string>();
        private List<string> _drowHousePrefixes = new List<string>();
        private BindableCollection<NameTemplate> _nameCollection = new BindableCollection<NameTemplate>();
        private string _firstName = string.Empty;
        private string _lastname = string.Empty;
        private string _affix = string.Empty;
        private string _postfix = string.Empty;
        private Random rand = new Random();
        private string _selectedRace = "Aasimar";
        private bool _affixChecked = true;
        private bool _firstNameChecked = true;
        private bool _lastNameChecked = true;
        private bool _postfixChecked = true;
        private bool _isMale = true;
        #endregion

        #region Public Variables
        public BindableCollection<NameTemplate> NameCollection
        {
            get { return _nameCollection; }
            set
            {
                if(_nameCollection != value)
                {
                    _nameCollection = value;
                    NotifyOfPropertyChange(() => NameCollection);
                }
            }
        }
        public bool AffixChecked
        {
            get { return _affixChecked; }
            set
            {
                if (_affixChecked != value)
                {
                    _affixChecked = value;
                    NotifyOfPropertyChange(() => AffixChecked);
                }
            }
        }
        public bool FirstNameChecked
        {
            get { return _firstNameChecked; }
            set
            {
                if(_firstNameChecked != value)
                {
                    _firstNameChecked = value;
                    NotifyOfPropertyChange(() => FirstNameChecked);
                }
            }
        }
        public bool LastNameChecked
        {
            get { return _lastNameChecked; }
            set
            {
                if(_lastNameChecked != value)
                {
                    _lastNameChecked = value;
                    NotifyOfPropertyChange(() => LastNameChecked);
                }
            }
        }
        public bool PostfixChecked
        {
            get { return _postfixChecked; }
            set
            {
                if(_postfixChecked != value)
                {
                    _postfixChecked = value;
                    NotifyOfPropertyChange(() => PostfixChecked);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public NameGeneratorViewModel()
        {

        }

        #region Private Methods
        private string CapitalizeFirstLetter(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        #endregion

        #region Public Methods
        public void GenerateRandomNames()
        {
            _firstName = string.Empty;
            _lastname = string.Empty;
            _affix = string.Empty;
            _postfix = string.Empty;
            
            NameCollection = new BindableCollection<NameTemplate>();
            var tempNameCollection = new List<NameTemplate>();
            var tempFirstPrefixCollection = new List<NamePrefix>();
            var tempFirstSuffixCollection = new List<NameSuffix>();
            var tempFirstInfixCollection = new List<NameInfix>();
            var tempLastPrefixCollection = new List<NamePrefix>();
            var tempLastSuffixCollection = new List<NameSuffix>();
            var tempLastInfixCollection = new List<NameInfix>();
            var tempAffixCollection = new List<NameAffix>();
            var tempPostfixCollection = new List<NamePostfix>();

            switch(_selectedRace)
            {
                case "Dhampir":
                    _selectedRace = "Human";
                    break;
                case "Half-Elf":
                    _selectedRace = "Elf";
                    break;
                default:
                    break;
            }

            if (_isMale)
            {
                tempAffixCollection = new List<NameAffix>(Global.Instance.AffixCollection.Where(x => x.Race == _selectedRace && (x.Sex == "Male" || x.Sex == "Both")));
                tempFirstPrefixCollection = new List<NamePrefix>(Global.Instance.PrefixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Male" || x.Sex == "Both")));
                tempFirstSuffixCollection = new List<NameSuffix>(Global.Instance.SuffixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Male" || x.Sex == "Both")));
                tempFirstInfixCollection = new List<NameInfix>(Global.Instance.InfixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Male" || x.Sex == "Both")));
                tempLastPrefixCollection = new List<NamePrefix>(Global.Instance.PrefixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Male" || x.Sex == "Both")));
                tempLastSuffixCollection = new List<NameSuffix>(Global.Instance.SuffixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Male" || x.Sex == "Both")));
                tempLastInfixCollection = new List<NameInfix>(Global.Instance.InfixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Male" || x.Sex == "Both")));
                tempPostfixCollection = new List<NamePostfix>(Global.Instance.PostfixCollection.Where(x => x.Race == _selectedRace && (x.Sex == "Male" || x.Sex == "Both")));
            }
            else
            {
                tempAffixCollection = new List<NameAffix>(Global.Instance.AffixCollection.Where(x => x.Race == _selectedRace && (x.Sex == "Female" || x.Sex == "Both")));
                tempFirstPrefixCollection = new List<NamePrefix>(Global.Instance.PrefixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Female" || x.Sex == "Both")));
                tempFirstSuffixCollection = new List<NameSuffix>(Global.Instance.SuffixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Female" || x.Sex == "Both")));
                tempFirstInfixCollection = new List<NameInfix>(Global.Instance.InfixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "First" && (x.Sex == "Female" || x.Sex == "Both")));
                tempLastPrefixCollection = new List<NamePrefix>(Global.Instance.PrefixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Female" || x.Sex == "Both")));
                tempLastSuffixCollection = new List<NameSuffix>(Global.Instance.SuffixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Female" || x.Sex == "Both")));
                tempLastInfixCollection = new List<NameInfix>(Global.Instance.InfixCollection.Where(x => x.Race == _selectedRace && x.FirstLast == "Last" && (x.Sex == "Female" || x.Sex == "Both")));
                tempPostfixCollection = new List<NamePostfix>(Global.Instance.PostfixCollection.Where(x => x.Race == _selectedRace && (x.Sex == "Female" || x.Sex == "Both")));
            }

            

            for (int i = 0; i <= 100; i++)
            {
                var _fullName = string.Empty;

                if (tempAffixCollection.Count > 0)
                    _affix = tempAffixCollection[rand.Next(0, tempAffixCollection.Count)].Affix;

                if(tempFirstInfixCollection.Count > 0)
                {
                    if(tempFirstPrefixCollection.Count > 0 && tempFirstSuffixCollection.Count > 0)
                    {
                        _firstName = tempFirstPrefixCollection[rand.Next(0, tempFirstPrefixCollection.Count)].Prefix
                                    + tempFirstInfixCollection[rand.Next(0, tempFirstInfixCollection.Count)].Infix
                                    + tempFirstSuffixCollection[rand.Next(0, tempFirstSuffixCollection.Count)].Suffix;
                    }
                }
                else
                {
                    if (tempFirstPrefixCollection.Count > 0 && tempFirstSuffixCollection.Count > 0)
                    {
                        _firstName = tempFirstPrefixCollection[rand.Next(0, tempFirstPrefixCollection.Count)].Prefix
                                    + tempFirstSuffixCollection[rand.Next(0, tempFirstSuffixCollection.Count)].Suffix;
                    }
                }
                    
                if(tempLastInfixCollection.Count > 0)
                {
                    if(tempLastPrefixCollection.Count > 0 && tempLastSuffixCollection.Count > 0)
                    {
                        _lastname = tempLastPrefixCollection[rand.Next(0, tempLastPrefixCollection.Count)].Prefix
                                + tempLastInfixCollection[rand.Next(0, tempLastInfixCollection.Count)].Infix
                                + tempLastSuffixCollection[rand.Next(0, tempLastSuffixCollection.Count)].Suffix;
                    }
                    
                }
                else
                {
                    if (tempLastPrefixCollection.Count > 0 && tempLastSuffixCollection.Count > 0)
                    {
                        _lastname = tempLastPrefixCollection[rand.Next(0, tempLastPrefixCollection.Count)].Prefix
                                + tempLastSuffixCollection[rand.Next(0, tempLastSuffixCollection.Count)].Suffix;
                    }
                }
                
                if(tempPostfixCollection.Count > 0)
                    _postfix = tempPostfixCollection[rand.Next(0, tempPostfixCollection.Count)].Postfix;

                if(AffixChecked)
                {
                    _fullName += _affix + " ";
                }

                if(FirstNameChecked)
                {
                    _fullName += _firstName;
                }

                if(FirstNameChecked && LastNameChecked)
                {
                    _fullName += " ";
                }

                if(LastNameChecked)
                {
                    _fullName += _lastname;
                }

                if(PostfixChecked)
                {
                    _fullName += " " + _postfix;
                }

                tempNameCollection.Add(new NameTemplate
                {
                    Affix = _affix,
                    FirstName = _firstName,
                    LastName = _lastname,
                    Postfix = _postfix,
                    FullName = _fullName
                });
            }

            NameCollection = new BindableCollection<NameTemplate>(tempNameCollection);
        }

        public void IsChecked(object sender, EventArgs e)
        {
            _selectedRace = (sender as RadioButton).Content.ToString();
        }

        public void IsSexChecked(object sender, EventArgs e)
        {
            var selectedSex = (sender as RadioButton).Content.ToString();

            switch(selectedSex)
            {
                case "Male":
                    _isMale = true;
                    break;
                case "Female":
                    _isMale = false;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
