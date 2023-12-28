using Domain.Entities;
using Domain.Entities.Catalog;
using Infraestructure.Data.Config;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Data.Context
{
    public class DBContext : DbContext
    {
        //Catalog
        public DbSet<EventoTipo> EventoTipos { get; set; }
        public DbSet<IngredienteCategoria> IngredienteCategorias { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<RecetaCategoria> RecetaCategorias { get; set; }
        public DbSet<RecetaDificultad> RecetaDificultades { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<UsuarioTipo> UsuarioTipos { get; set; }

        //Entities
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; } 
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes {  get; set; }
        public DbSet<RecetaPaso> RecetaPasos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRecetaCategoriaFav> UsuarioRecetaCategoriaFavs { get; set; }
        public DbSet<UsuarioRecetaFav> UsuarioRecetaFavs { get; set; }

        //Apply Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Flavorist;Trusted_Connection=True;");
        }

        //Apply Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComentarioConfig());
            modelBuilder.ApplyConfiguration(new EventoConfig());
            modelBuilder.ApplyConfiguration(new EventoTipoConfig());
            modelBuilder.ApplyConfiguration(new FollowConfig());
            modelBuilder.ApplyConfiguration(new LikeConfig());
            modelBuilder.ApplyConfiguration(new NotificacionConfig());
            modelBuilder.ApplyConfiguration(new RecetaConfig());
            modelBuilder.ApplyConfiguration(new RecetaDificultadConfig());
            modelBuilder.ApplyConfiguration(new RecetaIngredienteConfig());
            modelBuilder.ApplyConfiguration(new RecetaPasoConfig());
            modelBuilder.ApplyConfiguration(new UnidadMedidaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}
