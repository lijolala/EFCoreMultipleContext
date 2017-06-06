using ERS.Data.Entities;

namespace ERS.Data.Entity
{
    public class Employee : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}