USE SPCLINICALGROUP
GO

INSERT INTO CLINICA (NomeCLinica, CNPJ, RazaoSocial, Endereco)
VALUES ('SPMedicalGroup', '86.400.902/0001-30', 'SPMedicalGroup', 'Av. Bar�o Limeira, 532, S�o Paulo, SP')
GO

INSERT INTO ESPECIALIDADE(Especialidade)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da M�o'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pedi�trica'),('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria')
GO

INSERT INTO SITUACAO (Situacao)
VALUES ('Agendada'),('Concluida'),('Cancelada')
GO

INSERT INTO TipoUsuario(Tipo)
VALUES ('Administrador'),('M�dico'),('Paciente')
GO

INSERT INTO PACIENTE(DataNasc, Telefone, RG, CPF, Endereco)
VALUES ('10/13/1983','11 3456-7654','43522543-5','94839859000','Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000'),
	   ('07/23/2001','11 98765-6543','32654345-7','73556944057','Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'),
       ('10/10/1978','11 97208-4453','54636525-3','16839338002','Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'),
       ('10/13/1985','11 3456-6543','54366362-5','14332654765','R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
       ('08/27/1975','11 7656-6377','53254444-1','91305348010','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'),
       ('03/21/1972','11 95436-8769','54566266-7','79799299004','Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP,'),
       ('03/05/2018','','54566266-8','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140')
GO

INSERT INTO MEDICO(CRM, idClinica, idEspecialidade)
VALUES ('54356-SP',1,2),('53452-SP',1,17),('65463-SP',1,16)
GO

INSERT INTO USUARIO(Nome, Email, idTipoUsuario, idPaciente, idMedico)
VALUES ('Ligia','ligia@gmail.com',3,1,NULL),
('Alexandre','alexandre@gmail.com',3,2,NULL),
('Fernando','fernando@gmail.com',3,3,NULL),
('Henrique','henrique@gmail.com',3,4,NULL),
('Jo�o','joao@hotmail.com',3,5,NULL),
('Bruno','bruno@gmail.com',3,6,NULL),
('Mariana','mariana@outlook.com',3,7,NULL),
('Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br1',2,NULL,1),
('Roberto Possarle','roberto.possarle@spmedicalgroup.com.br',2,NULL,2),
('Helena Strada','helena.souza@spmedicalgroup.com.br',2,NULL,3)

INSERT INTO USUARIO(Nome, Email, Senha, idTipoUsuario, idPaciente, idMedico) VALUES ('ADMIN','Admin@Admin.com','Admin123',1,null,null)

INSERT INTO CONSULTA(idPaciente, idMedico, DataConsulta, idSituacao)
VALUES (7,3,'01/20/2020',2),
       (2,2,'01/06/2020',3),
	   (3,2,'02/07/2020',2),
	   (2,2,'02/06/2018',2),
	   (4,1,'02/07/2019',3),
	   (7,3,'02/08/2020',1),
	   (4,1,'03/08/2020',1)