using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailwayReservation.Models;

namespace RailwayReservation.DataLayer
{
    public class RailwayReservationContext : DbContext
    {
        public DbSet<Passenger> Passesngers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<DepartureFrequency> DepartureFrequency { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.DepartureStation)
                .WithMany()
                .HasForeignKey(s => s.DepartureStationId);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.ArrivalStation)
                .WithMany()
                .HasForeignKey(s => s.ArrivalStationId);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.Train)
                .WithMany()
                .HasForeignKey(s => s.TrainId);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.DepartureFrequency)
                .WithMany()
                .HasForeignKey(s => s.DepartureFrequecnyId);

            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.TrainNumber)
                .WithMany()
                .HasForeignKey(t => t.TrainNumberId);

            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.DepartureStation)
                .WithMany()
                .HasForeignKey(t => t.DepartureStationId);

            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.ArrivalStation)
                .WithMany()
                .HasForeignKey(t => t.ArrivalStationId);

            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Train>()
                .HasKey(t => t.TrainId);
        }
    }
}
