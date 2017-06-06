using ERS.Data.Entities;

namespace TestEFCore.Data.Entity
{
    public class Employee : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}