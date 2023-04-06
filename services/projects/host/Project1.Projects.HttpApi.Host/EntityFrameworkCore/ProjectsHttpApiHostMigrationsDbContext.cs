using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Project1.Projects.EntityFrameworkCore;

public class ProjectsHttpApiHostMigrationsDbContext : AbpDbContext<ProjectsHttpApiHostMigrationsDbContext>
{
    public ProjectsHttpApiHostMigrationsDbContext(DbContextOptions<ProjectsHttpApiHostMigrationsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProjects();
    }
}