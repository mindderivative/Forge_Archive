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

namespace Forge.ViewModels
{
    [Export(typeof(CodexViewModel))]
    public class CodexViewModel : Conductor<object>
    {
        #region Private Variables
        #endregion

        #region Public Variables
        #endregion

        [ImportingConstructor]
        public CodexViewModel()
        {
            Global.Instance.LoadedForge = "Spells";
            IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
            ActivateItem(new SpellsViewModel());
        }

        #region Private Methods
        #endregion

        #region Public Methods
        public void MenuControl(int sender)
        {
            switch (sender)
            {
                case 0:
                    Global.Instance.LoadedForge = "Spells";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new SpellsViewModel());
                    break;
                case 1:
                    Global.Instance.LoadedForge = "Bestiary";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new BestiaryViewModel());
                    break;
                case 2:
                    Global.Instance.LoadedForge = "Feats";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new FeatViewModel());
                    break;
                case 3:
                    Global.Instance.LoadedForge = "Skills";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new SkillsViewModel());
                    break;
                case 4:
                    //ActivateItem(new TimelineViewModel());
                    break;
                case 5:
                    Global.Instance.LoadedForge = "Languages";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new LanguageViewModel());
                    break;
                case 6:
                    Global.Instance.LoadedForge = "Factions";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new FactionViewModel());
                    break;
                case 7:
                    Global.Instance.LoadedForge = "Random Name Generator";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new NameGeneratorViewModel());
                    break;
                default:
                    Global.Instance.LoadedForge = "Spells";
                    IoC.Get<IEventAggregator>().PublishOnUIThread("SetLoadedForge");
                    ActivateItem(new SpellsViewModel());
                    break;
            }
        }
        #endregion
    }
}
