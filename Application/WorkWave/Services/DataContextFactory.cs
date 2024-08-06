using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DotNetEnv;
using System.IO;
using Repository;

namespace Services
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            Env.Load("connectionstring.env");

            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not set.");
            }


            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }
    }
}
