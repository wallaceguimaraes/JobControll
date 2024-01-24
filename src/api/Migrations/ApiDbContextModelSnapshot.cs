﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data.Context;

namespace api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Models.EntityModel.Jobs.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Descricao");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimaAtualizacao");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.Property<string>("Title")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Titulo");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Tarefa", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Descricao");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimaAtualizacao");

                    b.Property<string>("Title")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Projeto", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Times.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataFim");

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("IdTarefa");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicio");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Tempo", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.UserProjects.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioProjeto", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimaAtualizacao");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Nome");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Senha");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Salt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Login");

                    b.ToTable("Usuario", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.WorkedTimes.WorkedTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Days")
                        .HasColumnType("int")
                        .HasColumnName("Dias");

                    b.Property<decimal?>("Hours")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Horas");

                    b.Property<int?>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("IdTarefa");

                    b.Property<int?>("Months")
                        .HasColumnType("int")
                        .HasColumnName("Meses");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("IdProjeto");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique()
                        .HasFilter("[IdTarefa] IS NOT NULL");

                    b.HasIndex("ProjectId")
                        .IsUnique()
                        .HasFilter("[IdProjeto] IS NOT NULL");

                    b.ToTable("TempoTrabalhado", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Jobs.Job", b =>
                {
                    b.HasOne("api.Models.EntityModel.Projects.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Models.EntityModel.Users.User", "User")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.EntityModel.Times.Time", b =>
                {
                    b.HasOne("api.Models.EntityModel.Jobs.Job", "Job")
                        .WithMany("Times")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("api.Models.EntityModel.UserProjects.UserProject", b =>
                {
                    b.HasOne("api.Models.EntityModel.Projects.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.EntityModel.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.EntityModel.WorkedTimes.WorkedTime", b =>
                {
                    b.HasOne("api.Models.EntityModel.Jobs.Job", "Job")
                        .WithOne("WorkedTime")
                        .HasForeignKey("api.Models.EntityModel.WorkedTimes.WorkedTime", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.EntityModel.Projects.Project", "Project")
                        .WithOne("WorkedTime")
                        .HasForeignKey("api.Models.EntityModel.WorkedTimes.WorkedTime", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("api.Models.EntityModel.Jobs.Job", b =>
                {
                    b.Navigation("Times");

                    b.Navigation("WorkedTime");
                });

            modelBuilder.Entity("api.Models.EntityModel.Projects.Project", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("UserProjects");

                    b.Navigation("WorkedTime");
                });

            modelBuilder.Entity("api.Models.EntityModel.Users.User", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
