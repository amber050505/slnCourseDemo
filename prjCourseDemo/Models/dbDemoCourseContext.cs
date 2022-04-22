using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class dbDemoCourseContext : DbContext
    {
        public dbDemoCourseContext()
        {
        }

        public dbDemoCourseContext(DbContextOptions<dbDemoCourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }
        public virtual DbSet<TCourseInformation> TCourseInformations { get; set; }
        public virtual DbSet<TCourseInformationImg> TCourseInformationImgs { get; set; }
        public virtual DbSet<TCourseModle> TCourseModles { get; set; }
        public virtual DbSet<TCourseModleDetail> TCourseModleDetails { get; set; }
        public virtual DbSet<TOrder> TOrders { get; set; }
        public virtual DbSet<TOrderDetail> TOrderDetails { get; set; }
        public virtual DbSet<TShoppingCart> TShoppingCarts { get; set; }
        public virtual DbSet<TTeachingMaterial> TTeachingMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbDemoCourse;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<StudentProfile>(entity =>
            {
                entity.ToTable("StudentProfile", "Identity");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<TCourseInformation>(entity =>
            {
                entity.HasKey(e => e.FEchelonId);

                entity.ToTable("tCourseInformation");

                entity.Property(e => e.FEchelonId)
                    .HasMaxLength(50)
                    .HasColumnName("fEchelonId");

                entity.Property(e => e.FBasicPeople).HasColumnName("fBasicPeople");

                entity.Property(e => e.FClassRoom)
                    .HasMaxLength(50)
                    .HasColumnName("fClassRoom");

                entity.Property(e => e.FClassState).HasColumnName("fClassState");

                entity.Property(e => e.FCourseId)
                    .HasMaxLength(50)
                    .HasColumnName("fCourseId");

                entity.Property(e => e.FCoverImg)
                    .HasMaxLength(50)
                    .HasColumnName("fCoverImg");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FDiscountDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fDiscountDate");

                entity.Property(e => e.FEndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fEndTime");

                entity.Property(e => e.FLimitPeople).HasColumnName("fLimitPeople");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FSaverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");

                entity.Property(e => e.FStartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fStartTime");

                entity.Property(e => e.FTeacher)
                    .HasMaxLength(50)
                    .HasColumnName("fTeacher");

                entity.Property(e => e.FTime)
                    .HasMaxLength(50)
                    .HasColumnName("fTime");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TCourseInformations)
                    .HasForeignKey(d => d.FCourseId)
                    .HasConstraintName("FK_tCourseInformation_tCourseModle");
            });

            modelBuilder.Entity<TCourseInformationImg>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK_tCourseModleImg");

                entity.ToTable("tCourseInformationImg");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCourseImageName)
                    .HasMaxLength(50)
                    .HasColumnName("fCourseImageName");

                entity.Property(e => e.FEchelonId)
                    .HasMaxLength(50)
                    .HasColumnName("fEchelonId");

                entity.HasOne(d => d.FEchelon)
                    .WithMany(p => p.TCourseInformationImgs)
                    .HasForeignKey(d => d.FEchelonId)
                    .HasConstraintName("FK_tCourseModleImg_tCourseModle");
            });

            modelBuilder.Entity<TCourseModle>(entity =>
            {
                entity.HasKey(e => e.FCourseId);

                entity.ToTable("tCourseModle");

                entity.Property(e => e.FCourseId)
                    .HasMaxLength(50)
                    .HasColumnName("fCourseId");

                entity.Property(e => e.FCategory).HasColumnName("fCategory");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FGrade)
                    .HasMaxLength(50)
                    .HasColumnName("fGrade");

                entity.Property(e => e.FModleSate).HasColumnName("fModleSate");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FOriginalPrice)
                    .HasColumnType("money")
                    .HasColumnName("fOriginalPrice");

                entity.Property(e => e.FSaverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");

                entity.Property(e => e.FSchoolYear).HasColumnName("fSchoolYear");

                entity.Property(e => e.FSpecialOffer)
                    .HasColumnType("money")
                    .HasColumnName("fSpecialOffer");

                entity.Property(e => e.FSummary)
                    .HasMaxLength(500)
                    .HasColumnName("fSummary");

                entity.Property(e => e.FTeachingMaterial)
                    .HasMaxLength(50)
                    .HasColumnName("fTeachingMaterial");

                entity.Property(e => e.FTotalHours).HasColumnName("fTotalHours");

                entity.Property(e => e.FTotalNumber).HasColumnName("fTotalNumber");

                entity.HasOne(d => d.FTeachingMaterialNavigation)
                    .WithMany(p => p.TCourseModles)
                    .HasForeignKey(d => d.FTeachingMaterial)
                    .HasConstraintName("FK_tCourseModle_tTeachingMaterials");
            });

            modelBuilder.Entity<TCourseModleDetail>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tCourseModleDetail");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCourseId)
                    .HasMaxLength(50)
                    .HasColumnName("fCourseId");

                entity.Property(e => e.FCourseNumber).HasColumnName("fCourseNumber");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FRemark)
                    .HasMaxLength(500)
                    .HasColumnName("fRemark");

                entity.Property(e => e.FSaverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");

                entity.Property(e => e.FSchedule)
                    .HasMaxLength(50)
                    .HasColumnName("fSchedule");

                entity.Property(e => e.FScheduleDetail)
                    .HasMaxLength(500)
                    .HasColumnName("fScheduleDetail");

                entity.Property(e => e.FTeachingMethod)
                    .HasMaxLength(50)
                    .HasColumnName("fTeachingMethod");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TCourseModleDetails)
                    .HasForeignKey(d => d.FCourseId)
                    .HasConstraintName("FK_tCourseModleDetail_tCourseModle");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.FOrderId);

                entity.ToTable("tOrder");

                entity.Property(e => e.FOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("fOrderId");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FOrderState).HasColumnName("fOrderState");

                entity.Property(e => e.FPayment).HasColumnName("fPayment");

                entity.Property(e => e.FSaverDaate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDaate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fUserId");
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tOrderDetail");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FEchelonId)
                    .HasMaxLength(50)
                    .HasColumnName("fEchelonId");

                entity.Property(e => e.FMoney)
                    .HasColumnType("money")
                    .HasColumnName("fMoney");

                entity.Property(e => e.FOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("fOrderId");

                entity.Property(e => e.FReceiverId)
                    .HasMaxLength(50)
                    .HasColumnName("fReceiverId");

                entity.Property(e => e.FSaverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");

                entity.HasOne(d => d.FEchelon)
                    .WithMany(p => p.TOrderDetails)
                    .HasForeignKey(d => d.FEchelonId)
                    .HasConstraintName("FK_tOrderDetail_tCourseInformation");

                entity.HasOne(d => d.FOrder)
                    .WithMany(p => p.TOrderDetails)
                    .HasForeignKey(d => d.FOrderId)
                    .HasConstraintName("FK_tOrderDetail_tOrder");
            });

            modelBuilder.Entity<TShoppingCart>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tShoppingCart");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FEchelonId)
                    .HasMaxLength(50)
                    .HasColumnName("fEchelonId");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fUserId");

                entity.HasOne(d => d.FEchelon)
                    .WithMany(p => p.TShoppingCarts)
                    .HasForeignKey(d => d.FEchelonId)
                    .HasConstraintName("FK_tShoppingCart_tCourseInformation");
            });

            modelBuilder.Entity<TTeachingMaterial>(entity =>
            {
                entity.HasKey(e => e.FTeachingMaterial);

                entity.ToTable("tTeachingMaterials");

                entity.Property(e => e.FTeachingMaterial)
                    .HasMaxLength(50)
                    .HasColumnName("fTeachingMaterial");

                entity.Property(e => e.FAuthor)
                    .HasMaxLength(50)
                    .HasColumnName("fAuthor");

                entity.Property(e => e.FCategory).HasColumnName("fCategory");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FCreationUser)
                    .HasMaxLength(50)
                    .HasColumnName("fCreationUser");

                entity.Property(e => e.FMaterialsSate).HasColumnName("fMaterialsSate");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPress)
                    .HasMaxLength(50)
                    .HasColumnName("fPress");

                entity.Property(e => e.FSaverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSaverDate");

                entity.Property(e => e.FSaverUser)
                    .HasMaxLength(50)
                    .HasColumnName("fSaverUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
