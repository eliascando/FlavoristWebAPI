using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/forgotpass")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly SenderService _senderService;
        private readonly OTPService _otpService;
        private readonly PasswordService _passwordService;
        private readonly IWebHostEnvironment _env;

        public ForgotPasswordController(
            SenderService senderService, 
            OTPService otpService,
            PasswordService passwordService,
            IWebHostEnvironment env
        )
        {
            _senderService = senderService;
            _otpService = otpService;
            _passwordService = passwordService;
            _env = env;
        }

        [HttpGet("gettoken/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == null)
                return BadRequest(new { succed = false, message = "Debe enviar un id" });
            try
            {
                var otp = _otpService.GenerarOTP(id);
                var mensaje = $"<h1>Flavorist</h1><p>Estimado usuario, para reestablecer su contraseña debe ingresar el siguiente OTP:</p><strong>{otp}</strong><p>Este código expira en 1 minuto.</p>";
                var correo = _passwordService.ObtenerCorreo(id);

                var result = await _senderService.Send(correo, mensaje, "Recuperación de contraseña");
                if (result)
                    return Ok(new { succed = true, message = "Correo enviado." });
                else
                    return BadRequest(new { succed = false, message = "No se pudo enviar el correo." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        [HttpGet("validatetoken/{id}/{token}")]
        [AllowAnonymous]
        public ActionResult Validate(Guid id, string token)
        {
            if (id == null || token == null)
                return BadRequest(new { succed = false, message = "Debe enviar un id y un token" });
            try
            {
                var result = _otpService.ValidarOTP(id, token);
                if (result)
                    return Ok(new { succed = true, message = "Token válido." });
                else
                    return BadRequest(new { succed = false, message = "Token inválido." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        [HttpPost("changepass")]
        [AllowAnonymous]
        public ActionResult ChangePass([FromBody] ChangePassDTO p)
        {
            if (p == null)
                return BadRequest(new { succed = false, message = "Debe enviar un usuario válido." });
            try
            {
                var result = _passwordService.CambiarPassword(p.Id, p.Password);
                if (result)
                    return Ok(new { succed = true, message = "Contraseña cambiada correctamente." });
                else
                    return BadRequest(new { succed = false, message = "No se pudo cambiar la contraseña." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
