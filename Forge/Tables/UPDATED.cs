using System.Data.Linq.Mapping;

namespace Forge.Tables
{
    [Table]
    public class UPDATED
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int StoryID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string LastUpdated { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Note { get; set; }
    }
}
