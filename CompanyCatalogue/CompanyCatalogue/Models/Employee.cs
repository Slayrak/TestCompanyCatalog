namespace CompanyCatalogue.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Position { get; set; }

        public DateTime DateOfEmployment { get; set; }
        
        public int? BossId { get; set; }
        public Employee? Boss { get; set; }

        public List<Employee>? Subordinates { get; set; }

    }
}
