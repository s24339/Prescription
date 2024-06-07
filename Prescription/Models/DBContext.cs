using System;
using System.Collections.Generic;

namespace Prescription.Models
{
    public class DBContext
    {

        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public class DbContextOptions
        {
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(k => k.IdDoctor);
                e.Property(k => k.FirstName).HasMaxLength(100).IsRequired();
                e.Property(k => k.LastName).HasMaxLength(100).IsRequired();
                e.Property(k => k.Email).HasMaxLength(100).IsRequired();

                e.HasData(new List<Doctor>
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Mieszko",
                        LastName = "Pierwszy",
                        Email = "ostatni@example.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Zbyszko",
                        LastName = "Zbogdanca",
                        Email = "zbogdanca@example.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 3,
                        FirstName = "Ala",
                        LastName = "Makota",
                        Email = "makota@example.com"
                    }
                });
            });

            modelBuilder.Entity<Patient>(e =>
            {
                e.HasKey(k => k.IdPatient);
                e.Property(k => k.FirstName).HasMaxLength(100).IsRequired();
                e.Property(k => k.LastName).HasMaxLength(100).IsRequired();
                e.Property(k => k.BirthDate).IsRequired();

                e.HasData(new List<Patient>
                {
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Marek",
                        LastName = "Marucha",
                        BirthDate = DateTime.Now
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Tadeusz",
                        LastName = "Norek",
                        BirthDate = DateTime.Now
                    },
                    new Patient
                    {
                        IdPatient = 3,
                        FirstName = "Tomasz",
                        LastName = "Karolak",
                        BirthDate = DateTime.Now
                    }
                });
            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasKey(k => k.IdMedicament);
                e.Property(k => k.Name).HasMaxLength(100).IsRequired();
                e.Property(k => k.Description).HasMaxLength(100).IsRequired();
                e.Property(k => k.Type).HasMaxLength(100).IsRequired();

                e.HasData(new List<Medicament>
                {
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "APAP",
                        Description = "SomeDescription",
                        Type = "PainKiller"
                    }
                });
            });

            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasKey(k => k.IdPrescription);
                e.Property(k => k.Date).IsRequired();
                e.Property(k => k.DueDate).IsRequired();

                e.HasOne(e => e.Doctor)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientCascade);

                e.HasOne(e => e.Patient)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdPatient)
                    .OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(new List<Prescription>
                {
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        IdDoctor = 1,
                        IdPatient = 1
                    },
                    new Prescription
                    {
                        IdPrescription = 2,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        IdDoctor = 2,
                        IdPatient = 2
                    },
                    new Prescription
                    {
                        IdPrescription = 3,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        IdDoctor = 3,
                        IdPatient = 3
                    }
                });
            });

            modelBuilder.Entity<PrescriptionMedicament>(e =>
            {
                e.HasKey(k => new { k.IdMedicament, k.IdPrescription });

                e.HasOne(e => e.Medicament)
                    .WithMany(e => e.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientCascade);
                ;

                e.HasOne(e => e.Prescription)
                    .WithMany(e => e.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientCascade);

                e.Property(k => k.Details).IsRequired();

                e.HasData(new List<PrescriptionMedicament>
                {
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose = 200,
                        Details = "2x dziennie"
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Details = "Brać doraźnie"
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 3,
                        Dose = 400,
                        Details = "Max. 4 razy dziennie!"
                    }
                });
            });
        }
    }
}
