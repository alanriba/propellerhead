using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using propellerhead.dac.Models;

namespace propellerhead.dac.Providers
{
	public class PropellerheadContext : DbContext
	{
        private readonly DefaultShemaSettings defaultShemaSettings;
        public PropellerheadContext(DbContextOptions<PropellerheadContext> options, DefaultShemaSettings defaultShemaSettings)
			: base(options)
		{
				this.defaultShemaSettings = defaultShemaSettings;
        }

        public DbSet<CustomerEntity> CustomerEntities{ get; set; }

        public DbSet<StatusEntity> StatusEntities { get; set; }

        public DbSet<CustomerContactDetailEntity> CustomerDetailsContactEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(defaultShemaSettings.DefaultSchemaCustomer);

            #region Disable cascading deletion
            // Disable cascading deletion of all relationships in the database 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            #endregion

            #region Add Indexes
            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(m => m.CustomerNumber)
                .HasName("IX_TBL_CUSTOMER_CustomerNumber")
                .IsUnique();

            modelBuilder.Entity<CustomerContactDetailEntity>()
                .HasIndex(p => p.ContactId)
                .HasName("IX_TBL_DETAILS_CONTACT_ContactId");
            #endregion

            string customerNumberSequence = "customerNumberSequence";
            modelBuilder.HasSequence(customerNumberSequence)
                                   .StartsAt(100).IncrementsBy(1);
            modelBuilder.Entity<CustomerEntity>()
               .Property(x => x.CustomerNumber)
               .HasDefaultValueSql($"NEXT VALUE FOR [{defaultShemaSettings.DefaultSchemaCustomer}].[{customerNumberSequence}]");

            this.Seed(modelBuilder);
            //this.AddDescriptions(modelBuilder);

            

            base.OnModelCreating(modelBuilder);
        }

        #region Parameterized data seeding
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusEntity>()
                .HasData(
                new StatusEntity { StatusId = 1, StatusName = "prospective" },
                new StatusEntity { StatusId = 2, StatusName = "current" },
                new StatusEntity { StatusId = 3, StatusName = "non-active" });
        }
        #endregion

       /* private void AddDescriptions(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var description = entityType.ClrType.GetCustomAttributes(false)
                    .OfType<DescriptionAttribute>().Select(x => x.Description).FirstOrDefault();
                entityType.SetComment(description);
                foreach (var property in entityType.GetProperties())
                {
                    var propertyAccessMode = property.GetPropertyAccessMode();
                    property.SetPropertyAccessMode(PropertyAccessMode.PreferProperty);
                    var propertyInfo = property.GetMemberInfo(true, true);
                    var propertyDescription = propertyInfo.GetCustomAttributes(false)
                        .OfType<DescriptionAttribute>().Select(x => x.Description).FirstOrDefault();
                    property.SetComment(propertyDescription);
                    property.SetPropertyAccessMode(propertyAccessMode);
                }
            }
        }*/

    }
}