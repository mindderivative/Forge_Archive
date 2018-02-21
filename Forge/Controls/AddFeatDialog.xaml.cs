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
    /// Interaction logic for AddFeatDialog.xaml
    /// </summary>
    public partial class AddFeatDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private string _featNameTxt;
        private string _description;
        private string _benefit;
        #endregion

        #region Public Variables
        public string FeatNameTxt
        {
            get { return _featNameTxt; }
            set
            {
                _featNameTxt = value;
                NotifyOfPropertyChanged("FeatNameTxt");
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
        public string Benefit
        {
            get { return _benefit; }
            set
            {
                _benefit = value;
                NotifyOfPropertyChanged("Benefit");
            }
        }
        #endregion

        public AddFeatDialog()
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
            if(!Validation.GetHasError(FeatName) && !Validation.GetHasError(FeatDescription) && !Validation.GetHasError(FeatBenefit))
            {
                string featName = FeatName.Text;
                string featDes = FeatDescription.Text;
                string featBen = FeatBenefit.Text;
                string featPre = FeatPrerequisites.Text;
                string featSpe = FeatSpecial.Text;
                string featType = FeatType.Text;
                string featNormal = FeatNormal.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                FEAT feat = new FEAT()
                {
                    Name = featName,
                    Description = featDes,
                    Benefit = featBen,
                    Prerequisites = featPre,
                    Special = featSpe,
                    Type = featType,
                    Normal = featNormal
                };

                forgeDatabase.Feats.InsertOnSubmit(feat);
                forgeDatabase.SubmitChanges();

                PopulateFeatCollection();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddFeatDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
            }
        }

        private void PopulateFeatCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempFeatCollection = new BindableCollection<FeatCollection>();

            foreach (var feat in forgeDatabase.Feats)
            {
                tempFeatCollection.Add(new FeatCollection
                {
                    FeatID = feat.ID,
                    FeatName = feat.Name,
                    FeatDescription = feat.Description,
                    FeatBenefit = feat.Benefit,
                    FeatPrerequisites = feat.Prerequisites,
                    FeatSpecial = feat.Special,
                    FeatType = feat.Type,
                    FeatNormal = feat.Normal
                });
            }

            if (!tempFeatCollection.SequenceEqual(Global.Instance.FeatCollection))
            {
                Global.Instance.FeatCollection = new BindableCollection<FeatCollection>(tempFeatCollection);
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
