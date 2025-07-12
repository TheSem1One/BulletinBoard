using BulletinBoard.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BulletinBoard.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Announcements> Announcements { get; set; }

    }
}
