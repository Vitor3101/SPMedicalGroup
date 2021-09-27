using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> Listar();
        Consultum ListarPorId(int idConsulta);
        Consultum ListarPorIdMedico(int idMedico);
        Consultum ListarPorIdPaciente(int idPaciente);
        
        
        void Cadastrar(Consultum novoMedico);
        bool Atualizar(int idConsulta, Consultum consultaDesatualizada);
        bool AtualizarSituação(int idConsulta, Consultum situacaoDesatualizada);
        void Deletar(int idConsulta);
    }
}
