using SpMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();
        Clinica ListarPorId(int idClinica);
        Clinica ListarPorCNPJ(string CNPJ);

        void Cadastrar(Clinica novaClinica);
        bool Atualizar(int idClinica, Clinica atualizarClinica);
        void Deletar(int idClinica);
    }
}
