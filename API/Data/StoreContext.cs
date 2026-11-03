using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data;
//creating migration for the database context class
   
public class StoreContext(DbContextOptions options) : DbContext(options)

// Ensure no properties named "Database" or "SaveChanges()" are written here!
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }// Basket=name of table in database, Baskets= name of the property in the context class

}

