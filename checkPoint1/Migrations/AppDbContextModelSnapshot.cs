﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using checkPoint1.Data;

#nullable disable

namespace checkPoint1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("checkPoint1.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("Id");

                    b.ToTable("TB_PACIENTE_CP");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "123456789",
                            DataNascimento = new DateTime(2024, 10, 3, 22, 53, 20, 796, DateTimeKind.Local).AddTicks(8127),
                            Endereco = "endereço inicial",
                            NomeCompleto = "Paciente Inicial",
                            Telefone = "123456789"
                        });
                });

            modelBuilder.Entity("checkPoint1.Models.PacientePlanoSaude", b =>
                {
                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PlanoSaudeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PacienteId", "PlanoSaudeId");

                    b.HasIndex("PlanoSaudeId");

                    b.ToTable("TB_PACIENTE_PLANO_CP");

                    b.HasData(
                        new
                        {
                            PacienteId = 1,
                            PlanoSaudeId = 1
                        });
                });

            modelBuilder.Entity("checkPoint1.Models.PlanoSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cobertura")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("NomePlano")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("TB_PLANO_SAUDE_CP");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cobertura = "Cobertura Inicial",
                            NomePlano = "Plano Inicial"
                        });
                });

            modelBuilder.Entity("checkPoint1.Models.PacientePlanoSaude", b =>
                {
                    b.HasOne("checkPoint1.Models.Paciente", "Paciente")
                        .WithMany("PacientePlanosSaude")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("checkPoint1.Models.PlanoSaude", "PlanoSaude")
                        .WithMany("PacientePlanosSaude")
                        .HasForeignKey("PlanoSaudeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("PlanoSaude");
                });

            modelBuilder.Entity("checkPoint1.Models.PlanoSaude", b =>
                {
                    b.HasOne("checkPoint1.Models.Paciente", null)
                        .WithMany("PlanosSaude")
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("checkPoint1.Models.Paciente", b =>
                {
                    b.Navigation("PacientePlanosSaude");

                    b.Navigation("PlanosSaude");
                });

            modelBuilder.Entity("checkPoint1.Models.PlanoSaude", b =>
                {
                    b.Navigation("PacientePlanosSaude");
                });
#pragma warning restore 612, 618
        }
    }
}
