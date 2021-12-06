using System.Collections.Generic;
using ItSkillHouse.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ItSkillHouse.Repositories.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnTechnologyModelCreating(modelBuilder);
            OnRoleModelCreating(modelBuilder);
            OnRecruiterModelCreating(modelBuilder);
            
            OnUserModelCreating(modelBuilder);
            OnUserRoleModelCreating(modelBuilder);
            OnTokenModelCreating(modelBuilder);
            
            OnClientProjectModelCreating(modelBuilder);
            OnClientUserModelCreating(modelBuilder);

            OnContractModelCreating(modelBuilder);
            OnContractorTechnologyModelCreating(modelBuilder);
            OnContractorModelCreating(modelBuilder);
            OnContractorNoteModelCreating(modelBuilder);
            OnRateModelCreating(modelBuilder);
        }
        
        private static void OnTechnologyModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Technology>()
                .HasIndex(technology => technology.Name)
                .IsUnique();
        }
        
        private static void OnRoleModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Role>()
                .HasIndex(role => role.Name)
                .IsUnique();

            modelBuilder
                .Entity<Role>()
                .Property(role => role.Name)
                .HasConversion(name => name.ToLower(), name => name);
            
            modelBuilder
                .Entity<Role>()
                .Property(role => role.Permissions)
                .HasConversion(
                    permissions => JsonConvert.SerializeObject(permissions),
                    permissions => JsonConvert.DeserializeObject<List<string>>(permissions)
                );
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
                .Property(user => user.Email)
                .HasConversion(email => email.ToLower(), email => email);
        }
        
        private static void OnUserRoleModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(userRole => userRole.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.RoleUsers)
                .HasForeignKey(userRole => userRole.RoleId);
        }

        private static void OnClientProjectModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientProject>()
                .HasOne(clientProject => clientProject.Client)
                .WithMany(client => client.ClientProjects)
                .HasForeignKey(clientProject => clientProject.ClientId);

            modelBuilder.Entity<ClientProject>()
                .HasOne(clientProject => clientProject.Contract)
                .WithOne(contract => contract.ClientProject)
                .HasForeignKey<Contract>(contract => contract.ClientProjectId);
        }
        
        private static void OnClientUserModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientUser>()
                .HasKey(clientUser => new { clientUser.UserId, clientUser.ClientId });

            modelBuilder.Entity<ClientUser>()
                .HasOne(clientUser => clientUser.User)
                .WithMany(user => user.UserClients)
                .HasForeignKey(clientUser => clientUser.UserId);

            modelBuilder.Entity<ClientUser>()
                .HasOne(clientUser => clientUser.Client)
                .WithMany(client => client.ClientUsers)
                .HasForeignKey(clientUser => clientUser.ClientId);
        }

        private static void OnContractModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.Contractor)
                .WithMany(contractor => contractor.Contracts)
                .HasForeignKey(contract => contract.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.Rate)
                .WithMany(rate => rate.Contracts)
                .HasForeignKey(contract => contract.RateId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.ClientProject)
                .WithOne(clientProject => clientProject.Contract)
                .HasForeignKey<Contract>(contract => contract.ClientProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.Recruiter)
                .WithMany(recruiter => recruiter.Contracts)
                .HasForeignKey(contract => contract.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        private static void OnContractorModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .HasOne(contractor => contractor.User)
                .WithOne(user => user.Contractor)
                .HasForeignKey<Contractor>(contractor => contractor.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contractor>()
                .HasOne(contractor => contractor.Recruiter)
                .WithMany(recruiter => recruiter.Contractors)
                .HasForeignKey(contractor => contractor.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        private static void OnContractorNoteModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractorNote>()
                .HasOne(contractorNote => contractorNote.Contractor)
                .WithMany(contractor => contractor.Notes)
                .HasForeignKey(contractorNote => contractorNote.ContractorId);
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
                .WithMany(technology => technology.TechnologyContractors)
                .HasForeignKey(contractorTechnology => contractorTechnology.TechnologyId);
        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientProject> ClientProjects { get; set; }
        public DbSet<ClientUser> ClientsUsers { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContractorNote> ContractorNotes { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<ContractorTechnology> ContractorsTechnologies { get; set; }
    }
}