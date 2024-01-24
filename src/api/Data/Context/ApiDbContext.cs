
// using api.Models.EntityModel.Projects;
// using api.Models.EntityModel.Times;
// using api.Models.EntityModel.UserProjects;
using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.Projects;
using api.Models.EntityModel.Times;
using api.Models.EntityModel.UserProjects;
using api.Models.EntityModel.Users;
using api.Models.EntityModel.WorkedTimes;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<WorkedTime> WorkedTimes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Map();
            modelBuilder.Entity<Project>().Map();
            modelBuilder.Entity<Job>().Map();
            modelBuilder.Entity<Time>().Map();
            modelBuilder.Entity<UserProject>().Map();
            modelBuilder.Entity<WorkedTime>().Map();

        }
    }
}