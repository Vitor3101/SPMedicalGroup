using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPaciente { get; set; }
        public string DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
