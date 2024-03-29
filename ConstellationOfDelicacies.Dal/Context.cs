using ConstellationOfDelicacies.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstellationOfDelicacies.Dal.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal;


public class Context:DbContext
{
    public DbSet<OrdersDto> Orders { get; set; }
    public DbSet<ProfilesDto> Profiles { get; set; }
    public DbSet<RolesDto> Roles { get; set; }
    public DbSet<SpecializationsDto> Specializations { get; set; }
    public DbSet<TasksDto> Tasks { get; set; }
    public DbSet<TaskStatusesDto> TaskStatuses { get; set; }
    public DbSet<UsersDto> Users { get; set; }
    
    public Context()
    {
        // Database.EnsureDeletedAsync();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Options.ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
    }
}