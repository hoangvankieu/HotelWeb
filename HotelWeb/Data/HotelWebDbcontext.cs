using HotelWeb.Models;
using HotelWeb.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Data
{
    public class HotelWebDbcontext : IdentityDbContext<IdentityUser>
    {
        public HotelWebDbcontext(DbContextOptions<HotelWebDbcontext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        
    }
}
