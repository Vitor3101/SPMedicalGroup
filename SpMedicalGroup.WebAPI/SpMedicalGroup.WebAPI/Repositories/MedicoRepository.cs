using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPClinicalGroupContext ctx = new();
        public bool Atualizar(int idMedico, Medico atualizarMedico)
        {
            Medico medicoDesatualizado = new();

            if (atualizarMedico.IdClinica != null && atualizarMedico.IdEspecialidade != null)
            {
                medicoDesatualizado.Crm = atualizarMedico.Crm;
                medicoDesatualizado.IdClinica = atualizarMedico.IdClinica;
                medicoDesatualizado.IdEspecialidade = atualizarMedico.IdEspecialidade;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(ListarPorId(idMedico));
            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

        public Medico ListarPorCRM(string CRM)
        {
            return ctx.Medicos.FirstOrDefault(e => e.Crm == CRM);
        }

        public Medico ListarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(e => e.IdMedico == idMedico);
        }
    }
}
