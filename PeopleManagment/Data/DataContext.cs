using Microsoft.EntityFrameworkCore;
using PeopleManagment.Models;

namespace PeopleManagment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                   
        }

        public DbSet<People> peoples => Set<People>();
    }
}
