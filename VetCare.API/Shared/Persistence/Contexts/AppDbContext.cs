using VetCare.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Faq.Domain.Models;
using VetCare.API.Identification.Domain.Models;
using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Store.Domain.Models;

namespace VetCare.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<PetOwner> PetOwners { get; set; }
    public DbSet<Vet> Vets { get; set; }
    
    public DbSet<Veterinary> Veterinary { get; set; }
    
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<Question> Questions { get; set; }
    
    

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<PetOwner>().ToTable("PetOwner");
        builder.Entity<PetOwner>().HasKey(p => p.Id);
        builder.Entity<PetOwner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PetOwner>().Property(p => p.Firstname).IsRequired().HasMaxLength(30);
        builder.Entity<PetOwner>().Property(p => p.Lastname).IsRequired().HasMaxLength(30);
        builder.Entity<PetOwner>().Property(p => p.Email).IsRequired();
        builder.Entity<PetOwner>().Property(p => p.Gender).IsRequired().HasMaxLength(30);
        builder.Entity<PetOwner>().Property(p => p.Birthdate).IsRequired().HasMaxLength(30);
        builder.Entity<PetOwner>().Property(p => p.ImageUrl).IsRequired();
        
        
        builder.Entity<Vet>().ToTable("Vet");
        builder.Entity<Vet>().HasKey(p => p.Id);
        builder.Entity<Vet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vet>().Property(p => p.Firstname).IsRequired().HasMaxLength(30);
        builder.Entity<Vet>().Property(p => p.Lastname).IsRequired().HasMaxLength(30);
        builder.Entity<Vet>().Property(p => p.Email).IsRequired();
        builder.Entity<Vet>().Property(p => p.Gender).IsRequired().HasMaxLength(30);
        builder.Entity<Vet>().Property(p => p.Birthdate).IsRequired().HasMaxLength(30);
        builder.Entity<Vet>().Property(p => p.ImageUrl).IsRequired();
        
        
        // Relationships
        builder.Entity<Vet>()
            .HasMany(p => p.Veterinary)
            .WithOne(p => p.Vet)
            .HasForeignKey(p => p.VetId);
        
        builder.Entity<Veterinary>().ToTable("Veterinary");
        builder.Entity<Veterinary>().HasKey(p => p.Id);
        builder.Entity<Veterinary>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Veterinary>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Veterinary>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Veterinary>().Property(p => p.Ranking).IsRequired();
        builder.Entity<Veterinary>().Property(p => p.Address).IsRequired();
        builder.Entity<Veterinary>().Property(p => p.phoneNumber).IsRequired();
        builder.Entity<Veterinary>().Property(p => p.imageUrl).IsRequired();
        
        

        builder.Entity<Pet>().ToTable("Pets");
        builder.Entity<Pet>().HasKey(p => p.Id);
        builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Pet>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Pet>().Property(p => p.Breed).IsRequired().HasMaxLength(30);
        builder.Entity<Pet>().Property(p => p.Weight).IsRequired();
        builder.Entity<Pet>().Property(p => p.Type).IsRequired();
        builder.Entity<Pet>().Property(p => p.photoUrl).IsRequired();
        builder.Entity<Pet>().Property(p => p.Color).IsRequired().HasMaxLength(30);
        builder.Entity<Pet>().Property(p => p.Date).IsRequired();
        
        // Relationships
        builder.Entity<Pet>()
            .HasMany(p => p.Prescriptions)
            .WithOne(p => p.Pet)
            .HasForeignKey(p => p.PetId);
        
        builder.Entity<Prescription>().ToTable("Prescriptions");
        builder.Entity<Prescription>().HasKey(p => p.Id);
        builder.Entity<Prescription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Prescription>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Prescription>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Prescription>().Property(p => p.Published).IsRequired();
        
        
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(200);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Image).HasMaxLength(250);
        builder.Entity<Product>().Property(p => p.Stock).IsRequired();
        
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Email).IsRequired();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.PasswordHash).IsRequired();

        
        builder.Entity<Question>().ToTable("Questions");
        builder.Entity<Question>().HasKey(p => p.Id);
        builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Question>().Property(p => p.Name).IsRequired();
        builder.Entity<Question>().Property(p => p.Description).IsRequired();
        
        
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}