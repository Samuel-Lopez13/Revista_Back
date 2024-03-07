using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infraestructure.Persistance;

public class RevistaContext : DbContext
{   
    public RevistaContext(DbContextOptions<RevistaContext> options): base(options) { }
    
    public DbSet<Aprobacion> Aprobaciones { get; set; } = null!;
    public DbSet<Articulo> Articulos { get; set; } = null!;
    public DbSet<ArticuloAprobado> ArticulosAprobados { get; set; } = null!;
    public DbSet<AsignacionRevision> AsignacionesRevision { get; set; } = null!;
    public DbSet<CriterioEvaluacion> CriteriosEvaluacion { get; set; } = null!;
    public DbSet<Estatus> Status { get; set; } = null!;
    public DbSet<Intereses> Intereses { get; set; } = null!;
    public DbSet<Revision> Revisiones { get; set; } = null!;
    public DbSet<Revisor> Revisores { get; set; } = null!;
    public DbSet<Rol> Roles { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Valoracion> Valoraciones { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aprobacion>(entity =>
        {
            entity.HasKey(e => e.Aprobacion_Id);
            entity.Property(e => e.Aprobado).IsRequired();
            
            entity.HasOne(d => d.Articulos)
                .WithMany(p => p.Aprobacions)
                .HasForeignKey(d => d.Articulo_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("articulo-kf_aprobacion");
        });
        
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Articulo_Id);
            entity.Property(e => e.Titulo).IsRequired();
            entity.Property(e => e.Fecha).IsRequired();
            entity.Property(e => e.Archivo).IsRequired();
            
            entity.HasOne(d => d.Usuarios)
                .WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Usuario_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuario-kf_articulo");
            
            entity.HasOne(d => d.Interes)
                .WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Intereses_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("interes-kf_articulo");
            
            entity.HasOne(d => d.status)
                .WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Estatus_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("estatus-kf_articulo");
        });
        
        modelBuilder.Entity<ArticuloAprobado>(entity =>
        {
            entity.HasKey(e => e.ArticuloAprobado_Id);
            
            entity.HasOne(d => d.Articulos)
                .WithMany(p => p.ArticuloAprobados)
                .HasForeignKey(d => d.Articulo_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("articulo-kf_articuloA");
        });
        
        modelBuilder.Entity<AsignacionRevision>(entity =>
        {
            entity.HasKey(e => e.AsignacionRevision_Id);
            
            entity.HasOne(d => d.Revisors)
                .WithMany(p => p.AsignacionRevisions)
                .HasForeignKey(d => d.Revisor_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("revisor-kf_asignacionR");
            
            entity.HasOne(d => d.Articulos)
                .WithMany(p => p.AsignacionRevisions)
                .HasForeignKey(d => d.Articulo_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("articulo-kf_asignacionR");
        });
        
        modelBuilder.Entity<CriterioEvaluacion>(entity =>
        {
            entity.HasKey(e => e.CriterioEvaluacion_Id);
        });
        
        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.Estatus_Id);
            entity.Property(e => e.Descripcion).IsRequired();
        });
        
        modelBuilder.Entity<Intereses>(entity =>
        {
            entity.HasKey(e => e.Intereses_Id);
            entity.Property(e => e.Descripcion).IsRequired();
        });
        
        modelBuilder.Entity<Revision>(entity =>
        {
            entity.HasKey(e => e.Revision_Id);
            
            entity.HasOne(d => d.AsignacionRevisiones)
                .WithMany(p => p.Revisiones)
                .HasForeignKey(d => d.AsignacionRevision_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("asignacion-kf_Revision");
            
            entity.HasOne(d => d.Valoraciones)
                .WithMany(p => p.Revisiones)
                .HasForeignKey(d => d.Valoracion_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("valoracion-kf_Revision");
            
            entity.HasOne(d => d.Criterios)
                .WithMany(p => p.Revisiones)
                .HasForeignKey(d => d.CriteriosEvaluacion_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("criterios-kf_Revision");
        });
        
        modelBuilder.Entity<Revisor>(entity =>
        {
            entity.HasKey(e => e.Revisor_Id);
            entity.Property(e => e.Curriculum).IsRequired();
            
            entity.HasOne(d => d.Usuarios)
                .WithMany(p => p.Revisors)
                .HasForeignKey(d => d.Usuario_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("usuario-kf_Revisor");
            
            entity.HasOne(d => d.Intereses)
                .WithMany(p => p.Revisors)
                .HasForeignKey(d => d.Intereses_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("interes-kf_Revisor");
        });
        
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Rol_Id);
            entity.Property(e => e.Descripcion).IsRequired();
        });
        
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuario_Id);
            entity.Property(e => e.Nombre).IsRequired();
            entity.Property(e => e.Correo).IsRequired();
            entity.HasIndex(e => e.Correo).IsUnique();
            entity.Property(e => e.Contrasena).IsRequired();
            entity.Property(e => e.Pais).IsRequired();
            entity.Property(e => e.Afiliacion).IsRequired();
            
            entity.HasOne(d => d.Roles)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("rol-kf_Usuario");
        });
        
        modelBuilder.Entity<Valoracion>(entity =>
        {
            entity.HasKey(e => e.Valoracion_Id);
            entity.Property(e => e.Descripcion).IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }
}