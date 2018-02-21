using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
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
    /// Interaction logic for AddSkillDialog.xaml
    /// </summary>
    public partial class AddSkillDialog : UserControl, INotifyPropertyChanged
    {

        #region Private Variables
        private string _skillNameTxt = string.Empty;
        private string _description = string.Empty;
        #endregion

        #region Public Variables
        public string SkillNameTxt
        {
            get { return _skillNameTxt; }
            set
            {
                _skillNameTxt = value;
                NotifyOfPropertyChanged("SkillNameTxt");
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


        public AddSkillDialog()
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
            if (!Validation.GetHasError(SkillName) && !Validation.GetHasError(SkillDescription))
            {
                string skillName = SkillName.Text;
                string skillDes = SkillDescription.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                SKILL skill = new SKILL()
                {
                    Name = skillName,
                    Description = skillDes
                };
                forgeDatabase.Skills.InsertOnSubmit(skill);
                forgeDatabase.SubmitChanges();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddSkillDialog");
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
