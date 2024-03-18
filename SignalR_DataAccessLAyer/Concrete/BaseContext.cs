using Microsoft.EntityFrameworkCore;
using SignalR_EntityLayer.Entities;

namespace SignalR_DataAccessLayer.Concrete;

public class BaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server =(localdb)\\MSSQLLocalDB ; initial catalog = SignalRDb ; integrated Security = true");
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DiscountOfDay> DiscountOfDays { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}
