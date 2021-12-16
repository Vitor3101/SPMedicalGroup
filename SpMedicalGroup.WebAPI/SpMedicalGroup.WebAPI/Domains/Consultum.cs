using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebAPI.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int IdPaciente { get; set; }
        public short IdMedico { get; set; }
        public string DataConsulta { get; set; }
        public string Descricao { get; set; }
        public byte IdSituacao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
