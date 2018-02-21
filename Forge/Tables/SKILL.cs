using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Forge.Tables
{
    [Table]
    public class SKILL
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }

        private EntitySet<PLAYER_SKILL> _playerSkill = new EntitySet<PLAYER_SKILL>();
        [Association(Name = "FK_PLAYER_SKILL_SKILL", Storage = "_playerSkill", OtherKey = "SkillID", ThisKey = "ID")]
        private ICollection<PLAYER_SKILL> PLAYER_SKILL
        {
            get { return _playerSkill; }
            set { _playerSkill.Assign(value); }
        }

        public ICollection<PLAYER> Players { get { return (from ps in PLAYER_SKILL select ps.PLAYER).ToList(); } }
        public int SkillRank { get { return (from ps in PLAYER_SKILL where ps.SkillID == ID select ps.Rank).FirstOrDefault(); } }
    }
}
