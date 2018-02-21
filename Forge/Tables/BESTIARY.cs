using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class BESTIARY
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public float CR { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int XP { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Race { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Class1 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Class1Level { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Class2 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Class2Level { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Alignment { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Size { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Type { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType1 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType2 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType3 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType4 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType5 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubType6 { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int AC { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int ACTouch { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int ACFlatFooted { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int HP { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string HD { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Fort { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Ref { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Will { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Melee { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Ranged { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Reach { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Str { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Dex { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Con { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Int { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Wis { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Cha { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Feats { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Skills { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string RacialMods { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Languages { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SQ { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Environment { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Organization { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Treasure { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Group { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Gear { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string OtherGear { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Speed { get; set; }
    }
}
