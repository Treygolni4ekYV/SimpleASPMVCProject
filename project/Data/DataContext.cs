using Microsoft.EntityFrameworkCore;
using project.Model;

namespace project.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users {get;set;} = null!;
    public DbSet<Comment> Comments {get;set;} = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }   
}