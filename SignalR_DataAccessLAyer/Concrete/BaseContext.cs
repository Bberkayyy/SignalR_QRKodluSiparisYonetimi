using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR_EntityLayer.Entities;
using System.Reflection.Metadata;

namespace SignalR_DataAccessLayer.Concrete;

public class BaseContext : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server =(localdb)\\MSSQLLocalDB ; initial catalog = SignalRDb ; integrated Security = true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>().ToTable(opt => opt.HasTrigger("UpdateCartTotalAmount"));
        modelBuilder.Entity<Order>().ToTable(opt => opt.HasTrigger("SumMoneyCases"));
        modelBuilder.Entity<OrderDetail>().ToTable(opt => opt.HasTrigger("DecreaseOrderTotalPrice"));
        modelBuilder.Entity<OrderDetail>().ToTable(opt => opt.HasTrigger("IncreaseOrderTotalPrice"));
        modelBuilder.Entity<OrderDetail>().ToTable(opt => opt.HasTrigger("UpdateOrderDetailsTotalPrice"));
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
        //{
        //    entity.HasKey(e => e.UserId);
        //});
        //modelBuilder.Entity<IdentityUserRole<int>>(entity =>
        //{
        //    entity.HasKey(e => new { e.UserId, e.RoleId });
        //});
        //modelBuilder.Entity<IdentityUserToken<int>>(entity =>
        //{
        //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        //});

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
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<MoneyCase> MoneyCases { get; set; }
    public DbSet<RestaurantTable> RestaurantTables { get; set; }
    public DbSet<FooterInfo> FooterInfos { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
}
