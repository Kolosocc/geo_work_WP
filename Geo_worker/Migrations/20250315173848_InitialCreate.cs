using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo_worker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    ID_AccessLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.ID_AccessLevel);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    ID_CustomerType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.ID_CustomerType);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID_Equipment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID_Equipment);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID_Position = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ID_AccessLevel = table.Column<int>(type: "int", nullable: false),
                    AccessLevelID_AccessLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID_Position);
                    table.ForeignKey(
                        name: "FK_Positions_AccessLevels_AccessLevelID_AccessLevel",
                        column: x => x.AccessLevelID_AccessLevel,
                        principalTable: "AccessLevels",
                        principalColumn: "ID_AccessLevel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID_Customer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Type = table.Column<int>(type: "int", nullable: false),
                    CustomerTypeID_CustomerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID_Customer);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeID_CustomerType",
                        column: x => x.CustomerTypeID_CustomerType,
                        principalTable: "CustomerTypes",
                        principalColumn: "ID_CustomerType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID_Employee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passport = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_Position = table.Column<int>(type: "int", nullable: false),
                    PositionID_Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID_Employee);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID_Position",
                        column: x => x.PositionID_Position,
                        principalTable: "Positions",
                        principalColumn: "ID_Position",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID_Project = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Customer = table.Column<int>(type: "int", nullable: false),
                    CustomerID_Customer = table.Column<int>(type: "int", nullable: false),
                    ID_Employee = table.Column<int>(type: "int", nullable: false),
                    EmployeeID_Employee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID_Project);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerID_Customer",
                        column: x => x.CustomerID_Customer,
                        principalTable: "Customers",
                        principalColumn: "ID_Customer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_EmployeeID_Employee",
                        column: x => x.EmployeeID_Employee,
                        principalTable: "Employees",
                        principalColumn: "ID_Employee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID_Report = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Employee = table.Column<int>(type: "int", nullable: false),
                    ID_Project = table.Column<int>(type: "int", nullable: false),
                    ReportFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID_Report);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_ID_Employee",
                        column: x => x.ID_Employee,
                        principalTable: "Employees",
                        principalColumn: "ID_Employee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Projects_ID_Project",
                        column: x => x.ID_Project,
                        principalTable: "Projects",
                        principalColumn: "ID_Project",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    ID_Square = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alitude = table.Column<int>(type: "int", nullable: false),
                    ID_Project = table.Column<int>(type: "int", nullable: false),
                    ProjectID_Project = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.ID_Square);
                    table.ForeignKey(
                        name: "FK_Squares_Projects_ProjectID_Project",
                        column: x => x.ProjectID_Project,
                        principalTable: "Projects",
                        principalColumn: "ID_Project",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaCoordinates",
                columns: table => new
                {
                    ID_Record = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Square = table.Column<int>(type: "int", nullable: false),
                    SquareID_Square = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCoordinates", x => x.ID_Record);
                    table.ForeignKey(
                        name: "FK_AreaCoordinates_Squares_SquareID_Square",
                        column: x => x.SquareID_Square,
                        principalTable: "Squares",
                        principalColumn: "ID_Square",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID_Profile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Square = table.Column<int>(type: "int", nullable: false),
                    SquareID_Square = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID_Profile);
                    table.ForeignKey(
                        name: "FK_Profiles_Squares_SquareID_Square",
                        column: x => x.SquareID_Square,
                        principalTable: "Squares",
                        principalColumn: "ID_Square",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pickets",
                columns: table => new
                {
                    ID_Picket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Profile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickets", x => x.ID_Picket);
                    table.ForeignKey(
                        name: "FK_Pickets_Profiles_ID_Profile",
                        column: x => x.ID_Profile,
                        principalTable: "Profiles",
                        principalColumn: "ID_Profile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileCoordinates",
                columns: table => new
                {
                    ID_Record = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Profile = table.Column<int>(type: "int", nullable: false),
                    ProfileID_Profile = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileCoordinates", x => x.ID_Record);
                    table.ForeignKey(
                        name: "FK_ProfileCoordinates_Profiles_ProfileID_Profile",
                        column: x => x.ProfileID_Profile,
                        principalTable: "Profiles",
                        principalColumn: "ID_Profile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PicketCoordinates",
                columns: table => new
                {
                    ID_Record = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Picket = table.Column<int>(type: "int", nullable: false),
                    PicketID_Picket = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicketCoordinates", x => x.ID_Record);
                    table.ForeignKey(
                        name: "FK_PicketCoordinates_Pickets_PicketID_Picket",
                        column: x => x.PicketID_Picket,
                        principalTable: "Pickets",
                        principalColumn: "ID_Picket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    ID_Point = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    TransitioAmplitude = table.Column<double>(type: "float", nullable: false),
                    SignalAnomaly = table.Column<double>(type: "float", nullable: false),
                    Amendments = table.Column<double>(type: "float", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Operator = table.Column<int>(type: "int", nullable: false),
                    OperatorID_Employee = table.Column<int>(type: "int", nullable: false),
                    ID_Equipment = table.Column<int>(type: "int", nullable: false),
                    EquipmentID_Equipment = table.Column<int>(type: "int", nullable: false),
                    ID_Picket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.ID_Point);
                    table.ForeignKey(
                        name: "FK_Points_Employees_OperatorID_Employee",
                        column: x => x.OperatorID_Employee,
                        principalTable: "Employees",
                        principalColumn: "ID_Employee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_Equipments_EquipmentID_Equipment",
                        column: x => x.EquipmentID_Equipment,
                        principalTable: "Equipments",
                        principalColumn: "ID_Equipment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_Pickets_ID_Picket",
                        column: x => x.ID_Picket,
                        principalTable: "Pickets",
                        principalColumn: "ID_Picket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaCoordinates_SquareID_Square",
                table: "AreaCoordinates",
                column: "SquareID_Square");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeID_CustomerType",
                table: "Customers",
                column: "CustomerTypeID_CustomerType");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Passport",
                table: "Employees",
                column: "Passport",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID_Position",
                table: "Employees",
                column: "PositionID_Position");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SerialNumber",
                table: "Equipments",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PicketCoordinates_PicketID_Picket",
                table: "PicketCoordinates",
                column: "PicketID_Picket");

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_ID_Profile",
                table: "Pickets",
                column: "ID_Profile");

            migrationBuilder.CreateIndex(
                name: "IX_Points_EquipmentID_Equipment",
                table: "Points",
                column: "EquipmentID_Equipment");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ID_Picket",
                table: "Points",
                column: "ID_Picket");

            migrationBuilder.CreateIndex(
                name: "IX_Points_OperatorID_Employee",
                table: "Points",
                column: "OperatorID_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_AccessLevelID_AccessLevel",
                table: "Positions",
                column: "AccessLevelID_AccessLevel");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCoordinates_ProfileID_Profile",
                table: "ProfileCoordinates",
                column: "ProfileID_Profile");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SquareID_Square",
                table: "Profiles",
                column: "SquareID_Square");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerID_Customer",
                table: "Projects",
                column: "CustomerID_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeID_Employee",
                table: "Projects",
                column: "EmployeeID_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ID_Employee",
                table: "Reports",
                column: "ID_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ID_Project",
                table: "Reports",
                column: "ID_Project");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_ProjectID_Project",
                table: "Squares",
                column: "ProjectID_Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaCoordinates");

            migrationBuilder.DropTable(
                name: "PicketCoordinates");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "ProfileCoordinates");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Pickets");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "AccessLevels");
        }
    }
}
