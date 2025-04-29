using SQLite;

namespace Assignment_1.Models
{
    public class InvoiceEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Mechanic { get; set; }
        public string? Material { get; set; }
        public double? TimeUsed { get; set; }
        public double? Price { get; set; }
    }

    public class UserEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Primary key for each entry
        public string? Name { get; set; }
        public string? Adresse { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Registry { get; set; }
        public string? Description { get; set; }
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public TimeSpan SelectedTime { get; set; } = TimeSpan.Zero;
    }
}
