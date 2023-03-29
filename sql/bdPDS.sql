create database app_contato_bd;
Use app_contato_bd; 

create table contato (
id_con int not null auto_increment primary key,
nome_con varchar(200) not null,
data_nasc_con date not null,
sexo_con varchar(30),
email_con varchar(200),
telefone_con varchar(200)
);

insert into contato values (null, 'Bel Supple', '2022-11-19', 'Female', 'bsupple0@ebay.com', '909-659-8325');


