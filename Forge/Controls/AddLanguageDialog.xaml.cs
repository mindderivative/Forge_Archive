using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forge.Controls
{
    /// <summary>
    /// Interaction logic for AddLanguageDialog.xaml
    /// </summary>
    public partial class AddLanguageDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private string _languageNameTxt = string.Empty;
        private string _description = string.Empty;
        #endregion

        #region Public Variables
        public string LanguageNameTxt
        {
            get { return _languageNameTxt; }
            set
            {
                _languageNameTxt = value;
                NotifyOfPropertyChanged("LanguageNameTxt");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChanged("Description");
            }
        }
        #endregion

        public AddLanguageDialog()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(LanguageName) && !Validation.GetHasError(LanguageDescription))
            {
                string langName = LanguageName.Text;
                string langDes = LanguageDescription.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                LANGUAGE language = new LANGUAGE()
                {
                    Name = langName,
                    Description = langDes
                };
                forgeDatabase.Languages.InsertOnSubmit(language);
                forgeDatabase.SubmitChanges();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddLanguageDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
            }
        }
        #endregion

        #region PropteryChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged(string sProp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));
        }
        #endregion
    }
}
