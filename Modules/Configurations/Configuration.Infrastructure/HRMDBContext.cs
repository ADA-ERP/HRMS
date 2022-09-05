
using Core.Constant;
using Core.Directory;
using Core.Domains;
using Core.Domains.Configuration;
using Core.Domains.Position;
using Domains.Configuration;
using Domains.Directory;
using Microsoft.EntityFrameworkCore;


namespace Configuration.Infrastructure
{
    public class HRMDBContext : DbContext
    {
        public HRMDBContext(DbContextOptions<HRMDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaryStructure>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(s => s.Maximum).HasColumnType("decimal(18,2)");
                s.Property(s => s.Range).HasColumnType("decimal(18,2)");
                s.Property(s => s.Midpoint).HasColumnType("decimal(18,2)");
                s.Property(s => s.Minimum).HasColumnType("decimal(18,2)");
                s.Property(s => s.Spread).HasColumnType("decimal(18,2)");
                s.Property(s => s.PayBand).IsRequired().HasMaxLength(Constant.MIN_STRING_LENGTH);
                s.Property(s=>s.Note).HasMaxLength(Constant.MAX_STRING_LENGTH);


            });

            modelBuilder.Entity<Branch>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(b => b.Name).HasMaxLength(Constant.MIN_STRING_LENGTH);
                b.HasMany(b => b.Departments).WithOne();
            });

            modelBuilder.Entity<Country>(c => {
                c.Property(c => c.Name).HasMaxLength(Constant.MID_STRING_LENGTH);
                c.Property(c => c.ISOCode).HasMaxLength(Constant.MIN_STRING_LENGTH);
                c.Property(c => c.AreaCode).HasMaxLength(Constant.MIN_STRING_LENGTH);
            });

           
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(Constant.MID_STRING_LENGTH);
            });

            
        
            
            modelBuilder.Entity<FieldOfStudy>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(Constant.MID_STRING_LENGTH);
            });

            modelBuilder.Entity<Company>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).HasMaxLength(Constant.MID_STRING_LENGTH);
                e.Property(p => p.PhoneTwo).HasMaxLength(Constant.MIN_STRING_LENGTH);
                e.Property(p => p.TinNumber).HasMaxLength(Constant.MIN_STRING_LENGTH);
                e.Property(p => p.Description).HasMaxLength(Constant.MAX_STRING_LENGTH);
            });
           
            modelBuilder.Entity<JobPosition>(j=>
            {
                j.Property(p=>p.PositionCode).IsRequired();
                j.HasIndex(p=>p.PositionCode).IsUnique();

            });
           
            modelBuilder.Entity<Department>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasIndex(p => p.Code).IsUnique();
                e.Property(p => p.Code).HasMaxLength(Constant.EXTRA_MIN_STRING_LENGTH);
                e.Property(p => p.Description).HasMaxLength(Constant.MAX_STRING_LENGTH);
            });

         
            modelBuilder.Entity<JobGrade>(j=>j.HasMany(g=>g.Positions));           
            modelBuilder.HasDefaultSchema("configuration");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
          
        }
      
        public DbSet<Title> Titles { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        public DbSet<Country> Countries {get;set;}
        public DbSet<Language> Languages { get; set; }
 
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobPosition> Positions { get; set; }
        public DbSet<JobGrade> JobGrades { get; set; }
        public DbSet<PositionChangeReason> PositionChangeReasons { get; set; }
        public DbSet<KeyValue> KeyValues { get; set; }
        public DbSet<SalaryStructure> SalaryStructure { get; set; }
        
    }
}
