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
            Database.SetInitializer(new Configuration());
        }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Items> Items { get; set; }
    }
    public class Configuration : CreateDatabaseIfNotExists<ShopDB>
    {
        protected override void Seed(ShopDB context)
        {
            context.User.Add(new Models.User()
            {
                Name = "Bora",
                Surname = "Kasmer"
            });
            context.Items.AddRange(new Items[]{
                new Items() {Image="xbox.jpg",Name="XboxOne",Price=1000},
                new Items() {Image="ps4.jpg",Name="Ps4",Price=1200},
                new Items() {Image="Holo.jpg",Name="HoloLens",Price=4000}
            });

            context.SaveChanges();
        }
    }

}