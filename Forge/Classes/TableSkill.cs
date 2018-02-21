using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class TableSkill : PropertyChangedBase
    {
        private object _skillID;
        private object _skillName;
        private object _skillDescription;

        public object SkillID
        {
            get { return _skillID; }
            set
            {
                if(_skillID != value)
                {
                    _skillID = value;
                    NotifyOfPropertyChange(() => SkillID);
                }
            }
        }
        public object SkillName
        {
            get { return _skillName; }
            set
            {
                if(_skillName != value)
                {
                    _skillName = value;
                    NotifyOfPropertyChange(() => SkillName);
                }
            }
        }
        public object SkillDescription
        {
            get { return _skillDescription; }
            set
            {
                if(_skillDescription != value)
                {
                    _skillDescription = value;
                    NotifyOfPropertyChange(() => SkillDescription);
                }
            }
        }
    }
}
