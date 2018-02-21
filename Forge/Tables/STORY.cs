using System.Data.Linq.Mapping;

namespace Forge.Tables
{
    [Table]
    public class STORY
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Author { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Created { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Type { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }
    }
}
