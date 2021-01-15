using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class softwareContext : DbContext
    {
        public softwareContext()
        {
        }

        public softwareContext(DbContextOptions<softwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorysoftware> Categorysoftwares { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Computertype> Computertypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Installedsoftware> Installedsoftwares { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<OpenRequest> OpenRequests { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Soft> Softs { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<Typelicense> Typelicenses { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Masmetus2018;database=software", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorysoftware>(entity =>
            {
                entity.ToTable("categorysoftware");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasColumnType("char(30)")
                    .HasColumnName("category")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactInfoSupport)
                    .HasColumnType("char(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("component");

                entity.HasIndex(e => e.IdComponentType, "id_componentType");

                entity.HasIndex(e => e.IdComputer, "id_computer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComponentType).HasColumnName("id_componentType");

                entity.Property(e => e.IdComputer).HasColumnName("id_computer");

                entity.Property(e => e.IsWorking).HasDefaultValueSql("'1'");

                entity.Property(e => e.SN)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("S/N")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Specs)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdComponentTypeNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.IdComponentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("component_ibfk_2");

                entity.HasOne(d => d.IdComputerNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.IdComputer)
                    .HasConstraintName("component_ibfk_1");
            });

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("computer");

                entity.HasIndex(e => e.IdCompyterType, "ID_compyterType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComponent).HasColumnName("id_component");

                entity.Property(e => e.IdCompyterType).HasColumnName("ID_compyterType");

                entity.Property(e => e.IdWorkPlace).HasColumnName("ID_WorkPlace");

                entity.Property(e => e.Inv)
                    .IsRequired()
                    .HasColumnType("char(20)")
                    .HasColumnName("INV")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsWorking)
                    .IsRequired()
                    .HasColumnName("isWorking")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdCompyterTypeNavigation)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.IdCompyterType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("computer_ibfk_1");
            });

            modelBuilder.Entity<Computertype>(entity =>
            {
                entity.ToTable("computertype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.InstituteId, "Institute_id");

                entity.HasIndex(e => e.WorkersId, "workers_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstituteId).HasColumnName("Institute_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WorkersId).HasColumnName("workers_id");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_ibfk_1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Installedsoftware>(entity =>
            {
                entity.ToTable("installedsoftware");

                entity.HasIndex(e => e.IdSoftware, "ID_Software");

                entity.HasIndex(e => e.IdComputer, "ID_computer");

                entity.HasIndex(e => e.IdEnginere, "ID_enginere");

                entity.HasIndex(e => e.TypeLicenseId, "TypeLicense_ID");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComputer).HasColumnName("ID_computer");

                entity.Property(e => e.IdEnginere).HasColumnName("ID_enginere");

                entity.Property(e => e.IdRoom).HasColumnName("ID_room");

                entity.Property(e => e.IdSoftware).HasColumnName("ID_Software");

                entity.Property(e => e.InstallationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LicenseEnd).HasColumnType("date");

                entity.Property(e => e.LicenseStart).HasColumnType("date");

                entity.Property(e => e.TypeLicenseId).HasColumnName("TypeLicense_ID");

                entity.Property(e => e.WorkStatus)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdComputerNavigation)
                    .WithMany(p => p.Installedsoftwares)
                    .HasForeignKey(d => d.IdComputer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installedsoftware_ibfk_10");

                entity.HasOne(d => d.IdEnginereNavigation)
                    .WithMany(p => p.Installedsoftwares)
                    .HasForeignKey(d => d.IdEnginere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installedsoftware_ibfk_5");

                entity.HasOne(d => d.IdSoftwareNavigation)
                    .WithMany(p => p.Installedsoftwares)
                    .HasForeignKey(d => d.IdSoftware)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installedsoftware_ibfk_7");

                entity.HasOne(d => d.TypeLicense)
                    .WithMany(p => p.Installedsoftwares)
                    .HasForeignKey(d => d.TypeLicenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installedsoftware_ibfk_9");
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.ToTable("institute");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstituteName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Monitor>(entity =>
            {
                entity.ToTable("monitor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdWorkPlace).HasColumnName("ID_WorkPlace");

                entity.Property(e => e.Inv)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("INV")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsWorking)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SN)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("S/N")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<OpenRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("open_request");

                entity.HasComment("View 'software.open_request' references invalid table(s) or column(s) or function(s) or definer/invoker of view lack rights to use them");
            });

            modelBuilder.Entity<PostType>(entity =>
            {
                entity.ToTable("post_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PostType1)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("Post_Type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.HasIndex(e => e.IdComputer, "ID_Computer");

                entity.HasIndex(e => e.IdEnginner, "ID_Enginner");

                entity.HasIndex(e => e.InstalledsoftwareId, "request_ibfk_6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationClosingDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DescriptionOfTheProblem)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdComputer).HasColumnName("ID_Computer");

                entity.Property(e => e.IdEnginner).HasColumnName("ID_Enginner");

                entity.Property(e => e.InstalledsoftwareId).HasColumnName("installedsoftware_ID");

                entity.Property(e => e.RequestStatus)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdEnginnerNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.IdEnginner)
                    .HasConstraintName("request_ibfk_3");

                entity.HasOne(d => d.Installedsoftware)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.InstalledsoftwareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_ibfk_2");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.HasIndex(e => e.IdDepartment, "id_department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_ibfk_1");
            });

            modelBuilder.Entity<Soft>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("soft");

                entity.HasComment("View 'software.soft' references invalid table(s) or column(s) or function(s) or definer/invoker of view lack rights to use them");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.HasIndex(e => e.IdCategory, "ID_Category");

                entity.HasIndex(e => e.IdCompany, "ID_Company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCategory).HasColumnName("ID_Category");

                entity.Property(e => e.IdCompany).HasColumnName("ID_Company");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Softwares)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("software_ibfk_2");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Softwares)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("software_ibfk_1");
            });

            modelBuilder.Entity<Typelicense>(entity =>
            {
                entity.ToTable("typelicense");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeLicense1)
                    .IsRequired()
                    .HasColumnType("char(20)")
                    .HasColumnName("TypeLicense")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("workers");

                entity.HasIndex(e => e.PostId, "Post_ID");

                entity.HasIndex(e => e.DepartmentNameId, "workers_ibfk_2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentNameId).HasColumnName("DepartmentName_ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workers_ibfk_2");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workers_ibfk_1");
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.ToTable("workplace");

                entity.HasIndex(e => e.IdRoom, "idRoom");

                entity.HasIndex(e => e.IdComputer, "workplace_ibfk_1");

                entity.HasIndex(e => e.IdMonitor, "workplace_ibfk_2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdComputer).HasColumnName("ID_computer");

                entity.Property(e => e.IdMonitor).HasColumnName("ID_Monitor");

                entity.Property(e => e.IdRoom).HasColumnName("idRoom");

                entity.Property(e => e.Number)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdComputerNavigation)
                    .WithMany(p => p.Workplaces)
                    .HasForeignKey(d => d.IdComputer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workplace_ibfk_1");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.Workplaces)
                    .HasForeignKey(d => d.IdMonitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workplace_ibfk_2");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Workplaces)
                    .HasForeignKey(d => d.IdRoom)
                    .HasConstraintName("workplace_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
