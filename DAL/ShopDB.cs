namespace DAL
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class ShopDB : DbContext
    {
        // Your context has been configured to use a 'ShopDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.ShopDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopDB' 
        // connection string in the application configuration file.
        public ShopDB()
            : base("name=ShopDB")
        {
        }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Items> Items { get; set; }
    }
    internal sealed class Configuration : CreateDatabaseIfNotExists<ShopDB>
    {
        protected override void Seed(ShopDB context)
        {
            context.User.Add(new Models.User()
            {
                Name = "Bora",
                Surname = "Kasmer"
            });
            context.Items.AddRange(new Items[]{
                new Items() {Image="",Name="Xbox",Price=1000},
                new Items() {Image="",Name="Ps4",Price=1200},
            });

            context.SaveChanges();
        }
    }

}