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
    public class EspecialidadeController : ControllerBase
    {
        IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspecialidade)
        {
            _especialidadeRepository.Cadastrar(novaEspecialidade);
            return StatusCode(201);
        }

        [HttpGet]
        public  IActionResult Listar()
        {
            return Ok(_especialidadeRepository.Listar());
        }

        [HttpGet("ListarPorId/{idEspecialidade}")]
        public IActionResult ListarId(int idEspecialidade)
        {
            return Ok(_especialidadeRepository.ListarPorId(idEspecialidade));
        }

        [HttpDelete("Deletar/{idEspecialidade}")]
        public IActionResult Deletar(int idEspecialidade)
        {
            _especialidadeRepository.Deletar(idEspecialidade);
            return Ok();
        }
    }
}
