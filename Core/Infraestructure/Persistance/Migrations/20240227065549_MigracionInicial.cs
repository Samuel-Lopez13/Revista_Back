using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CriteriosEvaluacion",
                columns: table => new
                {
                    CriterioEvaluacion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Originalidad = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    Novedad = table.Column<string>(type: "longtext", nullable: false),
                    Innovacion = table.Column<string>(type: "longtext", nullable: false),
                    Relevancia = table.Column<string>(type: "longtext", nullable: false),
                    Pertinencia = table.Column<string>(type: "longtext", nullable: false),
                    Transcendencia = table.Column<string>(type: "longtext", nullable: false),
                    Calidad = table.Column<string>(type: "longtext", nullable: false),
                    Presentacion = table.Column<string>(type: "longtext", nullable: false),
                    Comentario = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriosEvaluacion", x => x.CriterioEvaluacion_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Intereses",
                columns: table => new
                {
                    Intereses_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intereses", x => x.Intereses_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Rol_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Estatus_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Estatus_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    Valoracion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => x.Valoracion_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contrasena = table.Column<string>(type: "longtext", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false),
                    Afiliacion = table.Column<string>(type: "longtext", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Usuario_Id);
                    table.ForeignKey(
                        name: "rol-kf_Usuario",
                        column: x => x.Rol_Id,
                        principalTable: "Roles",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Articulo_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Fecha = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Archivo = table.Column<string>(type: "longtext", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: true),
                    Intereses_Id = table.Column<int>(type: "int", nullable: true),
                    Estatus_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Articulo_Id);
                    table.ForeignKey(
                        name: "estatus-kf_articulo",
                        column: x => x.Estatus_Id,
                        principalTable: "Status",
                        principalColumn: "Estatus_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "interes-kf_articulo",
                        column: x => x.Intereses_Id,
                        principalTable: "Intereses",
                        principalColumn: "Intereses_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "usuario-kf_articulo",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Revisores",
                columns: table => new
                {
                    Revisor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Curriculum = table.Column<string>(type: "longtext", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Intereses_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisores", x => x.Revisor_Id);
                    table.ForeignKey(
                        name: "interes-kf_Revisor",
                        column: x => x.Intereses_Id,
                        principalTable: "Intereses",
                        principalColumn: "Intereses_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "usuario-kf_Revisor",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aprobaciones",
                columns: table => new
                {
                    Aprobacion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Aprobado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Articulo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprobaciones", x => x.Aprobacion_Id);
                    table.ForeignKey(
                        name: "articulo-kf_aprobacion",
                        column: x => x.Articulo_Id,
                        principalTable: "Articulos",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArticulosAprobados",
                columns: table => new
                {
                    ArticuloAprobado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Constancia = table.Column<string>(type: "longtext", nullable: true),
                    Articulo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosAprobados", x => x.ArticuloAprobado_Id);
                    table.ForeignKey(
                        name: "articulo-kf_articuloA",
                        column: x => x.Articulo_Id,
                        principalTable: "Articulos",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignacionesRevision",
                columns: table => new
                {
                    AsignacionRevision_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Revisor_Id = table.Column<int>(type: "int", nullable: false),
                    Articulo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesRevision", x => x.AsignacionRevision_Id);
                    table.ForeignKey(
                        name: "articulo-kf_asignacionR",
                        column: x => x.Articulo_Id,
                        principalTable: "Articulos",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "revisor-kf_asignacionR",
                        column: x => x.Revisor_Id,
                        principalTable: "Revisores",
                        principalColumn: "Revisor_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Revisiones",
                columns: table => new
                {
                    Revision_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaRevision = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ConstanciaRevision = table.Column<string>(type: "longtext", nullable: false),
                    AsignacionRevision_Id = table.Column<int>(type: "int", nullable: true),
                    Valoracion_Id = table.Column<int>(type: "int", nullable: true),
                    CriteriosEvaluacion_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisiones", x => x.Revision_Id);
                    table.ForeignKey(
                        name: "asignacion-kf_Revision",
                        column: x => x.AsignacionRevision_Id,
                        principalTable: "AsignacionesRevision",
                        principalColumn: "AsignacionRevision_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "criterios-kf_Revision",
                        column: x => x.CriteriosEvaluacion_Id,
                        principalTable: "CriteriosEvaluacion",
                        principalColumn: "CriterioEvaluacion_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "valoracion-kf_Revision",
                        column: x => x.Valoracion_Id,
                        principalTable: "Valoraciones",
                        principalColumn: "Valoracion_Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aprobaciones_Articulo_Id",
                table: "Aprobaciones",
                column: "Articulo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Estatus_Id",
                table: "Articulos",
                column: "Estatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Intereses_Id",
                table: "Articulos",
                column: "Intereses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Usuario_Id",
                table: "Articulos",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosAprobados_Articulo_Id",
                table: "ArticulosAprobados",
                column: "Articulo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRevision_Articulo_Id",
                table: "AsignacionesRevision",
                column: "Articulo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRevision_Revisor_Id",
                table: "AsignacionesRevision",
                column: "Revisor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_AsignacionRevision_Id",
                table: "Revisiones",
                column: "AsignacionRevision_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_CriteriosEvaluacion_Id",
                table: "Revisiones",
                column: "CriteriosEvaluacion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_Valoracion_Id",
                table: "Revisiones",
                column: "Valoracion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revisores_Intereses_Id",
                table: "Revisores",
                column: "Intereses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revisores_Usuario_Id",
                table: "Revisores",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Rol_Id",
                table: "Usuarios",
                column: "Rol_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aprobaciones");

            migrationBuilder.DropTable(
                name: "ArticulosAprobados");

            migrationBuilder.DropTable(
                name: "Revisiones");

            migrationBuilder.DropTable(
                name: "AsignacionesRevision");

            migrationBuilder.DropTable(
                name: "CriteriosEvaluacion");

            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Revisores");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Intereses");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
