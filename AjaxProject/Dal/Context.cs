using Microsoft.EntityFrameworkCore;

namespace AjaxProject.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-JTNUQFE\\SQLEXPRESS ;initial Catalog=AjaxDb; integrated Security=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}