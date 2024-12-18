using GYM_Body_Light_API.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace GYM_Body_Light_API.Src.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public DbSet<TypeClass> TypeClasses { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<Membership_> Memberships { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Category> Categories { get; set; }
        
  
        
       

    }
}