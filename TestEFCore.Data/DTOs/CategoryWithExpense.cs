namespace ERS.Data.DTOs
{
    public class CategoryWithExpense
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public double TotalExpenses { get; set; }
    }
}
