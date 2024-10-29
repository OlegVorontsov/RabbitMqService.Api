﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RabbitMqService.DataAccess;

#nullable disable

namespace RabbitMqService.DataAccess.Migrations
{
    [DbContext(typeof(MessageDbContext))]
    partial class MessageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.CreditPartAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreditPartId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreditPartId");

                    b.ToTable("CreditPartAttributes");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.CreditPartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgreementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("CreditParts");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DebitPartAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DebitPartId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DebitPartId");

                    b.ToTable("DebitPartAttributes");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DebitPartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgreementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("DebitParts");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DocumentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.MessageAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageAttributes");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BankingDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.RequestEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.CreditPartAttributeEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.CreditPartEntity", "CreditPart")
                        .WithMany("Attributes")
                        .HasForeignKey("CreditPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditPart");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.CreditPartEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.MessageEntity", "Message")
                        .WithOne("CreditPart")
                        .HasForeignKey("RabbitMqService.DataAccess.Entities.CreditPartEntity", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DebitPartAttributeEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.DebitPartEntity", "DebitPart")
                        .WithMany("Attributes")
                        .HasForeignKey("DebitPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DebitPart");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DebitPartEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.MessageEntity", "Message")
                        .WithOne("DebitPart")
                        .HasForeignKey("RabbitMqService.DataAccess.Entities.DebitPartEntity", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DocumentEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.RequestEntity", "Request")
                        .WithOne("Document")
                        .HasForeignKey("RabbitMqService.DataAccess.Entities.DocumentEntity", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.MessageAttributeEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.MessageEntity", "Message")
                        .WithMany("Attributes")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.RequestEntity", b =>
                {
                    b.HasOne("RabbitMqService.DataAccess.Entities.MessageEntity", "Message")
                        .WithOne("Request")
                        .HasForeignKey("RabbitMqService.DataAccess.Entities.RequestEntity", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.CreditPartEntity", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.DebitPartEntity", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.MessageEntity", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("CreditPart")
                        .IsRequired();

                    b.Navigation("DebitPart")
                        .IsRequired();

                    b.Navigation("Request")
                        .IsRequired();
                });

            modelBuilder.Entity("RabbitMqService.DataAccess.Entities.RequestEntity", b =>
                {
                    b.Navigation("Document")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
