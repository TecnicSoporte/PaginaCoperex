using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaginaWebCoperex.Models;

public partial class PaginaWebContext : DbContext
{
    public PaginaWebContext()
    {
    }

    public PaginaWebContext(DbContextOptions<PaginaWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AjusteArrendamiento> AjusteArrendamiento { get; set; }

    public virtual DbSet<AjusteCotizacion> AjusteCotizacion { get; set; }

    public virtual DbSet<AreaTarifario> AreaTarifario { get; set; }

    public virtual DbSet<Areas> Areas { get; set; }

    public virtual DbSet<AreasCaracteristicas> AreasCaracteristicas { get; set; }

    public virtual DbSet<Arrendamiento> Arrendamiento { get; set; }

    public virtual DbSet<Caracteristicas> Caracteristicas { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<CodigoPais> CodigoPais { get; set; }

    public virtual DbSet<Cotizacion> Cotizacion { get; set; }

    public virtual DbSet<CotizacionArea> CotizacionArea { get; set; }

    public virtual DbSet<CotizacionServicio> CotizacionServicio { get; set; }

    public virtual DbSet<DepartamentoSeccion> DepartamentoSeccion { get; set; }

    public virtual DbSet<DepartamentoTrabajo> DepartamentoTrabajo { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<DocumentoLaip> DocumentoLaip { get; set; }

    public virtual DbSet<DocumentoMemoria> DocumentoMemoria { get; set; }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<Eventos> Eventos { get; set; }

    public virtual DbSet<EventosImagenes> EventosImagenes { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<FacturaPago> FacturaPago { get; set; }

    public virtual DbSet<HistorialCotizacion> HistorialCotizacion { get; set; }

    public virtual DbSet<HistorialPostulacion> HistorialPostulacion { get; set; }

    public virtual DbSet<Imagenes> Imagenes { get; set; }

    public virtual DbSet<MemoriaLaboral> MemoriaLaboral { get; set; }

    public virtual DbSet<NumeralLaip> NumeralLaip { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<PlazaTrabajo> PlazaTrabajo { get; set; }

    public virtual DbSet<Postulacion> Postulacion { get; set; }

    public virtual DbSet<Requisitos> Requisitos { get; set; }

    public virtual DbSet<RequisitosPlaza> RequisitosPlaza { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Secciones> Secciones { get; set; }

    public virtual DbSet<ServicioAdicional> ServicioAdicional { get; set; }

    public virtual DbSet<Tarifario> Tarifario { get; set; }

    public virtual DbSet<Telefono> Telefono { get; set; }

    public virtual DbSet<TipoAjuste> TipoAjuste { get; set; }

    public virtual DbSet<TipoContrato> TipoContrato { get; set; }

    public virtual DbSet<TipoEvento> TipoEvento { get; set; }

    public virtual DbSet<TipoPago> TipoPago { get; set; }

    public virtual DbSet<TransaccionPago> TransaccionPago { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AjusteArrendamiento>(entity =>
        {
            entity.HasKey(e => e.AjusteArrendamientoId).HasName("PK__AjusteAr__5EAC4BE99AEF2AF2");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoCalculado).HasMaxLength(20);
            entity.Property(e => e.Motivo).HasMaxLength(500);
            entity.Property(e => e.TipoCalculo).HasMaxLength(20);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Arrendamiento).WithMany(p => p.AjusteArrendamiento)
                .HasForeignKey(d => d.ArrendamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AjusteArr_Arrendamiento");

            entity.HasOne(d => d.TipoAjuste).WithMany(p => p.AjusteArrendamiento)
                .HasForeignKey(d => d.TipoAjusteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AjusteArr_TipoAjuste");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.AjusteArrendamiento)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_AjusteArr_Usuario");
        });

        modelBuilder.Entity<AjusteCotizacion>(entity =>
        {
            entity.HasKey(e => e.AjusteCotizacionId).HasName("PK__AjusteCo__DEF8018E2A6B1C14");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoCalculado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Motivo).HasMaxLength(500);
            entity.Property(e => e.TipoCalculo).HasMaxLength(20);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.AjusteCotizacion)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AjusteCot_Cotizacion");

            entity.HasOne(d => d.TipoAjuste).WithMany(p => p.AjusteCotizacion)
                .HasForeignKey(d => d.TipoAjusteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AjusteCot_TipoAjuste");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.AjusteCotizacion)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_AjusteCot_Usuario");
        });

        modelBuilder.Entity<AreaTarifario>(entity =>
        {
            entity.HasKey(e => e.AreaTarifarioId).HasName("PK__AreaTari__8579B91C6D364EC8");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.AreaTarifario)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaTarifario_Area");

            entity.HasOne(d => d.IdTarifarioNavigation).WithMany(p => p.AreaTarifario)
                .HasForeignKey(d => d.IdTarifario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaTarifario_Tarifario");
        });

        modelBuilder.Entity<Areas>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82048151AE33C");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Author).HasMaxLength(150);
            entity.Property(e => e.EstiloArquitectura).HasMaxLength(150);
            entity.Property(e => e.NombreArea).HasMaxLength(150);
            entity.Property(e => e.NumeroRegistro).HasMaxLength(25);

            entity.HasOne(d => d.Caracteristicas).WithMany(p => p.Areas)
                .HasForeignKey(d => d.CaracteristicasId)
                .HasConstraintName("FK_Areas_Caracteristicas");
        });

        modelBuilder.Entity<AreasCaracteristicas>(entity =>
        {
            entity.HasKey(e => e.AreasCaracteristicasId).HasName("PK__AreasCar__45AA688A532651E6");

            entity.HasOne(d => d.IdAreasNavigation).WithMany(p => p.AreasCaracteristicas)
                .HasForeignKey(d => d.IdAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreasCaract_Area");

            entity.HasOne(d => d.IdCaracteristicasNavigation).WithMany(p => p.AreasCaracteristicas)
                .HasForeignKey(d => d.IdCaracteristicas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreasCaract_Carac");
        });

        modelBuilder.Entity<Arrendamiento>(entity =>
        {
            entity.HasKey(e => e.ArrendamientoId).HasName("PK__Arrendam__F78B3AD2AD22EE86");

            entity.Property(e => e.FechaContrato)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinEvento).HasColumnType("datetime");
            entity.Property(e => e.FechaFinPremontaje).HasColumnType("datetime");
            entity.Property(e => e.FechaInicioEvento).HasColumnType("datetime");
            entity.Property(e => e.FechaInicioPremontaje).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MontoArrendamiento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoIVA");
            entity.Property(e => e.MontoNeto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroContrato).HasMaxLength(50);
            entity.Property(e => e.PorcentajeIva)
                .HasDefaultValue(12.00m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PorcentajeIVA");
            entity.Property(e => e.SubtotalServicios).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDescuentos).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRecargos).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.Arrendamiento)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Arrendamiento_Cotizacion");

            entity.HasOne(d => d.Estado).WithMany(p => p.Arrendamiento)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Arrendamiento_Estado");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.ArrendamientoUsuarioCreacionNavigation)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Arrendamiento_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioModificacionNavigation).WithMany(p => p.ArrendamientoUsuarioModificacionNavigation)
                .HasForeignKey(d => d.UsuarioModificacion)
                .HasConstraintName("FK_Arrendamiento_UsuarioModificacion");
        });

        modelBuilder.Entity<Caracteristicas>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristicas).HasName("PK__Caracter__91D70EB62ECF19C2");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Icono).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E59C3B5C33");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreCategoria).HasMaxLength(300);
        });

        modelBuilder.Entity<CodigoPais>(entity =>
        {
            entity.HasKey(e => e.CodigoPaisId).HasName("PK__CodigoPa__19462DE31D19DF5D");

            entity.Property(e => e.CodigoDePais).HasMaxLength(10);
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.CotizacionId).HasName("PK__Cotizaci__30443A79C84797B5");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEventoFin).HasColumnType("datetime");
            entity.Property(e => e.FechaEventoInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaFinPremontaje).HasColumnType("datetime");
            entity.Property(e => e.FechaInicioPremontaje).HasColumnType("datetime");
            entity.Property(e => e.FechaRespuesta).HasColumnType("datetime");
            entity.Property(e => e.MontoEstimado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nit)
                .HasMaxLength(10)
                .HasColumnName("NIT");
            entity.Property(e => e.NombreEmpresa).HasMaxLength(256);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Cotizacion)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cotizacion_Estado");

            entity.HasOne(d => d.NombreSolicitanteNavigation).WithMany(p => p.CotizacionNombreSolicitanteNavigation)
                .HasForeignKey(d => d.NombreSolicitante)
                .HasConstraintName("FK_Cotizacion_Solicitante");

            entity.HasOne(d => d.TipoEventoNavigation).WithMany(p => p.Cotizacion)
                .HasForeignKey(d => d.TipoEvento)
                .HasConstraintName("FK_Cotizacion_TipoEvento");

            entity.HasOne(d => d.UsuarioRevisorNavigation).WithMany(p => p.CotizacionUsuarioRevisorNavigation)
                .HasForeignKey(d => d.UsuarioRevisor)
                .HasConstraintName("FK_Cotizacion_Revisor");
        });

        modelBuilder.Entity<CotizacionArea>(entity =>
        {
            entity.HasKey(e => e.CotizacionAreaId).HasName("PK__Cotizaci__213B48CA67B07269");

            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.Area).WithMany(p => p.CotizacionArea)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CotizacionArea_Area");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.CotizacionArea)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CotizacionArea_Cotizacion");

            entity.HasOne(d => d.IdTarifarioNavigation).WithMany(p => p.CotizacionArea)
                .HasForeignKey(d => d.IdTarifario)
                .HasConstraintName("FK_CotizacionArea_Tarifario");
        });

        modelBuilder.Entity<CotizacionServicio>(entity =>
        {
            entity.HasKey(e => e.CotizacionServicioId).HasName("PK__Cotizaci__E5CD7903AC39AA0C");

            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.Observaciones).HasMaxLength(300);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.CotizacionServicio)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CotizacionServicio_Cotizacion");

            entity.HasOne(d => d.ServicioAdicional).WithMany(p => p.CotizacionServicio)
                .HasForeignKey(d => d.ServicioAdicionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CotizacionServicio_Servicio");
        });

        modelBuilder.Entity<DepartamentoSeccion>(entity =>
        {
            entity.HasKey(e => e.DepartamentoSeccionId).HasName("PK__Departam__CF8D04BDD1B30C5D");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.DepartamentoSeccion)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepSeccion_Departamento");

            entity.HasOne(d => d.IdSeccion).WithMany(p => p.DepartamentoSeccion)
                .HasForeignKey(d => d.IdSeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepSeccion_Seccion");
        });

        modelBuilder.Entity<DepartamentoTrabajo>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E3E14E9302A");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreDepartamento).HasMaxLength(100);
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleFacturaId).HasName("PK__DetalleF__2318ABF5441482B5");

            entity.Property(e => e.Cantidad)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.MontoIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoIVA");
            entity.Property(e => e.PorcentajeIva)
                .HasDefaultValue(12.00m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PorcentajeIVA");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura");
        });

        modelBuilder.Entity<DocumentoLaip>(entity =>
        {
            entity.HasKey(e => e.DocumentoLaipid).HasName("PK__Document__CF99E7F88ABB4D32");

            entity.ToTable("DocumentoLAIP");

            entity.Property(e => e.DocumentoLaipid).HasColumnName("DocumentoLAIPId");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdnumeralLaip).HasColumnName("IDNumeralLAIP");
            entity.Property(e => e.Titulo).HasMaxLength(300);
            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.IdnumeralLaipNavigation).WithMany(p => p.DocumentoLaip)
                .HasForeignKey(d => d.IdnumeralLaip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentoLAIP_Numeral");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.DocumentoLaip)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_DocumentoLAIP_Usuario");
        });

        modelBuilder.Entity<DocumentoMemoria>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC7675AED4FC");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Titulo).HasMaxLength(300);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("URL");

            entity.HasOne(d => d.MemoriaLaboral).WithMany(p => p.DocumentoMemoria)
                .HasForeignKey(d => d.MemoriaLaboralId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentoMemoria_Memoria");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.DocumentoMemoria)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_DocumentoMemoria_Usuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B0066A973EC");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DescripcionEstado).HasMaxLength(500);
            entity.Property(e => e.NombreEstado).HasMaxLength(300);
        });

        modelBuilder.Entity<Eventos>(entity =>
        {
            entity.HasKey(e => e.EventosId).HasName("PK__Eventos__4D4BA4D1614A7B42");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DescripcionEvento).HasMaxLength(250);
            entity.Property(e => e.NombreEvento).HasMaxLength(250);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Eventos_Usuario");
        });

        modelBuilder.Entity<EventosImagenes>(entity =>
        {
            entity.HasKey(e => e.EventosImagenesId).HasName("PK__EventosI__E34FA7CF00EEC9DE");

            entity.Property(e => e.EventosImagenesId).HasColumnName("EventosImagenesID");

            entity.HasOne(d => d.Evento).WithMany(p => p.EventosImagenes)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventosImagenes_Evento");

            entity.HasOne(d => d.Imagen).WithMany(p => p.EventosImagenes)
                .HasForeignKey(d => d.ImagenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventosImagenes_Imagen");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C024865562141B7");

            entity.Property(e => e.DireccionEmisor).HasMaxLength(500);
            entity.Property(e => e.DireccionReceptor).HasMaxLength(500);
            entity.Property(e => e.EstadoFel)
                .HasMaxLength(20)
                .HasColumnName("EstadoFEL");
            entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCertificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.MontoIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoIVA");
            entity.Property(e => e.MotivoAnulacion).HasMaxLength(500);
            entity.Property(e => e.Nitemisor)
                .HasMaxLength(20)
                .HasColumnName("NITEmisor");
            entity.Property(e => e.Nitreceptor)
                .HasMaxLength(256)
                .HasColumnName("NITReceptor");
            entity.Property(e => e.NombreEmisor).HasMaxLength(256);
            entity.Property(e => e.NomineReceptor).HasMaxLength(256);
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.SerieFactura).HasMaxLength(50);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UuidFel)
                .HasMaxLength(100)
                .HasColumnName("UUID_FEL");
            entity.Property(e => e.XmlFel).HasColumnName("XmlFEL");

            entity.HasOne(d => d.Arrendamiento).WithMany(p => p.Factura)
                .HasForeignKey(d => d.ArrendamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Arrendamiento");

            entity.HasOne(d => d.Pago).WithMany(p => p.Factura)
                .HasForeignKey(d => d.PagoId)
                .HasConstraintName("FK_Factura_Pago");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Factura)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Factura_Usuario");
        });

        modelBuilder.Entity<FacturaPago>(entity =>
        {
            entity.HasKey(e => e.FacturaPagoId).HasName("PK__FacturaP__87125331F695CF71");

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaPago)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaPago_Factura");

            entity.HasOne(d => d.Pago).WithMany(p => p.FacturaPago)
                .HasForeignKey(d => d.PagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaPago_Pago");
        });

        modelBuilder.Entity<HistorialCotizacion>(entity =>
        {
            entity.HasKey(e => e.HistorialCotizacionId).HasName("PK__Historia__1BFCFC25B3F1DCB5");

            entity.Property(e => e.CampoTipo).HasMaxLength(100);
            entity.Property(e => e.FechaAccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.HistorialCotizacion)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistCotizacion_Cotizacion");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialCotizacion)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistCotizacion_Usuario");
        });

        modelBuilder.Entity<HistorialPostulacion>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__9752068F14B84D57");

            entity.Property(e => e.FechaAccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.EstadoAnteriorNavigation).WithMany(p => p.HistorialPostulacionEstadoAnteriorNavigation)
                .HasForeignKey(d => d.EstadoAnterior)
                .HasConstraintName("FK_HistPostulacion_EstAnt");

            entity.HasOne(d => d.EstadoNuevoNavigation).WithMany(p => p.HistorialPostulacionEstadoNuevoNavigation)
                .HasForeignKey(d => d.EstadoNuevo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistPostulacion_EstNuevo");

            entity.HasOne(d => d.PlazaTrabajoNavigation).WithMany(p => p.HistorialPostulacion)
                .HasForeignKey(d => d.PlazaTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistPostulacion_Plaza");

            entity.HasOne(d => d.Postulacion).WithMany(p => p.HistorialPostulacion)
                .HasForeignKey(d => d.PostulacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistPostulacion_Postulacion");

            entity.HasOne(d => d.UsuarioAccionNavigation).WithMany(p => p.HistorialPostulacion)
                .HasForeignKey(d => d.UsuarioAccion)
                .HasConstraintName("FK_HistPostulacion_Usuario");
        });

        modelBuilder.Entity<Imagenes>(entity =>
        {
            entity.HasKey(e => e.ImagenesId).HasName("PK__Imagenes__B628C0715BEAD231");

            entity.Property(e => e.Icono).HasMaxLength(250);
            entity.Property(e => e.Imagen).HasMaxLength(500);
        });

        modelBuilder.Entity<MemoriaLaboral>(entity =>
        {
            entity.HasKey(e => e.MemoriaLaboralId).HasName("PK__MemoriaL__38C44E42B7E2E982");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.ImagenPortadaUrl)
                .HasMaxLength(500)
                .HasColumnName("ImagenPortadaURL");
            entity.Property(e => e.Titulo).HasMaxLength(300);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.MemoriaLaboral)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_MemoriaLaboral_Usuario");
        });

        modelBuilder.Entity<NumeralLaip>(entity =>
        {
            entity.HasKey(e => e.NumeralLaipid).HasName("PK__NumeralL__B99186825C1DD52A");

            entity.ToTable("NumeralLAIP");

            entity.Property(e => e.NumeralLaipid).HasColumnName("NumeralLAIPId");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Titulo).HasMaxLength(300);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.NumeralLaip)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_NumeralLAIP_Usuario");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pago__F00B6138C741EAB3");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoIVA");
            entity.Property(e => e.MontoPago).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.Referencia).HasMaxLength(200);

            entity.HasOne(d => d.Arrendamiento).WithMany(p => p.Pago)
                .HasForeignKey(d => d.ArrendamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_Arrendamiento");

            entity.HasOne(d => d.Estado).WithMany(p => p.Pago)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_Estado");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_TipoPago");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Pago_Usuario");
        });

        modelBuilder.Entity<PlazaTrabajo>(entity =>
        {
            entity.HasKey(e => e.PlazaTrabajoId).HasName("PK__PlazaTra__0BAA13CD9BA7BB37");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaLimite).HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.NumeroVacantes).HasDefaultValue(1);
            entity.Property(e => e.SalarioMax).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.SalarioMin).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TituloPlaza).HasMaxLength(200);

            entity.HasOne(d => d.Departamento).WithMany(p => p.PlazaTrabajo)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_PlazaTrabajo_Departamento");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.PlazaTrabajo)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlazaTrabajo_Estado");

            entity.HasOne(d => d.Seccion).WithMany(p => p.PlazaTrabajo)
                .HasForeignKey(d => d.SeccionId)
                .HasConstraintName("FK_PlazaTrabajo_Seccion");

            entity.HasOne(d => d.TipoContrato).WithMany(p => p.PlazaTrabajo)
                .HasForeignKey(d => d.TipoContratoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlazaTrabajo_TipoContrato");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.PlazaTrabajo)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_PlazaTrabajo_Usuario");
        });

        modelBuilder.Entity<Postulacion>(entity =>
        {
            entity.HasKey(e => e.PostulacionId).HasName("PK__Postulac__5F6D89A9D86D9104");

            entity.Property(e => e.CvUrl).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FechaEntrevista).HasColumnType("datetime");
            entity.Property(e => e.FechaPostulacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.PlazaTrabajo).WithMany(p => p.Postulacion)
                .HasForeignKey(d => d.PlazaTrabajoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Postulacion_Plaza");

            entity.HasOne(d => d.UsuarioRevisorNavigation).WithMany(p => p.Postulacion)
                .HasForeignKey(d => d.UsuarioRevisor)
                .HasConstraintName("FK_Postulacion_Usuario");
        });

        modelBuilder.Entity<Requisitos>(entity =>
        {
            entity.HasKey(e => e.RequisitosId).HasName("PK__Requisit__D8E439985CDD3DF9");

            entity.Property(e => e.DescripcionRequisito).HasMaxLength(100);
        });

        modelBuilder.Entity<RequisitosPlaza>(entity =>
        {
            entity.HasKey(e => e.RequisitosPlazaId).HasName("PK__Requisit__B7FB279EC683BD89");

            entity.HasOne(d => d.PlazaTrabajo).WithMany(p => p.RequisitosPlaza)
                .HasForeignKey(d => d.PlazaTrabajoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequisitosPlaza_Plaza");

            entity.HasOne(d => d.Requisitos).WithMany(p => p.RequisitosPlaza)
                .HasForeignKey(d => d.RequisitosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequisitosPlaza_Requisito");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F1118E56BB");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DescripcionRol).HasMaxLength(256);
            entity.Property(e => e.NombreRol).HasMaxLength(20);
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__Roles__C4B27840A36DDD51");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.Rol).WithMany(p => p.Roles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Rol");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Roles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Usuario");
        });

        modelBuilder.Entity<Secciones>(entity =>
        {
            entity.HasKey(e => e.SeccionesId).HasName("PK__Seccione__4F1CD08AB7476E37");

            entity.Property(e => e.NombreSecciones).HasMaxLength(150);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Secciones)
                .HasForeignKey(d => d.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Secciones_Departamento");
        });

        modelBuilder.Entity<ServicioAdicional>(entity =>
        {
            entity.HasKey(e => e.ServicioAdicionalId).HasName("PK__Servicio__F61F150A2BCE7294");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreServicio).HasMaxLength(200);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnidadMedida).HasMaxLength(30);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.ServicioAdicional)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicioAdicional_Categoria");
        });

        modelBuilder.Entity<Tarifario>(entity =>
        {
            entity.HasKey(e => e.TarifarioId).HasName("PK__Tarifari__FE214B22581AF203");

            entity.Property(e => e.Activo).HasDefaultValue(1);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorDeposito).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.TelefonoId).HasName("PK__Telefono__A9C6EF1658535841");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoDePais).WithMany(p => p.Telefono)
                .HasForeignKey(d => d.CodigoDePaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Telefono_CodigoPais");
        });

        modelBuilder.Entity<TipoAjuste>(entity =>
        {
            entity.HasKey(e => e.TipoAjusteId).HasName("PK__TipoAjus__8AAF03729581F699");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreTipoAjuste).HasMaxLength(150);
        });

        modelBuilder.Entity<TipoContrato>(entity =>
        {
            entity.HasKey(e => e.TipoContratoId).HasName("PK__TipoCont__3E0E5787C488E185");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreTipoContrato).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.HasKey(e => e.TipoEventoId).HasName("PK__TipoEven__4231C183687A11E4");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DescripcionTipoEvento).HasMaxLength(256);
            entity.Property(e => e.NombreTipoEvento).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.TipoPagoId).HasName("PK__TipoPago__424FFE0B24644BDA");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreTipoPago).HasMaxLength(100);
        });

        modelBuilder.Entity<TransaccionPago>(entity =>
        {
            entity.HasKey(e => e.TransaccionPagoId).HasName("PK__Transacc__DEF7D8CDA928AABF");

            entity.Property(e => e.CodigoRespuesta).HasMaxLength(50);
            entity.Property(e => e.EstadoPasarela).HasMaxLength(50);
            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MensajeRespuesta).HasMaxLength(500);
            entity.Property(e => e.Pasarela).HasMaxLength(50);
            entity.Property(e => e.ReferenciaPasarela).HasMaxLength(500);
            entity.Property(e => e.TokenTransaccion).HasMaxLength(500);

            entity.HasOne(d => d.Pago).WithMany(p => p.TransaccionPago)
                .HasForeignKey(d => d.PagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransaccionPago_Pago");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B83F45C594");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ApellidoCasada).HasMaxLength(20);
            entity.Property(e => e.Dpi)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DPI");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nit)
                .HasMaxLength(10)
                .HasColumnName("NIT");
            entity.Property(e => e.PrimerApellido).HasMaxLength(20);
            entity.Property(e => e.PrimerNombre).HasMaxLength(20);
            entity.Property(e => e.SegundoApellido).HasMaxLength(20);
            entity.Property(e => e.SegundoNombre).HasMaxLength(20);
            entity.Property(e => e.TercerNombre).HasMaxLength(20);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_Usuario_Departamento");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_Usuario_Seccion");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK_Usuario_Rol");

            entity.HasOne(d => d.Telefono).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.TelefonoId)
                .HasConstraintName("FK_Usuario_Telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
