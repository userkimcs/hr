

namespace HR.Data.Entities
{
    public class Town : BaseEntity
    {
        public string Name { get; set; }
        public long DistrictId { get; set; }
    }
}
