using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarMinhas(int idUsuarioLogado);
        Consultum ListarPorId(int idConsulta);
        
        void Cadastrar(Consultum novoMedico);
        bool AtualizarSituação(int idConsulta, Consultum situacaoDesatualizada);
        void Deletar(int idConsulta);
    }
}
