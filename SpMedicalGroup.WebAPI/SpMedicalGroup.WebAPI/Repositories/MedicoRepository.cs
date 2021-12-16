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
    public class MedicoRepository : IMedicoRepository
    {
        SPClinicalContext ctx = new();

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
            return ctx.Medicos.Select(m => new Medico()
            {
                IdUsuario = m.IdMedico,
                IdMedico = m.IdMedico,
                IdUsuarioNavigation = new Usuario()
                {
                    Nome = m.IdUsuarioNavigation.Nome
                }
            }).ToList();
        }

        public Medico ListarPorCRM(string CRM)
        {
            return ctx.Medicos.Include(m => m.IdUsuarioNavigation).Include(m => m.IdClinicaNavigation).FirstOrDefault(e => e.Crm == CRM);
        }

        public Medico ListarPorId(int idMedico)
        {
            return ctx.Medicos.Include(m => m.IdUsuarioNavigation).Include(m => m.IdClinicaNavigation).FirstOrDefault(e => e.IdMedico == idMedico);
        }
    }
}

