using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using SpMedicalGroup.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet("/Usuarios")]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        
        [HttpGet("/Usuarios/id/{idUsuario}")]
        public IActionResult ListarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.ListarPorId(idUsuario));
        }


        [HttpPost("/Usuarios")]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }


        [HttpDelete("/Usuarios/{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return Ok("Usuario deletado");
        }
    }
}
