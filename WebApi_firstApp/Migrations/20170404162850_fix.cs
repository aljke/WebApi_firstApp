using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_firstApp.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AuthorTodo_AuthorId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorTodo",
                table: "AuthorTodo");

            migrationBuilder.RenameTable(
                name: "AuthorTodo",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Authors_AuthorId",
                table: "TodoItems",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Authors_AuthorId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "AuthorTodo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorTodo",
                table: "AuthorTodo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AuthorTodo_AuthorId",
                table: "TodoItems",
                column: "AuthorId",
                principalTable: "AuthorTodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
