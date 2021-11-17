using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
            Usuarios = new HashSet<Usuario>();
        }

        public  int IdMedico { get; set; }
        public string Crm { get; set; }
        public int? IdClinica { get; set; }
        public int? IdEspecialidade { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
