using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ViewModels
{
    [Export(typeof(EncounterForgeViewModel))]
    public class EncounterForgeViewModel : Screen
    {
        #region Private Variables
        #endregion

        #region Public Variables
        #endregion

        [ImportingConstructor]
        public EncounterForgeViewModel()
        {

        }

        #region Private Methods
        #endregion

        #region Public Methods
        /*public void OpenProfile()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProfile");
        }

        public void OpenExamSim()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenExamSim");
        }

        public void OpenFlashCards()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenFlashCards");
        }

        public void OpenReview()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenReview");
        }

        public void OpenStatistics()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenStatistics");
        }

        public void OpenSettings()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenSettings");
            //RootDialogContent = new SettingsDialogControl();
            //IsRootDialogOpen = true;
        }*/
        #endregion
    }
}
