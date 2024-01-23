using Microsoft.EntityFrameworkCore;
using SztuderWiniecki.BikesApp.DAO_EF_SQLite.BO;

namespace SztuderWiniecki.BikesApp.DAO_EF_SQLite
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "bikes.db");
            DbPath = "C:\\db\\bikes.db";
            System.Diagnostics.Debug.WriteLine($"SQLite database path: {DbPath}");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}