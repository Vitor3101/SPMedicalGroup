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
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            _ConsultaRepository.Cadastrar(novaConsulta);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult ListarConsultas()
        {
            return Ok(_ConsultaRepository.Listar());
        }

        [HttpGet("ListarPorId/{idConsulta}")]
        public IActionResult ListarConsulta(int idConsulta)
        {
            return Ok(_ConsultaRepository.ListarPorId(idConsulta));
        }
        
        [HttpDelete("Deletar/{idConsulta}")]
        public IActionResult DeletarConsulta(int idConsulta)
        {
            _ConsultaRepository.Deletar(idConsulta);
            return Ok();
        }
    }
}
