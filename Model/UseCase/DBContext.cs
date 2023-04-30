﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class DBContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Chord> Chord { get; set; }
        public DbSet<Singer> Singer { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<ChordsSong> ChordsSong { get; set; }
        public DbSet<Recent> Recent { get; set; }
        public DbSet<Saved> Saved { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}