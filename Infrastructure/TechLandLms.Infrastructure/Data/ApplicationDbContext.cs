
using Microsoft.EntityFrameworkCore;
using TechLandLms.Core.Entities;

namespace TechLandLms.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Feature>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[FeatureSeqId]");
                entity.HasOne(x => x.ParentEntity)
                    .WithMany(x => x.SubFeatureList)
                    .HasForeignKey(x => x.ParentFeatureId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AppUser>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[AppUserSeqId]");
            builder.Entity<AppSetting>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[AppSettingSeqId]");
            builder.Entity<MenuConfig>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[MenuConfigSeqId]");
            builder.Entity<Role>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[RoleSeqId]");
            builder.Entity<RoleFeature>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[RoleFeatureSeqId]");
            builder.Entity<UserRole>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[UserRoleSeqId]");
            //builder.Entity<Constant>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[ConstantSeqId]");
            builder.Entity<City>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[CitySeqId]");
            builder.Entity<Course>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[CourseSeqId]");
            builder.Entity<EduGroup>()
                .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[EduGroupSeqId]");
            //builder.Entity<EduGroupCourse>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[EduGroupCourseSeqId]");
            //builder.Entity<EduGroupMeeting>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[EduGroupMeetingSeqId]");
            //builder.Entity<EduGroupMember>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[EduGroupMemberSeqId]");
            //builder.Entity<Meeting>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[MeetingSeqId]");
            //builder.Entity<Province>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[ProvinceSeqId]");
            //builder.Entity<RelatedProduct>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[RelatedProductSeqId]");
            //builder.Entity<RelatedQuestion>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[RelatedQuestionSeqId]");
            //builder.Entity<Teacher>()
            //    .Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR [dbo].[TeacherSeqId]"); 
            builder.Entity<LogInfo>()
               .Property(o => o.LogId).HasDefaultValueSql("NEXT VALUE FOR [dbo].[LogInfoSeqId]");

        }

        public DbSet<City> City { get; set; }
        //public DbSet<Constant> Constant { get; set; }
        //public DbSet<Course> Course { get; set; }
        //public DbSet<AppUser> AppUser { get; set; }
        public DbSet<EduGroup> EduGroup { get; set; }
        //public DbSet<EduGroupCourse> EduGroupCourse { get; set; }
        //public DbSet<EduGroupMeeting> EduGroupMeeting { get; set; }
        //public DbSet<EduGroupMember> EduGroupMember { get; set; }
        //public DbSet<Meeting> Meeting { get; set; }
        //public DbSet<Province> Province { get; set; }
        //public DbSet<RelatedProduct> RelatedProduct { get; set; }
        //public DbSet<RelatedQuestion> RelatedQuestion { get; set; }
        //public DbSet<Teacher> Teacher { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppSetting> AppSetting { get; set; }
        public DbSet<MenuConfig> MenuConfig { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleFeature> RoleFeature { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<LogInfo> LogInfo { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
