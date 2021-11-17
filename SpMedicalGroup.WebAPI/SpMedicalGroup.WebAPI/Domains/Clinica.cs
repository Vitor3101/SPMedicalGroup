using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.WebAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        //Perguntar se pode fazer o trabalho sem essa DataAnnotation ou se tem outra maneira de atualizar o CNPJ sem cair nesse erro.
        [Required(ErrorMessage = "O nome da clinica é obrigatório")]
        public string NomeClinica { get; set; }

        [StringLength(18, ErrorMessage = "O campo CNPJ precisa ter no mínimo 18 Digitos")]
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
