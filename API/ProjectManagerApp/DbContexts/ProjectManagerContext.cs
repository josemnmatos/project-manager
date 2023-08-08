using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.Entities;

namespace ProjectManagerApp.DbContexts
{
    public class ProjectManagerContext : DbContext
{
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Entities.Task> Tasks { get; set; } = null!;
        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.ProjectAssociatedTo)
                .HasForeignKey(t => t.ProjectId)
                .IsRequired();

            modelBuilder.Entity<Developer>()
                .HasMany(d => d.Tasks)
                .WithOne(t => t.DeveloperAssignedTo)
                .HasForeignKey(t => t.DeveloperId)
                .IsRequired(false);


            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Projects)
                .WithOne(p => p.ManagerAssignedTo)
                .HasForeignKey(p => p.ManagerId)
                .IsRequired();





            modelBuilder.Entity<User>()
                .HasData(
                new User(
                    "John",
                    "Marks",
                    "johnmanager@email.com",
                    "password",
                    "manager")
                {
                    Id = 1,
                }, 
                new User(
                    "Mark",
                    "Anthony",
                    "markdev@email.com",
                    "passwordmark",
                    "developer")
                {
                    Id = 2,
                }, 
                new User(
                    "Anna",
                    "Peters",
                    "annadev@email.com",
                    "passwordanna",
                    "developer")
                {
                    Id = 3,
                });



            modelBuilder.Entity<Manager>()
                .HasData(
                new Manager(
                    "johnmanager@email.com",
                    "John",
                    "Marks")
                {
                    UserId = 1,
                    Id= 1
                });

        
            modelBuilder.Entity<Project>()
                .HasData(
                new Project("Calculator")
                {
                    Id = 1,
                    ManagerId = 1,
                    Budget = 100
                },
                new Project("Weather App")
                {
                    Id = 2,
                    ManagerId = 1,
                    Budget = 5000
                }
                );

            modelBuilder.Entity<Developer>()
                .HasData(
                new Developer(
                    "jmarkdev@email.com",
                    "Mark",
                    "Anthony")
                {
                    UserId = 2,
                    Id= 1,
                },
                new Developer(
                    "annadev@email.com",
                    "Anna",
                    "Peters")
                {
                    UserId = 3,
                    Id = 2
                }
                );


            modelBuilder.Entity<Entities.Task>()
                .HasData(
                new Entities.Task("Build Interface")
                {
                    Id = 1,
                    Description = "Build buttons and outer interface",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 1,
                    Deadline = DateTime.UtcNow.AddDays(31),
                    ProjectId = 1,
                },
                new Entities.Task("Make sum logic")
                {
                    Id = 2,
                    Description = "Build logic for the sum operation",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 2,
                    Deadline = DateTime.UtcNow.AddDays(31),
                    ProjectId = 1,
                },
                new Entities.Task("Make multiplication logic")
                {
                    Id = 3,
                    Description = "Build logic for the multiplication operation",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 2,
                    Deadline = DateTime.UtcNow.AddDays(35),
                    ProjectId = 1,
                },
                new Entities.Task("Integrate Weather API")
                {
                    Id = 4,
                    Description = "Integrate App with an Weather API",
                    State = CurrentState.Completed,
                    DeveloperId = 2,
                    Deadline = DateTime.UtcNow.AddDays(60),
                    ProjectId = 2,
                },
                new Entities.Task("Make a search bar")
                {
                    Id = 5,
                    Description = "Build a search bar for user search",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 1,
                    Deadline = DateTime.UtcNow.AddDays(60),
                    ProjectId = 2,
                },
                new Entities.Task("Deploy app")
                {
                    Id = 6,
                    Description = "Deploy app online",
                    State = CurrentState.NotAssigned,
                    DeveloperId = 2,

                    Deadline = DateTime.UtcNow.AddDays(90),
                    ProjectId = 2,
                }


                ) ;
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           
            optionsBuilder.UseSqlServer(
                new SqlConnectionStringBuilder()
                {
                    DataSource = "(localdb)\\mssqllocaldb",
                    InitialCatalog = "ProjectManagerDb-1",
                    TrustServerCertificate = true,
                    MultipleActiveResultSets = true,


                }.ConnectionString

                );
            base.OnConfiguring(optionsBuilder);
        }




    }
}
