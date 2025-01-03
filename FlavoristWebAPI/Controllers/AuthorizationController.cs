﻿using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthorizationService _authorizationService;
        private readonly LoginService _loginService;
        private readonly CatalogoServiceUsuarioTipo _catalogoServiceUsuarioTipo;
        private readonly IWebHostEnvironment _env;

        public AuthorizationController(
            AuthorizationService authorizationService,
            LoginService loginService,
            CatalogoServiceUsuarioTipo catalogoServiceUsuarioTipo,
            IWebHostEnvironment env
        )
        {
            _authorizationService = authorizationService;
            _loginService = loginService;
            _catalogoServiceUsuarioTipo = catalogoServiceUsuarioTipo;
            _env = env;
        }

        // Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthResultDTO> Post([FromBody] AuthDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest( new { error = true, message = "Debe enviar un usuario válido." });

            try
            {
                var usuario = _loginService.Login(loginDTO);
                var token = _authorizationService.GenerateToken(usuario);

                var usuarioTipo = _catalogoServiceUsuarioTipo.ObtenerPorId(usuario.UsuarioTipoID).Nombre;

                var resultado = new AuthResultDTO()
                {
                    Id = usuario.Id,
                    NombresCompletos = usuario.Nombres + " " + usuario.Apellidos,
                    Correo = usuario.Correo,
                    UsuarioTipo = usuarioTipo,
                    FechaLogin = DateTime.Now,
                    Token = token,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
