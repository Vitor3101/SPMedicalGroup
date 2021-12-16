using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebAPI.Contexts;
using SpMedicalGroup.WebAPI.Domains;
using SpMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPClinicalContext ctx = new();

        public bool AtualizarSituação(int idConsulta, Consultum situacaoAtualizada)
        {
            Consultum consultaDesatualizada = new();

            if (situacaoAtualizada.IdSituacao != 0)
            {
                consultaDesatualizada.IdSituacao = situacaoAtualizada.IdSituacao;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public void AtualizarDescricao(string novaDesc, int id)
        {
            Consultum consultaBuscada = ListarPorId(id);

            if (novaDesc != null)
            {
                consultaBuscada.Descricao = novaDesc;
                ctx.Consulta.Update(consultaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            novaConsulta.Descricao = "";

            ctx.Consulta.Add(novaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(ListarPorId(idConsulta));
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int idUsuarioLogado)
        {
            Medico medicoLogado = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idUsuarioLogado);
            Paciente pacienteLogado = ctx.Pacientes.FirstOrDefault(p => p.IdUsuario == idUsuarioLogado);

            int idPaciente = pacienteLogado.IdPaciente;
            int idMedico = medicoLogado.IdMedico;

            if (medicoLogado != null)
            {
                return ctx.Consulta.Where(c => c.IdMedico == idMedico).AsNoTracking().Select(c => new Consultum()
                {
                    DataConsulta = c.DataConsulta,
                    IdConsulta = c.IdConsulta,
                    Descricao = c.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Crm = c.IdMedicoNavigation.Crm,
                        IdUsuarioNavigation = new Usuario()
                        {
                            Nome = c.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email,
                        },
                        IdClinicaNavigation = new Clinica()
                        {
                            NomeClinica = c.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                        }
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Cpf = c.IdPacienteNavigation.Cpf,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        IdUsuarioNavigation = new Usuario()
                        {
                            Nome = c.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                            Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = c.IdSituacaoNavigation.Situacao1
                    }
                }).ToList();
            }
            else
            {
                return ctx.Consulta.Where(c => c.IdPaciente == idPaciente).AsNoTracking().Select(p => new Consultum()
                {
                    DataConsulta = p.DataConsulta,
                    IdConsulta = p.IdConsulta,
                    Descricao = p.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Crm = p.IdMedicoNavigation.Crm,
                        IdUsuarioNavigation = new Usuario()
                        {
                            Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                            Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                        },
                        IdClinicaNavigation = new Clinica()
                        {
                            NomeClinica = p.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                        }
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Cpf = p.IdPacienteNavigation.Cpf,
                        Telefone = p.IdPacienteNavigation.Telefone,
                        IdUsuarioNavigation = new Usuario()
                        {
                            Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                            Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = p.IdSituacaoNavigation.Situacao1
                    }
                }).ToList();
            };
        }

        public Consultum ListarPorId(int idConsulta)
        {
            return ctx.Consulta.Find(idConsulta);
        }
    }
}
