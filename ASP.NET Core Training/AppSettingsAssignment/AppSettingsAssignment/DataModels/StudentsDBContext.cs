using Microsoft.EntityFrameworkCore;

namespace AppSettingsAssignment.DataModels
{
    public class StudentsDBContext : DbContext
    {
        public StudentsDBContext(DbContextOptions<StudentsDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentsDataModel> Students { get; set; }
    }
}
