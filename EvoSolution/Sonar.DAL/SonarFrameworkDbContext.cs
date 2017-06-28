using Sonar.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System;

namespace Sonar.DAL
{
    internal class SonarEntityFrameworkContextInit : IDatabaseInitializer<SonarFrameworkDbContext>
    {
        public void InitializeDatabase(SonarFrameworkDbContext context)
        {

        }
    }

    public class SonarFrameworkDbContext : DbContext, IDbContext
    {
        public SonarFrameworkDbContext()
            : base("name=SonarFrameworkDbContext")
        {
            Database.SetInitializer(new SonarEntityFrameworkContextInit());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
        }

        public void Add(object entity)
        {
            Set(entity.GetType()).Add(entity);
        }

        public void Edit(object entity)
        {
            Set(entity.GetType()).Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object entity)
        {
            Set(entity.GetType()).Attach(entity);
            Entry(entity).State = EntityState.Deleted;
        }

        public virtual DbSet<State> State { get; set; }
        public IQueryable<State> QueryState { get { return State; } }


        public virtual DbSet<Address> Address { get; set; }
        public IQueryable<Address> QueryAddress { get { return Address; } }

        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public IQueryable<UserAccount> QueryUserAccount { get { return UserAccount; } }

    };

}
