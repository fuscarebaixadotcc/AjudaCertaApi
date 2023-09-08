create database FuscaTcc
drop database FuscaTcc
use FuscaTcc;

insert into Pessoa(idPessoa, nome, documento, telefone, genero, idEndereco, idUsuario) values (1,'joao vitor', '44454352879', '11946410819', 'masculino', 40000, 10001)	

	

create table Usuario(idUsuario int Primary Key IDENTITY(10001,1),
					senha varchar (25),
					email varchar(50),
					senha_hash varbinary(max),
					senha_salt varbinary(max));

create table Endereco (idEndereco int Primary Key IDENTITY(40000,1),
						rua varchar (50),
						estado varchar (30),
						cep varchar(9),
						cidade varchar(50)
						)
						
create table Pessoa(idPessoa int Primary Key,
                    nome varchar (50),
					tipo int,
					documento varchar(14),
					telefone varchar(15),
					genero varchar(20),
					dtNasc date,
					idEndereco int foreign key references Endereco (idEndereco),
					idUsuario int foreign key references Usuario (idUsuario)
					);

create table Agenda(idAgenda int Primary Key,
					statusAgenda int,
					tipo int,
					data date,
					idPessoa int references Pessoa,
					idEndereco int references Endereco)

create table Doacao(idDoacao int Primary Key IDENTITY(20000,1),
					statusDoacao int,
					idDoacaoOrigem int,
					data date,
					tipoDoacao int,
					idPessoa int references Pessoa,
					idAgenda int references Agenda)

create table Dinheiro(idDinheiro int Primary key, --id da doacao
					valor numeric(8,2))

create table ItemDoacao (idItem int Primary Key,
						descricao varchar(100),
						nome varchar(50))

create table ItemDoacaoDoado(idDoacao int references Doacao,
							idItem int references ItemDoacao)

create table Produto (idProduto int Primary Key,
					tipoProduto int,
					validade date,
					idItem int references ItemDoacao)

create table Eletrodomestico (idEletro int Primary Key,
							condicao varchar (20),
							medida varchar(20),
							idItem int references ItemDoacao)

create table Roupa (idRoupa int Primary Key,
					fxEtaria int,
					genero int,
					condicao varchar(20),
					tamanho varchar(3),
					idItem int references ItemDoacao)

create table Mobilia (idMobilia int Primary Key,
					tipo varchar(30),
					condicao varchar(20),
					medida varchar(20),
					idItem int references ItemDoacao)


