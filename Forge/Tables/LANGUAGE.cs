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
    public class LANGUAGE
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }

        private EntitySet<PLAYER_LANGUAGE> _playerLanguage = new EntitySet<PLAYER_LANGUAGE>();
        [Association(Name = "FK_PLAYER_LANGUAGE_LANGUAGE", Storage = "_playerLanguage", OtherKey = "LanguageID", ThisKey = "ID")]
        private ICollection<PLAYER_LANGUAGE> PLAYER_LANGUAGE
        {
            get { return _playerLanguage; }
            set { _playerLanguage.Assign(value); }
        }

        public ICollection<PLAYER> Players { get { return (from pl in PLAYER_LANGUAGE select pl.PLAYER).ToList(); } }
    }
}
