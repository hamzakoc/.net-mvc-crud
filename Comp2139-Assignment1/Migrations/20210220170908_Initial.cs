using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Comp2139_Assignment1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountriesID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountriesID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductsID);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationsID);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechniciansID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechniciansID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountriesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomersID);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountriesID",
                        column: x => x.CountriesID,
                        principalTable: "Countries",
                        principalColumn: "CountriesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsRegistrations",
                columns: table => new
                {
                    ProductsID = table.Column<int>(type: "int", nullable: false),
                    RegistrationsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsRegistrations", x => new { x.ProductsID, x.RegistrationsID });
                    table.ForeignKey(
                        name: "FK_ProductsRegistrations_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ProductsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsRegistrations_Registrations_RegistrationsID",
                        column: x => x.RegistrationsID,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersRegistrations",
                columns: table => new
                {
                    CustomersID = table.Column<int>(type: "int", nullable: false),
                    RegistrationsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersRegistrations", x => new { x.CustomersID, x.RegistrationsID });
                    table.ForeignKey(
                        name: "FK_CustomersRegistrations_Customers_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customers",
                        principalColumn: "CustomersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersRegistrations_Registrations_RegistrationsID",
                        column: x => x.RegistrationsID,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false),
                    TechniciansID = table.Column<int>(type: "int", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentsID);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customers",
                        principalColumn: "CustomersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ProductsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechniciansID",
                        column: x => x.TechniciansID,
                        principalTable: "Technicians",
                        principalColumn: "TechniciansID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Afghanistan",
                    "New Zealand",
                    "Nicaragua",
                    "Niger",
                    "Nigeria",
                    "Niue",
                    "Norfolk Island",
                    "Northern Mariana Islands",
                    "Norway",
                    "Oman",
                    "Pakistan",
                    "Palau",
                    "Palestine, State of",
                    "Panama",
                    "Papua New Guinea",
                    "Paraguay",
                    "Peru",
                    "Philippines",
                    "Pitcairn",
                    "Poland",
                    "Portugal",
                    "Puerto Rico",
                    "Qatar",
                    "Réunion",
                    "Romania",
                    "Russian Federation",
                    "Rwanda",
                    "Saint Barthélemy",
                    "New Caledonia",
                    "Saint Helena, Ascension and Tristan da Cunha",
                    "Netherlands",
                    "Nauru",
                    "Libya",
                    "Liechtenstein",
                    "Lithuania",
                    "Luxembourg",
                    "Macao",
                    "Macedonia, Republic of",
                    "Madagascar",
                    "Malaysia",
                    "Maldives",
                    "Mali"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Malta",
                    "Marshall Islands",
                    "Martinique",
                    "Mauritania",
                    "Mauritius",
                    "Mayotte",
                    "Mexico",
                    "Micronesia, Federated States of",
                    "Moldova",
                    "Monaco",
                    "Mongolia",
                    "Montenegro",
                    "Montserrat",
                    "Morocco",
                    "Mozambique",
                    "Myanmar",
                    "Namibia",
                    "Nepal",
                    "Saint Kitts and Nevis",
                    "Saint Lucia",
                    "Saint Martin",
                    "Togo",
                    "Tokelau",
                    "Tonga",
                    "Trinidad and Tobago",
                    "Tunisia",
                    "Turkey",
                    "Turkmenistan",
                    "Turks and Caicos Islands",
                    "Tuvalu",
                    "Uganda",
                    "Ukraine",
                    "United Arab Emirates",
                    "United Kingdom",
                    "United States",
                    "United States Minor Outlying Islands",
                    "Uruguay",
                    "Uzbekistan",
                    "Vanuatu",
                    "Venezuela, Bolivarian Republic of",
                    "Vietnam",
                    "Virgin Islands, British"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Virgin Islands, U.S.",
                    "Wallis and Futuna",
                    "Western Sahara",
                    "Yemen",
                    "Zambia",
                    "Zimbabwe",
                    "Timor-Leste",
                    "Thailand",
                    "Tanzania, United Republic of",
                    "Tajikistan",
                    "Saint Pierre and Miquelon",
                    "Saint Vincent and the Grenadines",
                    "Samoa",
                    "San Marino",
                    "Sao Tome and Principe",
                    "Saudi Arabia",
                    "Senegal",
                    "Serbia",
                    "Seychelles",
                    "Sierra Leone",
                    "Singapore",
                    "Sint Maarten (Dutch part)",
                    "Slovakia",
                    "Liberia",
                    "Slovenia",
                    "Somalia",
                    "South Africa",
                    "South Georgia and South Sandwich Islands",
                    "South Sudan",
                    "Spain",
                    "Sri Lanka",
                    "Sudan",
                    "Suriname",
                    "Swaziland",
                    "Sweden",
                    "Switzerland",
                    "Syrian Arab Republic",
                    "Taiwan",
                    "Solomon Islands",
                    "Lesotho",
                    "Malawi",
                    "Latvia"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Brunei Darussalam",
                    "Bulgaria",
                    "Burkina Faso",
                    "Burundi",
                    "Cambodia",
                    "Cameroon",
                    "Canada",
                    "Cape Verde",
                    "Cayman Islands",
                    "Central African Republic",
                    "Chad",
                    "Chile",
                    "China",
                    "Christmas Island",
                    "Cocos (Keeling) Islands",
                    "Colombia",
                    "Comoros",
                    "Congo, Republic of the (Brazzaville)",
                    "Congo, the Democratic Republic of the (Kinshasa)",
                    "Lebanon",
                    "Costa Rica",
                    "Côte d'Ivoire, Republic of",
                    "Croatia",
                    "Cuba",
                    "Curaçao",
                    "Cyprus",
                    "Czech Republic",
                    "British Indian Ocean Territory",
                    "Brazil",
                    "Bouvet Island",
                    "Botswana",
                    "Åland Islands",
                    "Albania",
                    "Algeria",
                    "American Samoa",
                    "Andorra",
                    "Angola",
                    "Anguilla",
                    "Antarctica",
                    "Antigua and Barbuda",
                    "Argentina",
                    "Armenia"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Aruba",
                    "Australia",
                    "Denmark",
                    "Austria",
                    "Bahamas",
                    "Bahrain",
                    "Bangladesh",
                    "Barbados",
                    "Belarus",
                    "Belgium",
                    "Belize",
                    "Benin",
                    "Bermuda",
                    "Bhutan",
                    "Bolivia",
                    "Bonaire, Sint Eustatius and Saba",
                    "Bosnia and Herzegovina",
                    "Azerbaijan",
                    "Djibouti",
                    "Cook Islands",
                    "Dominican Republic",
                    "Haiti",
                    "Heard Island and McDonald Islands",
                    "Holy See (Vatican City)",
                    "Honduras",
                    "Hong Kong",
                    "Hungary",
                    "Iceland",
                    "Dominica",
                    "Indonesia",
                    "Iran, Islamic Republic of",
                    "Iraq",
                    "Ireland",
                    "Isle of Man",
                    "Israel",
                    "Italy",
                    "Jamaica",
                    "Japan",
                    "Jersey",
                    "Jordan",
                    "Kazakhstan",
                    "Kenya"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountriesID",
                values: new object[]
                {
                    "Kiribati",
                    "Korea, Democratic People's Republic of",
                    "Korea, Republic of",
                    "Kuwait",
                    "Kyrgyzstan",
                    "Laos",
                    "Guyana",
                    "Guinea-Bissau",
                    "India",
                    "Guernsey",
                    "Ecuador",
                    "Egypt",
                    "El Salvador",
                    "Equatorial Guinea",
                    "Guinea",
                    "Estonia",
                    "Ethiopia",
                    "Falkland Islands (Islas Malvinas)",
                    "Faroe Islands",
                    "Fiji",
                    "Finland",
                    "France",
                    "French Guiana",
                    "Eritrea",
                    "French Southern and Antarctic Lands",
                    "Guatemala",
                    "Guam",
                    "Guadeloupe",
                    "Grenada",
                    "Greenland",
                    "Gibraltar",
                    "Greece",
                    "Ghana",
                    "Germany",
                    "Georgia",
                    "Gambia, The",
                    "Gabon",
                    "French Polynesia"
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomersID", "Address", "City", "CountriesID", "Email", "FName", "LName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 5, null, "Fresno", null, "kmayte@fresno.ca.gov", "Kendall", "Mayte", null, null, null },
                    { 6, null, "Los Angles", null, "kenzie@mmma.jobtrak.com", "Kenzie", "Quinn", null, null, null },
                    { 7, null, "Fresno", null, "marvin@expedata.com", "Marvin", "Quintin", null, null, null },
                    { 3, null, "Mission Viejo", null, " ", "Gonzolo", "Keeton", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomersID", "Address", "City", "CountriesID", "Email", "FName", "LName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 2, null, "Washington", null, "ania@mm.nidc.com", "Ania", "Irvin", null, null, null },
                    { 1, null, "San Francisco", null, "kanthoni@pge.com", "Kaitlyn", "Anthoni", null, null, null },
                    { 4, null, "Sacramento", null, "amauro@yahoo.org", "Anton", "Mauro", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductsID", "Code", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "TRNY10", "Tournament Master 1.0", 4.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "LEAG10", "Leaagur Scheduler 1.0", 4.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "LEAGD10", "Leaagur Scheduler Deluxe1.0", 7.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "DRAFT10", "Draft Manager 1.0", 4.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "TEAM10", "Team Manager 1.0", 4.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "TRNY20", "Tournament Master 2.0", 4.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "DRAFT20", "Tournament Master 1.0", 5.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "TRNY10", "Draft Manager 2.0", 5.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechniciansID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 4, "gunter@sportsprosoftware.com", "Guunter Wendit", "800-555-0400" },
                    { 1, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 2, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 3, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" },
                    { 5, "alison@sportsprosoftware.com", "Jason Lee", "800-555-0444" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentsID", "CustomersID", "DateClosed", "DateOpened", "Description", "ProductsID", "TechniciansID", "Title" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 1, "Could not install" },
                    { 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, "Could not install" },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 3, "Error importing data" },
                    { 4, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, "Error launching program" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountriesID",
                table: "Customers",
                column: "CountriesID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRegistrations_RegistrationsID",
                table: "CustomersRegistrations",
                column: "RegistrationsID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomersID",
                table: "Incidents",
                column: "CustomersID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductsID",
                table: "Incidents",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechniciansID",
                table: "Incidents",
                column: "TechniciansID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsRegistrations_RegistrationsID",
                table: "ProductsRegistrations",
                column: "RegistrationsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersRegistrations");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "ProductsRegistrations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
