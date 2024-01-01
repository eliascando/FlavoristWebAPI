using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Catalog;
using Infraestructure.Comunication.Mail;
using Infraestructure.Persistence.Context;
using Infraestructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace FlavoristWebAPI.Config
{
    public static class DependencyInjectionConfig
    {
        // Inject services to the container.
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add controllers
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAuthorization();

            // Add swagger
            services.AddSwaggerGen();

            #region CustomServices
            // Add services
            services.AddScoped<AuthorizationService>();
            services.AddScoped<LoginService>();
            services.AddScoped<LikeService>();
            services.AddScoped<ComentarioService>();
            services.AddScoped<FollowService>();
            services.AddScoped<PostService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<PreferenciaCategoriaService>();
            services.AddScoped<PreferenciaRecetaService>();
            services.AddScoped<ObtenerNotificacionService>();
            services.AddScoped<CatalogoServicePais>();
            services.AddScoped<CatalogoServiceUsuarioTipo>();
            services.AddScoped<CatalogoServiceIngredienteCategoria>();
            services.AddScoped<CatalogoServiceRecetaCategoria>();
            services.AddScoped<CatalogoServiceRecetaDificultad>();
            services.AddScoped<CatalogoServiceUnidadMedida>();
            services.AddScoped<CatalogoServiceEventoTipo>();
            services.AddScoped<SenderService>();
            services.AddScoped<OTPService>();
            services.AddScoped<PasswordService>();

            // Implement Services
            services.AddScoped<IServiceAuthorization<Usuario, AuthResultDTO>, AuthorizationService>();
            services.AddScoped<IServiceLogin<AuthDTO, Usuario>, LoginService>();
            services.AddScoped<IServiceLike<Like, LikeDTO, UserDTO, Guid, Guid>, LikeService>();
            services.AddScoped<IServiceComentario<Comentario, CommentDTO, Guid>, ComentarioService>();
            services.AddScoped<IServiceBase<Follow, int, Guid>, FollowService>();
            services.AddScoped<IServiceFollow<UserDTO, Guid, Guid, Guid>, FollowService>();
            services.AddScoped<IServicePost<Receta, Guid>, PostService>();
            services.AddScoped<IServiceBase<Usuario, int, Guid>, UsuarioService>();
            services.AddScoped<IServicePreferencia<UsuarioRecetaCategoriaFav, Guid>, PreferenciaCategoriaService>();
            services.AddScoped<IServicePreferencia<UsuarioRecetaFav, Guid>, PreferenciaRecetaService>();
            services.AddScoped<IServiceObtenerNotificacion<NotificacionDTO, Guid>, ObtenerNotificacionService>();
            services.AddScoped<IServiceBase<Pais, int, Guid>, CatalogoServicePais>();
            services.AddScoped<IServiceBase<UsuarioTipo, int, Guid>, CatalogoServiceUsuarioTipo>();
            services.AddScoped<IServiceBase<IngredienteCategoria, int, Guid>, CatalogoServiceIngredienteCategoria>();
            services.AddScoped<IServiceBase<RecetaCategoria, int, Guid>, CatalogoServiceRecetaCategoria>();
            services.AddScoped<IServiceBase<RecetaDificultad, int, Guid>, CatalogoServiceRecetaDificultad>();
            services.AddScoped<IServiceBase<UnidadMedida, int, Guid>, CatalogoServiceUnidadMedida>();
            services.AddScoped<IServiceBase<EventoTipo, int, Guid>, CatalogoServiceEventoTipo>();
            services.AddScoped<IServiceSender<string, string, string>, SenderService>();
            services.AddScoped<IServiceOTP<Guid>, OTPService>();
            services.AddScoped<IServicePassword<Guid, string>, PasswordService>();

            // Add repositories
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<PublicacionRepository>();
            services.AddScoped<LikeRepository>();
            services.AddScoped<PostRepository>();
            services.AddScoped<NotificacionRepository>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<FollowsRepository>();
            services.AddScoped<FollowRepository>();
            services.AddScoped<EventoRepository>();
            services.AddScoped<PreferenciaCategoriaRepository>();
            services.AddScoped<PreferenciasRecetaRepository>();
            services.AddScoped<ObtenerNotificacionRepository>();
            services.AddScoped<ComentarioRepository>();
            services.AddScoped<CatalogoRepositoryEventoTipo>();
            services.AddScoped<CatalogoRepositoryUnidadMedida>();
            services.AddScoped<CatalogoRepositoryRecetaDificultad>();
            services.AddScoped<CatalogoRepositoryRecetaCategoria>();
            services.AddScoped<CatalogoRepositoryIngredienteCategoria>();
            services.AddScoped<CatalogoRepositoryUsuarioTipo>();
            services.AddScoped<CatalogoRepositoryPais>();
            services.AddScoped<PasswordRepository>();

            // Implement Repositories
            services.AddScoped<IRepositoryBase<Usuario, int, Guid>, UsuarioRepository>();
            services.AddScoped<IRepositoryBase<Publicacion, int, Guid>, PublicacionRepository>();
            services.AddScoped<IRepositoryLike<Like,LikeDTO, UserDTO, Guid, Guid>, LikeRepository>();
            services.AddScoped<IRepositoryPost<Receta, Guid>, PostRepository>();
            services.AddScoped<IRepositoryBase<Notificacion, int, Guid>, NotificacionRepository>();
            services.AddScoped<IRepositoryAuthorization<AuthDTO, Usuario>, LoginRepository>();
            services.AddScoped<IRepositoryFollow<UserDTO, Guid, Guid, Guid>, FollowsRepository>();
            services.AddScoped<IRepositoryBase<Follow, int, Guid>, FollowRepository>();
            services.AddScoped<IRepositoryBase<Evento, int, Guid>, EventoRepository>();
            services.AddScoped<IRepositoryPreferencia<UsuarioRecetaCategoriaFav, Guid>, PreferenciaCategoriaRepository>();
            services.AddScoped<IRepositoryPreferencia<UsuarioRecetaFav, Guid>, PreferenciasRecetaRepository>();
            services.AddScoped<IRepositoryObtenerNotificacion<NotificacionDTO, Guid>, ObtenerNotificacionRepository>();
            services.AddScoped<IRepositoryComentario<Comentario, Guid>, ComentarioRepository>();
            services.AddScoped<IRepositoryBase<EventoTipo, int, Guid>, CatalogoRepositoryEventoTipo>();
            services.AddScoped<IRepositoryBase<UnidadMedida, int, Guid>, CatalogoRepositoryUnidadMedida>();
            services.AddScoped<IRepositoryBase<RecetaDificultad, int, Guid>, CatalogoRepositoryRecetaDificultad>();
            services.AddScoped<IRepositoryBase<RecetaCategoria, int, Guid>, CatalogoRepositoryRecetaCategoria>();
            services.AddScoped<IRepositoryBase<IngredienteCategoria, int, Guid>, CatalogoRepositoryIngredienteCategoria>();
            services.AddScoped<IRepositoryBase<UsuarioTipo, int, Guid>, CatalogoRepositoryUsuarioTipo>();
            services.AddScoped<IRepositoryBase<Pais, int, Guid>, CatalogoRepositoryPais>();
            services.AddScoped<IRepositoryPassword<Guid, string>, PasswordRepository>();
            #endregion

            // Add DBContext
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Master")
                ?? throw new ArgumentNullException("Master", "ERROR!, No existe la cadena de conexión")));

            // Add Mail Config
            services.Configure<MailConfig>(configuration.GetSection("MailConfig") 
                ?? throw new ArgumentNullException("MailConfig", "ERROR!, No existe la sección de configuración de correo"));

            // Add CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", 
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add HealthChecks
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Master")
                ?? throw new ArgumentNullException("Master", "ERROR!, No existe la cadena de conexión"));

            return services;
        }
    }
}
