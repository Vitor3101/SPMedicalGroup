using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using SpMedicalGroup.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario Login) {

            try {
                Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("E=mail ou Senha incorretos!");}

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim( "role", usuarioBuscado.IdTipoUsuario.ToString() ),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome)
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedical-group-chave"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(

                    issuer: "spMedical.webAPI",
                    audience: "spMedical.webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(200),
                    signingCredentials: creds
                    );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    } }
