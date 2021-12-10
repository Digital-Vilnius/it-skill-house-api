using ItSkillHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnProfessionModelCreating(modelBuilder);
            OnTagModelCreating(modelBuilder);
            OnTechnologyModelCreating(modelBuilder);
            
            OnNoteModelCreating(modelBuilder);
            OnRateModelCreating(modelBuilder);
            
            OnRecruiterModelCreating(modelBuilder);
            
            OnUserModelCreating(modelBuilder);
            OnTokenModelCreating(modelBuilder);
            
            OnContractorTechnologyModelCreating(modelBuilder);
            OnContractorModelCreating(modelBuilder);
            OnContractorTagModelCreating(modelBuilder);
        }
        
        private static void OnTechnologyModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Technology>()
                .HasIndex(technology => technology.Name)
                .IsUnique();
        }
        
        private static void OnProfessionModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Profession>()
                .HasIndex(profession => profession.Name)
                .IsUnique();
        }
        
        private static void OnTagModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Tag>()
                .HasIndex(tag => tag.Name)
                .IsUnique();
        }

        private static void OnRecruiterModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recruiter>()
                .HasOne(recruiter => recruiter.User)
                .WithOne(user => user.Recruiter)
                .HasForeignKey<Recruiter>(recruiter => recruiter.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void OnUserModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();
            
            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Phone)
                .IsUnique();
            
            modelBuilder
                .Entity<User>()
                .Property(user => user.Email)
                .HasConversion(email => email.ToLower(), email => email);
        }
        
        private static void OnContractorModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .HasOne(contractor => contractor.User)
                .WithOne(user => user.Contractor)
                .HasForeignKey<Contractor>(contractor => contractor.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Contractor>()
                .HasOne(contractor => contractor.Profession)
                .WithMany(profession => profession.Contractors)
                .HasForeignKey(contractor => contractor.ProfessionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contractor>()
                .HasOne(contractor => contractor.Recruiter)
                .WithMany(recruiter => recruiter.Contractors)
                .HasForeignKey(contractor => contractor.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        private static void OnNoteModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(note => note.Contractor)
                .WithMany(contractor => contractor.Notes)
                .HasForeignKey(note => note.ContractorId);
        }
        
        private static void OnRateModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .HasOne(rate => rate.Contractor)
                .WithMany(contractor => contractor.Rates)
                .HasForeignKey(rate => rate.ContractorId);
        }
        
        private static void OnTokenModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>()
                .HasOne(token => token.User)
                .WithMany(user => user.Tokens)
                .HasForeignKey(token => token.UserId);
        }
        
        private static void OnContractorTechnologyModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractorTechnology>()
                .HasKey(contractorTechnology => new { contractorTechnology.ContractorId, contractorTechnology.TechnologyId });

            modelBuilder.Entity<ContractorTechnology>()
                .HasOne(contractorTechnology => contractorTechnology.Contractor)
                .WithMany(contractor => contractor.Technologies)
                .HasForeignKey(contractorTechnology => contractorTechnology.ContractorId);

            modelBuilder.Entity<ContractorTechnology>()
                .HasOne(contractorTechnology => contractorTechnology.Technology)
                .WithMany(technology => technology.Contractors)
                .HasForeignKey(contractorTechnology => contractorTechnology.TechnologyId);
        }
        
        private static void OnContractorTagModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractorTag>()
                .HasKey(contractorTag => new { contractorTag.ContractorId, contractorTag.TagId });

            modelBuilder.Entity<ContractorTag>()
                .HasOne(contractorTag => contractorTag.Contractor)
                .WithMany(contractor => contractor.Tags)
                .HasForeignKey(contractorTag => contractorTag.ContractorId);

            modelBuilder.Entity<ContractorTag>()
                .HasOne(contractorTag => contractorTag.Tag)
                .WithMany(tag => tag.Contractors)
                .HasForeignKey(contractorTag => contractorTag.TagId);
        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profession> Professions { get; set; }
        
        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Note> Notes { get; set; }
        public DbSet<Rate> Rates { get; set; }
        
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContractorTechnology> ContractorsTechnologies { get; set; }
        public DbSet<ContractorTag> ContractorsTags { get; set; }
    }
}