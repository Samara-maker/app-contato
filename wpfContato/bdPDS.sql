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

insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (1, 'Bel Supple', '2022-11-19', 'Female', 'bsupple0@ebay.com', '909-659-8325');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (2, 'Shena Torresi', '2022-03-15', 'Female', 'storresi1@blogtalkradio.com', '900-455-1862');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (3, 'Robinett Lendrem', '2022-05-17', 'Genderqueer', 'rlendrem2@kickstarter.com', '877-415-8800');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (4, 'Sollie Jaycox', '2022-11-11', 'Male', 'sjaycox3@51.la', '646-628-3055');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (5, 'Alic Arnaldi', '2022-06-21', 'Male', 'aarnaldi4@weather.com', '362-107-9204');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (6, 'Agnes Issacson', '2022-08-28', 'Female', 'aissacson5@wordpress.org', '591-224-2817');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (7, 'Jeannine Earles', '2022-04-23', 'Female', 'jearles6@ucla.edu', '998-237-6597');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (8, 'Querida Servis', '2023-02-16', 'Female', 'qservis7@businessinsider.com', '917-644-3700');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (9, 'Honey Jorden', '2022-04-06', 'Female', 'hjorden8@ca.gov', '757-132-1564');
insert into contato (id_con, nome_con , data_nasc_con, sexo_con, email_con, telefone_con) values (10, 'Herbie Simion', '2022-10-13', 'Male', 'hsimion9@mtv.com', '651-737-7539');

select*from contato;