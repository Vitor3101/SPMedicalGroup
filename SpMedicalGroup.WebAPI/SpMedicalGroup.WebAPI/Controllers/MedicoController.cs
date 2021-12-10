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
    public class MedicoController : ControllerBase
    {
        IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            _medicoRepository.Cadastrar(novoMedico);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }

        [HttpGet("Listar")]
        public IActionResult ListarPorId(int idMedico)
        {
            return Ok(_medicoRepository.ListarPorId(idMedico));
        }

        [HttpGet("Crm/{CRM}")]
        public IActionResult ListarCrm(string CRM)
        {
            return Ok(_medicoRepository.ListarPorCRM(CRM));
        }

        [HttpDelete("Id/{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _medicoRepository.Deletar(idMedico);
            return Ok();
        }
    }
}
