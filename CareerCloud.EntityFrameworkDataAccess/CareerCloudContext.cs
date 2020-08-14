using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext(DbContextOptions<CareerCloudContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PADYOO\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducationPocos { get;set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ApplicantEducationPoco
            modelBuilder.Entity<ApplicantEducationPoco>(entity =>
            {
                entity.ToTable("Applicant_Educations").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //ApplicantJobApplicationPoco
            modelBuilder.Entity<ApplicantJobApplicationPoco>(entity =>
            {
                entity.ToTable("Applicant_Job_Applications").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //ApplicantProfilePoco
            modelBuilder.Entity<ApplicantProfilePoco>(entity =>
           {
               entity.ToTable("Applicant_Profiles").HasKey(i => i.Id);
               entity.HasMany(e => e.ApplicantEducations).WithOne(a => a.ApplicantProfiles).HasForeignKey(l => l.Applicant);
               entity.HasMany(e => e.ApplicantJobApplications).WithOne(a => a.ApplicantProfiles).HasForeignKey(l => l.Applicant);
               entity.HasMany(e => e.ApplicantResumes).WithOne(a => a.ApplicantProfiles).HasForeignKey(l => l.Applicant);
               entity.HasMany(e => e.ApplicantSkills).WithOne(a => a.ApplicantProfiles).HasForeignKey(l => l.Applicant);
               entity.HasMany(e => e.ApplicantWorkHistories).WithOne(a => a.ApplicantProfiles).HasForeignKey(l => l.Applicant);
               entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();

           });

            //ApplicantResumePoco
            modelBuilder.Entity<ApplicantResumePoco>(entity =>
            {
                entity.ToTable("Applicant_Resumes").HasKey(i => i.Id);
            });

            //ApplicantSkillPoco
            modelBuilder.Entity<ApplicantSkillPoco>(entity =>
            {
                entity.ToTable("Applicant_Skills").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //ApplicantWorkHistoryPoco
            modelBuilder.Entity<ApplicantWorkHistoryPoco>(entity =>
            {
                entity.ToTable("Applicant_Work_History").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyDescriptionPoco
            modelBuilder.Entity<CompanyDescriptionPoco>(entity =>
            {
                entity.ToTable("Company_Descriptions").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyJobEducationPoco
            modelBuilder.Entity<CompanyJobEducationPoco>(entity =>
            {
                entity.ToTable("Company_Job_Educations").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyJobSkillPoco
            modelBuilder.Entity<CompanyJobSkillPoco>(entity =>
            {
                entity.ToTable("Company_Job_Skills").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });


            //CompanyJobPoco
            modelBuilder.Entity<CompanyJobPoco>(entity =>
            {
                entity.ToTable("Company_Jobs").HasKey(i => i.Id);
                entity.HasMany(e => e.CompanyJobDescriptions).WithOne(a => a.CompanyJobs).HasForeignKey(l => l.Job);
                entity.HasMany(e => e.CompanyJobEducations).WithOne(a => a.CompanyJobs).HasForeignKey(l => l.Job);
                entity.HasMany(e => e.CompanyJobSkills).WithOne(a => a.CompanyJobs).HasForeignKey(l => l.Job);
                entity.HasMany(e => e.ApplicantJobApplications).WithOne(a => a.CompanyJobs).HasForeignKey(l => l.Job);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyJobDescriptionPoco
            modelBuilder.Entity<CompanyJobDescriptionPoco>(entity =>
            {
                entity.ToTable("Company_Jobs_Descriptions").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyLocationPoco
            modelBuilder.Entity<CompanyLocationPoco>(entity =>
            {
                entity.ToTable("Company_Locations").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //CompanyProfilePoco

            modelBuilder.Entity<CompanyProfilePoco>(entity =>
            {
                entity.ToTable("Company_Profiles").HasKey(i => i.Id);
                entity.HasMany(e => e.CompanyDescriptions).WithOne(a => a.CompanyProfiles).HasForeignKey(l => l.Company);
                entity.HasMany(e => e.CompanyLocations).WithOne(a => a.CompanyProfiles).HasForeignKey(l => l.Company);
                entity.HasMany(e => e.CompanyJobs).WithOne(a => a.CompanyProfiles).HasForeignKey(l => l.Company);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //SecurityLoginPoco

            modelBuilder.Entity<SecurityLoginPoco>(entity =>
            {
                entity.ToTable("Security_Logins").HasKey(i => i.Id);
                entity.HasMany(e => e.ApplicantProfiles).WithOne(a => a.SecurityLogins).HasForeignKey(l => l.Login);
                entity.HasMany(e => e.SecurityLoginsLogs).WithOne(a => a.SecurityLogins).HasForeignKey(l => l.Login);
                entity.HasMany(e => e.SecurityLoginsRoles).WithOne(a => a.SecurityLogins).HasForeignKey(l => l.Login);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //SecurityLoginsLogPoco
            modelBuilder.Entity<SecurityLoginsLogPoco>(entity =>
            {
                entity.ToTable("Security_Logins_Log").HasKey(i => i.Id);
            });

            //SecurityLoginsRolePoco
            modelBuilder.Entity<SecurityLoginsRolePoco>(entity =>
            {
                entity.ToTable("Security_Logins_Roles").HasKey(i => i.Id);
                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
            });

            //SecurityRolePoco

            modelBuilder.Entity<SecurityRolePoco>(entity =>
            {
                entity.ToTable("Security_Roles").HasKey(i => i.Id);
                entity.HasMany(e => e.SecurityLoginsRoles).WithOne(a => a.SecurityRoles).HasForeignKey(l => l.Id);
            });


            //SystemCountryCode

            modelBuilder.Entity<SystemCountryCodePoco>(entity =>
            {
                entity.ToTable("System_Country_Codes").HasKey(i => i.Code);
                entity.HasMany(e => e.ApplicantProfiles).WithOne(a => a.SystemCountryCodes).HasForeignKey(l => l.Country);
                entity.HasMany(e => e.ApplicantWorkHistories).WithOne(a => a.SystemCountryCode).HasForeignKey(l => l.CountryCode);
            });

            //SystemLanguageCode

            modelBuilder.Entity<SystemLanguageCodePoco>(entity =>
            {
                entity.ToTable("System_Language_Codes").HasKey(i => i.LanguageID);
                entity.HasMany(e => e.CompanyDescriptions).WithOne(a => a.SystemLanguageCodes).HasForeignKey(l => l.LanguageId);

            });

            

            base.OnModelCreating(modelBuilder);


        }
    }
}
