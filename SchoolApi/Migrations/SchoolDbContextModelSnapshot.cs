﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApi.Data;

#nullable disable

namespace SchoolApi.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JurusanId")
                        .HasColumnType("int");

                    b.Property<int>("KelasId")
                        .HasColumnType("int");

                    b.Property<string>("nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JurusanId");

                    b.HasIndex("KelasId");

                    b.ToTable("Namas");
                });

            modelBuilder.Entity("SchoolApi.Models.Jurusan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("jurusan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("jurusans");
                });

            modelBuilder.Entity("SchoolApi.Models.Kelas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("kelas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kelas");
                });

            modelBuilder.Entity("Nama", b =>
                {
                    b.HasOne("SchoolApi.Models.Jurusan", "jurusan")
                        .WithMany()
                        .HasForeignKey("JurusanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Models.Kelas", "Kelas")
                        .WithMany()
                        .HasForeignKey("KelasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kelas");

                    b.Navigation("jurusan");
                });
#pragma warning restore 612, 618
        }
    }
}
