using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Catalog;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Comunication.Mail;

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
            services.AddScoped<IServiceBase<Follow, Guid>, FollowService>();
            services.AddScoped<IServiceFollow<UserDTO, Guid, Guid, Guid>, FollowService>();
            services.AddScoped<IServicePost<Receta, Guid>, PostService>();
            services.AddScoped<IServiceBase<Usuario, Guid>, UsuarioService>();
            services.AddScoped<IServicePreferencia<UsuarioRecetaCategoriaFav, Guid>, PreferenciaCategoriaService>();
            services.AddScoped<IServicePreferencia<UsuarioRecetaFav, Guid>, PreferenciaRecetaService>();
            services.AddScoped<IServiceObtenerNotificacion<NotificacionDTO, Guid>, ObtenerNotificacionService>();
            services.AddScoped<IServiceBase<Pais, Guid>, CatalogoServicePais>();
            services.AddScoped<IServiceBase<UsuarioTipo, int>, CatalogoServiceUsuarioTipo>();
            services.AddScoped<IServiceBase<IngredienteCategoria, Guid>, CatalogoServiceIngredienteCategoria>();
            services.AddScoped<IServiceBase<RecetaCategoria, Guid>, CatalogoServiceRecetaCategoria>();
            services.AddScoped<IServiceBase<RecetaDificultad, int>, CatalogoServiceRecetaDificultad>();
            services.AddScoped<IServiceBase<UnidadMedida, int>, CatalogoServiceUnidadMedida>();
            services.AddScoped<IServiceBase<EventoTipo, int>, CatalogoServiceEventoTipo>();
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
            services.AddScoped<IRepositoryBase<Usuario, Guid>, UsuarioRepository>();
            services.AddScoped<IRepositoryBase<Publicacion, Guid>, PublicacionRepository>();
            services.AddScoped<IRepositoryLike<Like,LikeDTO, UserDTO, Guid, Guid>, LikeRepository>();
            services.AddScoped<IRepositoryPost<Receta, Guid>, PostRepository>();
            services.AddScoped<IRepositoryBase<Notificacion, Guid>, NotificacionRepository>();
            services.AddScoped<IRepositoryAuthorization<AuthDTO, Usuario>, LoginRepository>();
            services.AddScoped<IRepositoryFollow<UserDTO, Guid, Guid, Guid>, FollowsRepository>();
            services.AddScoped<IRepositoryBase<Follow, Guid>, FollowRepository>();
            services.AddScoped<IRepositoryBase<Evento, Guid>, EventoRepository>();
            services.AddScoped<IRepositoryPreferencia<UsuarioRecetaCategoriaFav, Guid>, PreferenciaCategoriaRepository>();
            services.AddScoped<IRepositoryPreferencia<UsuarioRecetaFav, Guid>, PreferenciasRecetaRepository>();
            services.AddScoped<IRepositoryObtenerNotificacion<NotificacionDTO, Guid>, ObtenerNotificacionRepository>();
            services.AddScoped<IRepositoryComentario<Comentario, Guid>, ComentarioRepository>();
            services.AddScoped<IRepositoryBase<EventoTipo, int>, CatalogoRepositoryEventoTipo>();
            services.AddScoped<IRepositoryBase<UnidadMedida, int>, CatalogoRepositoryUnidadMedida>();
            services.AddScoped<IRepositoryBase<RecetaDificultad, int>, CatalogoRepositoryRecetaDificultad>();
            services.AddScoped<IRepositoryBase<RecetaCategoria, Guid>, CatalogoRepositoryRecetaCategoria>();
            services.AddScoped<IRepositoryBase<IngredienteCategoria, Guid>, CatalogoRepositoryIngredienteCategoria>();
            services.AddScoped<IRepositoryBase<UsuarioTipo, int>, CatalogoRepositoryUsuarioTipo>();
            services.AddScoped<IRepositoryBase<Pais, Guid>, CatalogoRepositoryPais>();
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
