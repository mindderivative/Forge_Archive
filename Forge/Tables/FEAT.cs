using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class FEAT
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Benefit { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Prerequisites { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Special { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Type { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Normal { get; set; }
    }
}
