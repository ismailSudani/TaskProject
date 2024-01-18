using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskProject.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.HasData(
                    new TaskStatus { Id = 1, Name = "Not Started" },
                    new TaskStatus { Id = 2, Name = "In Progress" },
                    new TaskStatus { Id = 3, Name = "Completed" }
                    );
            });
            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasData(
                    new Task { Id = 1, Title = " first task title", Description = " Description of firt task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID=1 },
                    new Task { Id = 2, Title = "  second task title", Description = " Description of second task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 3, Title = " third task title", Description = " Description of third task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 4, Title = " fourth task title", Description = " Description of fourth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 5, Title = " Fifth task title", Description = " Description of Fifth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 6, Title = " Sixth task title", Description = " Description of Sixth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 7, Title = " Seventh task title", Description = " Description of Seventh task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 8, Title = " Eighth task title", Description = " Description of Eighth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 9, Title = " Ninth task title", Description = " Description of Ninth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 },
                    new Task { Id = 10, Title = " tenth task title", Description = " Description of tenth task is here ", Assignee = "isamil.sudani2022@gmail.com", StatusID = 1 }
                    );
            });
        }
    }
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public  string Assignee { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }= DateTime.Now;
        
        public int StatusID { get; set; } = 1;
        [ForeignKey("StatusID")]
        public TaskStatus? Status { get; set;}
    }
    public class TaskStatus
    {
        public TaskStatus()
        {
           // Tasks=new HashSet<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
