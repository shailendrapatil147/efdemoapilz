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
    public interface IefdemoContext
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<UserContactEntity> UserContact { get; set; }
        DbSet<UserDetailsEntity> UserDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges();
    }
}