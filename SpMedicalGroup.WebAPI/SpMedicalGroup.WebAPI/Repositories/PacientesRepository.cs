using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class PacientesRepository : IPacienteRepository
    {
        SpClinicalContext ctx = new();
        public bool Atualizar(int idPaciente, Paciente atualizarPaciente)
        {
            Paciente pacienteDesatualizado = new();
            ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == idPaciente);

            if (atualizarPaciente.Cpf != null && atualizarPaciente.Rg != null)
            {
                pacienteDesatualizado.Cpf = atualizarPaciente.Cpf;
                pacienteDesatualizado.Rg = atualizarPaciente.Rg;
            }
            
            if(atualizarPaciente.Cpf != null)
            {
                pacienteDesatualizado.Cpf = atualizarPaciente.Cpf;
            }
            else if (atualizarPaciente.Rg != null)
            {
                pacienteDesatualizado.Rg = atualizarPaciente.Rg;
            }
            ctx.Pacientes.Update(pacienteDesatualizado);
            ctx.SaveChanges();
            return true;
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(ListarPorId(idPaciente));
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }

        public Paciente ListarPorCpf(string CPF)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.Cpf == CPF); 
        }

        public Paciente ListarPorId(int idPaciente)
        {
            return ctx.Pacientes.Find(idPaciente);   
        }
    }
}
