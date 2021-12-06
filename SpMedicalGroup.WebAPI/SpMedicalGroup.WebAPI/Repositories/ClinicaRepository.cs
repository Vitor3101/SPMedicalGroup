using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpClinicalContext ctx = new();
        public bool Atualizar(int idClinica, Clinica atualizarClinica)
        {
            Clinica clinicaDesatualizada = new();
            if (atualizarClinica.NomeClinica != null && atualizarClinica.Cnpj != null)
            {
               clinicaDesatualizada.NomeClinica = atualizarClinica.NomeClinica;
               clinicaDesatualizada.Cnpj = atualizarClinica.Cnpj;
               return true;
            }
            
            if(atualizarClinica.NomeClinica != null)
            {
                clinicaDesatualizada.Cnpj = atualizarClinica.Cnpj;
                return true;
            }
            else if(atualizarClinica.Cnpj != null)
            {
                clinicaDesatualizada.NomeClinica = atualizarClinica.NomeClinica;
                return true;
            }
                return false;
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.Remove(ListarPorId(idClinica));
            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }

        public Clinica ListarPorCNPJ(string CNPJ)
        {
            return ctx.Clinicas.FirstOrDefault(e => e.Cnpj == CNPJ);
        }

        public Clinica ListarPorId(int idClinica)
        {
            return ctx.Clinicas.Find(idClinica);
        }
    }
}
