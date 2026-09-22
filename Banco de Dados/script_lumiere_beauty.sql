create database lumiere_beauty;
use lumiere_beauty;

create table Cliente (
	id_cliente int primary key auto_increment,
    nome_completo_cli varchar (300) not null,
    email_cli varchar (300),
    senha_cli varchar (255)
);

create table Profissional (
	id_profissional int primary key auto_increment,
    nome_profi varchar (300) not null,
    telefone_profi varchar (30),
    especialidade_profi varchar (200)
);

create table Categoria ( 
	id_categoria int primary key auto_increment,
    nome_catego varchar (200)
);

create table Servico (
	id_servico int primary key auto_increment,
    nome_serv varchar (300),
    descricao varchar (500), 
    preco double,
    id_categoria_fk int,
	foreign key (id_categoria_fk) references Categoria (id_categoria) 
);

create table Agendamento (
	id_agend int primary key auto_increment,
    data_agend date not null,
    horario_agend time,
    status_agend varchar (40),
    id_cliente_fk int,
    id_profissional_fk int,
    id_servico_fk int,
	foreign key (id_cliente_fk) references Cliente (id_cliente),
    foreign key (id_profissional_fk) references Profissional (id_profissional),
    foreign key (id_servico_fk) references Servico (id_servico)
);

insert into Cliente (id_cliente, nome_completo_cli, email_cli, senha_cli) values
(null, 'ana silva', 'ana@gmail.com', '123456'),
(null, 'maria oliveira', 'maria@gmail.com', '123456'),
(null, 'beatriz santos', 'beatriz@gmail.com', '123456'),
(null, 'carolina souza', 'carolina@gmail.com', '123456'),
(null, 'gabriela costa', 'gabriela@gmail.com', '123456');

insert into profissional (id_profissional, nome_profi, telefone_profi, especialidade_profi) values
(null, 'juliana souza', '(69) 99999-1111', 'maquiagem'),
(null, 'carla oliveira', '(69) 99999-2222', 'cabelo'),
(null, 'fernanda santos', '(69) 99999-3333', 'estetica'),
(null, 'beatriz costa', '(69) 99999-4444', 'maquiagem'),
(null, 'mariana lima', '(69) 99999-5555', 'cabelo');

insert into Categoria (id_categoria, nome_catego) values
(null,'maquiagem'),
(null, 'estetica'),
(null, 'cabelo');

insert into servico (id_servico, nome_serv, descricao, preco, id_categoria_fk) values
(null, 'maquiagem social', 'maquiagem para eventos e ocasioes especiais', 150.00, 1),
(null, 'maquiagem noiva', 'maquiagem especial para noivas', 979.99, 1),
(null, 'maquiagem casual', 'maquiagem para o dia a dia', 100.00, 1),
(null, 'maquiagem artistica', 'maquiagem para producoes artisticas', 329.87, 1),

(null, 'limpeza de pele', 'limpeza profunda e cuidados com a pele', 120.00, 2),
(null, 'extensao de cilios', 'aplicacao de extensao de cilios', 180.00, 2),
(null, 'design de sobrancelhas', 'design e modelagem das sobrancelhas', 50.00, 2),
(null, 'peeling', 'procedimento para renovacao da pele', 180.00, 2),

(null, 'corte', 'corte de cabelo', 79.99, 3),
(null, 'penteado', 'penteado para diversas ocasioes', 120.00, 3),
(null, 'hidratacao', 'tratamento de hidratacao capilar', 145.80, 3),
(null, 'escova', 'escova e finalizacao dos cabelos', 60.00, 3),
(null, 'alisamento', 'procedimento de alisamento capilar', 200.00, 3),
(null, 'completo', 'corte, hidratacao e escova', 669.99, 3);

insert into agendamento (id_agend, data_agend, horario_agend, status_agend, id_cliente_fk, id_profissional_fk, id_servico_fk) values
(null,'2026-08-15', '14:00:00', 'agendado', 1, 1, 1),
(null, '2026-08-16', '10:00:00', 'agendado', 2, 2, 9),
(null, '2026-08-17', '15:30:00', 'agendado', 3, 3, 5),
(null, '2026-08-18', '13:00:00', 'agendado', 4, 4, 2),
(null, '2026-08-19', '16:00:00', 'agendado', 5, 5, 11),
(null, '2026-08-20', '09:00:00', 'agendado', 1, 3, 6),
(null, '2026-08-21', '11:30:00', 'agendado', 2, 2, 10),
(null, '2026-08-22', '14:30:00', 'agendado', 3, 1, 3);
