using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();
        Paciente ListarPorId(int idPaciente);
        Paciente ListarPorCpf(string CPF);
        void Cadastrar(Paciente novoCliente);
        bool Atualizar(int idPaciente, Paciente atualizarPaciente);
        void Deletar(int idMedico);
    }
}
