

namespace HR.Data.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public long CityId { get; set; }
    }
}
