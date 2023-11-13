using AssessmentEF.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace AssessmentEF.DataAccess.Context
{
    public class EntityFrameworkDbContext: DbContext
    {
        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options)
        {
            
        }
        public EntityFrameworkDbContext()
        {
        }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; AttachDBFilename=[DataDirectory]\AssessmentDb.mdf; Trusted_Connection=True; MultipleActiveResultSets=True;".Replace("[DataDirectory]", path));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.ToTable("Personnels").HasKey(i=>i.ID);

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50);
                entity.Property(i => i.Surname).HasColumnName("Surname").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("BirthDate").HasColumnType("date");
                entity.Property(i => i.Gender).HasColumnName("Gender");
                entity.HasOne(i => i.Salary)
                    .WithOne()
                    .HasForeignKey<Salary>(i => i.PersonnelId)
                    .HasConstraintName("personnel_salary_id_fk");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salaries").HasKey(i=>i.PersonnelId);

                entity.Property(i => i.PersonnelId).HasColumnName("PersonnelId").IsRequired();
                entity.Property(i => i.Department).HasColumnName("Department");
                entity.Property(i => i.PersonnelSalary).HasColumnName("Salary");
            });        

            


            base.OnModelCreating(modelBuilder);
        }

    }
}
