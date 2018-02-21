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
    public class PLAYER_LANGUAGE
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int PlayerID { get; set; }
        private EntityRef<PLAYER> _player = new EntityRef<PLAYER>();
        [Association(Name = "FK_PLAYER_LANGUAGE_PLAYER", IsForeignKey = true, Storage = "_player", ThisKey = "PlayerID")]
        public PLAYER PLAYER
        {
            get { return _player.Entity; }
            set { _player.Entity = value; }
        }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int LanguageID { get; set; }
        private EntityRef<LANGUAGE> _language = new EntityRef<LANGUAGE>();
        [Association(Name = "FK_PLAYER_LANGUAGE_LANGUAGE", IsForeignKey = true, Storage = "_language", ThisKey = "LanguageID")]
        public LANGUAGE LANGUAGE
        {
            get { return _language.Entity; }
            set { _language.Entity = value; }
        }
    }
}
