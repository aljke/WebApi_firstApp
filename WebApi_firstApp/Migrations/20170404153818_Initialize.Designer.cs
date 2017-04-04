using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi_firstApp.Models;

namespace WebApi_firstApp.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20170404153818_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi_firstApp.Models.AuthorTodo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AuthorTodo");
                });

            modelBuilder.Entity("WebApi_firstApp.Models.TodoItem", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AuthorId");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Key");

                    b.HasIndex("AuthorId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("WebApi_firstApp.Models.TodoItem", b =>
                {
                    b.HasOne("WebApi_firstApp.Models.AuthorTodo", "Author")
                        .WithMany("Todoes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
