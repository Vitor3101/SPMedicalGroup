using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();
        Medico ListarPorId(int idMedico);
        Medico ListarPorCRM(string CRM);
        void Cadastrar(Medico novoMedico);
        bool Atualizar(int idMedico, Medico atualizarMedico);
        void Deletar(int idMedico);
    }
}
