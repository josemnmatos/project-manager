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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>()
                .HasData(
                new Manager(
                    "John",
                    "johnmanager@email.com",
                    "password")
                {
                    Id = 1,
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
                    "Mark",
                    "markdev@email.com",
                    "passwordmark")
                {
                    Id = 2,
                },
                new Developer(
                    "Anna",
                    "annadev@email.com",
                    "passwordanna")
                {
                    Id = 3,
                }
                );


            modelBuilder.Entity<Entities.Task>()
                .HasData(
                new Entities.Task("Build Interface")
                {
                    Id = 1,
                    Description = "Build buttons and outer interface",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 2,
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
                    DeveloperId = 3,
                    Deadline = DateTime.UtcNow.AddDays(35),
                    ProjectId = 1,
                },
                new Entities.Task("Integrate Weather API")
                {
                    Id = 4,
                    Description = "Integrate App with an Weather API",
                    State = CurrentState.Completed,
                    DeveloperId = 3,
                    Deadline = DateTime.UtcNow.AddDays(60),
                    ProjectId = 2,
                },
                new Entities.Task("Make a search bar")
                {
                    Id = 5,
                    Description = "Build a search bar for user search",
                    State = CurrentState.AssignedWaitingCompletion,
                    DeveloperId = 2,
                    Deadline = DateTime.UtcNow.AddDays(60),
                    ProjectId = 2,
                },
                new Entities.Task("Deploy app")
                {
                    Id = 6,
                    Description = "Deploy app online",
                    State = CurrentState.NotAssigned,
                    DeveloperId = 3,

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
