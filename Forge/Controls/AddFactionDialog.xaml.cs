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
    /// Interaction logic for AddFactionDialog.xaml
    /// </summary>
    public partial class AddFactionDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private string _factionNameTxt = string.Empty;
        private string _description = string.Empty;
        #endregion

        #region Public Variables
        public string FactionNameTxt
        {
            get { return _factionNameTxt; }
            set
            {
                _factionNameTxt = value;
                NotifyOfPropertyChanged("FactionNameTxt");
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

        public AddFactionDialog()
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
            if (!Validation.GetHasError(FactionName) && !Validation.GetHasError(FactionDescription))
            {
                string factionName = FactionName.Text;
                string factionDes = FactionDescription.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                FACTION faction = new FACTION()
                {
                    Name = factionName,
                    Description = factionDes                    
                };
                forgeDatabase.Factions.InsertOnSubmit(faction);
                forgeDatabase.SubmitChanges();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddFactionDialog");
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
