﻿// <auto-generated />
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20171215145040_TagLabelPk")]
    partial class TagLabelPk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAndTime");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Data.Domain.Entities.Tag", b =>
                {
                    b.Property<string>("Label")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EventId");

                    b.Property<Guid?>("UserId");

                    b.Property<bool>("Verified");

                    b.HasKey("Label");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Data.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Domain.Entities.Tag", b =>
                {
                    b.HasOne("Data.Domain.Entities.Event")
                        .WithMany("Tags")
                        .HasForeignKey("EventId");

                    b.HasOne("Data.Domain.Entities.User")
                        .WithMany("TagsList")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
