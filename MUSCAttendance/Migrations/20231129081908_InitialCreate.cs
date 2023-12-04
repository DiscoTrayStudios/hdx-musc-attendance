﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUSCAttendance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstMidName = table.Column<string>(type: "TEXT", nullable: true),
                    GradYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Performed = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasProgram = table.Column<bool>(type: "INTEGER", nullable: false),
                    OtherDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProgramDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: true),
                    StudentID1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Form_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Form_Student_StudentID1",
                        column: x => x.StudentID1,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Form_StudentID",
                table: "Form",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Form_StudentID1",
                table: "Form",
                column: "StudentID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}