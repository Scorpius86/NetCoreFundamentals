using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Galaxy.EF.Client.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Clave = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Contenido = table.Column<string>(unicode: false, nullable: true),
                    UsuarioIdPropietario = table.Column<int>(nullable: false),
                    UsuarioIdCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UsuarioIdActualizacion = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SysStartTime = table.Column<DateTime>(nullable: false),
                    SysEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostUsuarioActualizacion",
                        column: x => x.UsuarioIdActualizacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostUsuarioCreacion",
                        column: x => x.UsuarioIdCreacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostUsuarioPropietario",
                        column: x => x.UsuarioIdPropietario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    Contenido = table.Column<string>(unicode: false, nullable: true),
                    UsuarioIdPropietario = table.Column<int>(nullable: false),
                    UsuarioIdCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UsuarioIdActualizacion = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SysStartTime = table.Column<DateTime>(nullable: false),
                    SysEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_ComentarioPost",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioActualizacion",
                        column: x => x.UsuarioIdActualizacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioCreacion",
                        column: x => x.UsuarioIdCreacion,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioPropietario",
                        column: x => x.UsuarioIdPropietario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdActualizacion",
                table: "Comentario",
                column: "UsuarioIdActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdCreacion",
                table: "Comentario",
                column: "UsuarioIdCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdPropietario",
                table: "Comentario",
                column: "UsuarioIdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdActualizacion",
                table: "Post",
                column: "UsuarioIdActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdCreacion",
                table: "Post",
                column: "UsuarioIdCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdPropietario",
                table: "Post",
                column: "UsuarioIdPropietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
