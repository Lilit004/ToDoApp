using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-ICI6R6K; Database=ToDoDB; Integrated Security=True; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);

        }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<ToDoStatus> ToDoStatuses { get; set; }
    }
}
