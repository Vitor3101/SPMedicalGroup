using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpClinicalContext ctx = new();
        public bool Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            Consultum consultaDesatualizada = new();

            if (consultaAtualizada.IdMedico != 0 && consultaAtualizada.IdPaciente != 0 && consultaAtualizada.IdSituacao != 0 || consultaAtualizada.IdSituacao > 3)
            {
                consultaDesatualizada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaDesatualizada.IdMedico = consultaAtualizada.IdMedico;
                consultaDesatualizada.DataConsulta = consultaAtualizada.DataConsulta;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AtualizarSituação(int idConsulta, Consultum situacaoAtualizada)
        {
            Consultum consultaDesatualizada = new();

            if (situacaoAtualizada.IdSituacao != 0)
            {
                consultaDesatualizada.IdSituacao = situacaoAtualizada.IdSituacao;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(ListarPorId(idConsulta));
            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdSituacaoNavigation).ToList();
        }

        public Consultum ListarPorId(int idConsulta)
        {
            return ctx.Consulta.Find(idConsulta);
        }

        public Consultum ListarPorIdMedico(int idMedico)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdMedico == idMedico);
        }

        public Consultum ListarPorIdPaciente(int idPaciente)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdPaciente == idPaciente);
        }
    }
}
