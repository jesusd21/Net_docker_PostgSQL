using BasePostgresSql.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BasePostgresSql.Data
{
    public class BaseDataContext : DbContext
    {
        public DbSet<BaseModel> BaseModels { get; set; }
        public BaseDataContext(DbContextOptions<BaseDataContext> options) : base(options)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null)
                {
                    //Create Database if cannot connet
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    //Create Tables if no tables exist
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

