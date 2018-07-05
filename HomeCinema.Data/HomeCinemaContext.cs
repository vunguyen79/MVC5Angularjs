using HomeCinema.Data.Configurations;
using HomeCinema.Data.Helpers;
using HomeCinema.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HomeCinema.Data
{
    public class HomeCinemaContext : DbContext
    {
        public HomeCinemaContext() : base("HomeCinema")
        {
            if (!Utilities.GetBoolValue("ENABLE_CREATE_DATA"))
                Database.SetInitializer<HomeCinemaContext>(null);
            else
                Database.SetInitializer<HomeCinemaContext>(new DatabaseInitializer());
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Customer> CustomerSet { get; set; }
        public IDbSet<Movie> MovieSet { get; set; }
        public IDbSet<Genre> GenreSet { get; set; }
        public IDbSet<Stock> StockSet { get; set; }
        public IDbSet<Rental> RentalSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        public IDbSet<ProfileUser> ProfileUser { get; set; }
        public IDbSet<Country> Country { get; set; }
        public IDbSet<City> City { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());

            modelBuilder.Configurations.Add(new ProfileUserConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
        }
    }
}
