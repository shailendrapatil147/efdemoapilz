using LZ.Common.efdemo;
using LZ.Common.Logging;
using LZ.Models.efdemo.Entity;
using LZ.Models.efdemo.Entity.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LZ.DataLayer.efdemo.Context
{
    public class efdemoContext : DbContext, IefdemoContext
    {
        protected IConfiguration _configuration;
        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<UserContactEntity> UserContact { get; set; }
        public virtual DbSet<UserDetailsEntity> UserDetails { get; set; }
        public efdemoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Password).HasColumnName("Password");

                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.Property(e => e.UserContactId).HasColumnName("fkUserContactId");
                entity.Property(e => e.UserDetailId).HasColumnName("fkUserDetailId");

                entity.HasKey(e => e.UserId).HasName("UerId").HasName("PK_User");

                //entity.HasOne(d => d.FkUserContacttNavigation)
                //    .WithOne(p => p.FkUserNavigation)
                //    .HasForeignKey("UserContactId");

                //entity.HasOne(d => d.FkUserContacttNavigation)
                //    .WithMany(p=> p.)
                //    .HasForeignKey(d => d.UserContactId);
                //    //.HasConstraintName("FK_CartContactInfo_Cart");

                //entity.HasOne(d => d.FkUserDetailsNavigation)
                //    .WithOne(p => p.FkUserNavigation)
                //    .HasForeignKey<UserDetailsEntity>(ud => ud.Id);
            });

            modelBuilder.Entity<UserContactEntity>(entity =>
            {
                entity.Property(e => e.City).HasColumnName("City");
                entity.Property(e => e.Area).HasColumnName("Area");

                entity.Property(e => e.Pinccode).HasColumnName("Pinccode");
                entity.Property(e => e.State).HasColumnName("State");

                entity.HasKey(e => e.Id).HasName("Id").HasName("PK_UserContact");

                //entity.HasOne(d => d.FkUserContacttNavigation)
                //    .WithOne(p => p.FkUserNavigation)
                //    .HasForeignKey("UserContactId");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.FkUserContacttNavigation)
                    .HasForeignKey(d => d.Id);
                    //.HasConstraintName("FK_CartContactInfo_Cart");

                //entity.HasOne(d => d.FkUserDetailsNavigation)
                //    .WithOne(p => p.FkUserNavigation)
                //    .HasForeignKey<UserDetailsEntity>(ud => ud.Id);
            });

            modelBuilder.Entity<UserDetailsEntity>(entity =>
            {
                entity.Property(e => e.LastName).HasColumnName("LastName");
                entity.Property(e => e.FirstName).HasColumnName("FirstName");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.HasKey(e => e.Id).HasName("Id").HasName("PK_UserDetails");

                //entity.HasOne(d => d.FkUserContacttNavigation)
                //    .WithOne(p => p.FkUserNavigation)
                //    .HasForeignKey("UserContactId");

                //entity.HasOne(d => d.FkUserContacttNavigation)
                //    .WithMany(p => p.)
                //    .HasForeignKey(d => d.UserContactId);
                //.HasConstraintName("FK_CartContactInfo_Cart");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithOne(p => p.FkUserDetailsNavigation)
                    .HasForeignKey<UserDetailsEntity>(ud => ud.Id);
            });
        }

        #region Audit BaseEntity

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            DateTime now = DateTime.Now;
            IEnumerable<EntityEntry<BaseEntity>> changeset = ChangeTracker.Entries<BaseEntity>();
            //foreach (EntityEntry<BaseEntity> entityEntry in changeset)
            //{
            //    switch (entityEntry.State)
            //    {
            //        case EntityState.Added:
            //            entityEntry.Entity.DtCreated = now;
            //            entityEntry.Entity.DtLastUpdated = now;
            //            break;
            //        case EntityState.Modified:
            //            entityEntry.Entity.DtLastUpdated = now;
            //            break;
            //    }
            //}

            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().Result;
        }

        #endregion

        #region Transaction Wrapper

        protected delegate Task<T> TransactionScopeDelegate<T>();

        protected static async Task<T> WithTransaction<T>(DatabaseFacade db, TransactionScopeDelegate<T> functor)
        {
            T t;
            using (var transaction = db.BeginTransaction(IsolationLevel.Unspecified))
            {
                try
                {
                    t = await functor().ConfigureAwait(false);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return t;
        }
        #endregion
    }
}