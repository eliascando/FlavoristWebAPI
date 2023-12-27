using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure.Data.Config;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Data.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<EntidadTipo> EntidadTipos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoTipo> EventoTipos { get; set; }
        public DbSet<IngredienteCategoria> IngredienteCategorias { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; } 
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<RecetaCategoria> RecetaCategorias { get; set; }
        public DbSet<RecetaDificultad> RecetaDificultades { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes {  get; set; }
        public DbSet<RecetaPaso> RecetaPasos { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRecetaCategoriaFav> UsuarioRecetaCategoriaFavs { get; set; }
        public DbSet<UsuarioRecetaFav> UsuarioRecetaFavs { get; set; }
        public DbSet<UsuarioTipo> UsuarioTipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Flavorist;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComentarioConfig());
            modelBuilder.ApplyConfiguration(new EntidadTipoConfig());
            modelBuilder.ApplyConfiguration(new LikeConfig());
            modelBuilder.ApplyConfiguration(new NotificacionConfig());
            modelBuilder.ApplyConfiguration(new RecetaConfig());
            modelBuilder.ApplyConfiguration(new RecetaDificultadConfig());
            modelBuilder.ApplyConfiguration(new RecetaIngredienteConfig());
            modelBuilder.ApplyConfiguration(new RecetaPasoConfig());
            modelBuilder.ApplyConfiguration(new UnidadMedidaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new FollowConfig());
        }

    }
}
