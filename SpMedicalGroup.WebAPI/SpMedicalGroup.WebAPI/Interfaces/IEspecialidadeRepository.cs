using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();
        void Cadastrar(Especialidade novaEspecialidade);
        void Deletar(int idEspecialidade);
        Especialidade ListarPorId(int idespecialidade);
    }
}
