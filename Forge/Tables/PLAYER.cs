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
    public class PLAYER
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int StoryID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string PlayerName { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string CharacterName { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int HitPoints { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Alignment { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int ArmorClass { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int TouchAC { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int FlatFootedAC { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int CMD { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Fort { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Ref { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Will { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Str { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Dex { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Con { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Int { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Wis { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Cha { get; set; }

        private EntitySet<PLAYER_FACTION> _playerFaction = new EntitySet<PLAYER_FACTION>();
        [Association(Name = "FK_PLAYER_FACTION_PLAYER", Storage = "_playerFaction", OtherKey = "PlayerID", ThisKey = "ID")]
        private ICollection<PLAYER_FACTION> PLAYER_FACTION
        {
            get { return _playerFaction; }
            set { _playerFaction.Assign(value); }
        }

        public ICollection<FACTION> Factions { get { return (from pf in PLAYER_FACTION select pf.FACTION).ToList(); } }
        

        private EntitySet<PLAYER_LANGUAGE> _playerLanguage = new EntitySet<PLAYER_LANGUAGE>();
        [Association(Name = "FK_PLAYER_LANGUAGE_PLAYER", Storage = "_playerLanguage", OtherKey = "PlayerID", ThisKey = "ID")]
        private ICollection<PLAYER_LANGUAGE> PLAYER_LANGUAGE
        {
            get { return _playerLanguage; }
            set { _playerLanguage.Assign(value); }
        }

        public ICollection<LANGUAGE> Languages { get { return (from pl in PLAYER_LANGUAGE select pl.LANGUAGE).ToList(); } }

        private EntitySet<PLAYER_SKILL> _playerSkill = new EntitySet<PLAYER_SKILL>();
        [Association(Name = "FK_PLAYER_SKILL_PLAYER", Storage = "_playerSkill", OtherKey = "SkillID", ThisKey = "ID")]
        private ICollection<PLAYER_SKILL> PLAYER_SKILL
        {
            get { return _playerSkill; }
            set { _playerSkill.Assign(value); }
        }

        public ICollection<SKILL> Skills { get { return (from ps in PLAYER_SKILL select ps.SKILL).ToList(); } }
    }
}
