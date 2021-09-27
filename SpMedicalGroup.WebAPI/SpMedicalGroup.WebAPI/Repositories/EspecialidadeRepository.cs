using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPClinicalGroupContext ctx = new();
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idEspecialidade)
        {
            ctx.Especialidades.Remove(ListarPorId(idEspecialidade));
            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }

        public Especialidade ListarPorId(int idespecialidade)
        {
            return ctx.Especialidades.Find(idespecialidade);
        }
    }
}
