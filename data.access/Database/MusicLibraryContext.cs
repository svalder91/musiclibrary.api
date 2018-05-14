﻿using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedMember.Local

namespace Demo.MusicLibrary.Api.DataAccess.Database
{
    internal sealed class MusicLibraryContext : DbContext
    {

        public MusicLibraryContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
        private DbSet<DbArtist> Artists { get; set; }
    }
}
