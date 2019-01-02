using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebshopApp.Models;

namespace WebshopApp.Data
{
    public class WebshopAppContext : IdentityDbContext<WebshopAppUser>
    {
        public WebshopAppContext(DbContextOptions<WebshopAppContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<ReceiptOrder> ReceiptsOrders { get; set; }

        public DbSet<ClientReceipt> ClientsReceipts { get; set; }

        public DbSet<ShipmentData> ShipmentsDatas { get; set; }
               
        public DbSet<Image> Images { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<WebshopAppUser> WebshopAppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
