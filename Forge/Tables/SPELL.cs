using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table(Name ="SPELL")]
    public class SPELL
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string School { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SubSchool { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Effect { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string CastingTime { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Components { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Range { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Area { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Targets { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Duration { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SavingThrow { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string SpellResistance { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Level { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string ShortDescription { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Domain { get; set; }
    }
}
