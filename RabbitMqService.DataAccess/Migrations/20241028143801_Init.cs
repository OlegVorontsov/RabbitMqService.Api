using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RabbitMqService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditPartEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgreementNumber = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPartEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitPartEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgreementNumber = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitPartEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestEntity_DocumentEntity_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "DocumentEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<long>(type: "bigint", nullable: false),
                    DebitPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreditPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    BankingDate = table.Column<string>(type: "text", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_CreditPartEntity_CreditPartId",
                        column: x => x.CreditPartId,
                        principalTable: "CreditPartEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_DebitPartEntity_DebitPartId",
                        column: x => x.DebitPartId,
                        principalTable: "DebitPartEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_RequestEntity_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreditPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DebitPartEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeEntity_CreditPartEntity_CreditPartEntityId",
                        column: x => x.CreditPartEntityId,
                        principalTable: "CreditPartEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttributeEntity_DebitPartEntity_DebitPartEntityId",
                        column: x => x.DebitPartEntityId,
                        principalTable: "DebitPartEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttributeEntity_Messages_MessageEntityId",
                        column: x => x.MessageEntityId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntity_CreditPartEntityId",
                table: "AttributeEntity",
                column: "CreditPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntity_DebitPartEntityId",
                table: "AttributeEntity",
                column: "DebitPartEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntity_MessageEntityId",
                table: "AttributeEntity",
                column: "MessageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreditPartId",
                table: "Messages",
                column: "CreditPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DebitPartId",
                table: "Messages",
                column: "DebitPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RequestId",
                table: "Messages",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEntity_DocumentId",
                table: "RequestEntity",
                column: "DocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeEntity");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "CreditPartEntity");

            migrationBuilder.DropTable(
                name: "DebitPartEntity");

            migrationBuilder.DropTable(
                name: "RequestEntity");

            migrationBuilder.DropTable(
                name: "DocumentEntity");
        }
    }
}
