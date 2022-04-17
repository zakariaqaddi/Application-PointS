create database callCenterApp;
use callCenterApp;
create table client(
	numTel varchar(30) primary key,
    firstName varchar(30),
    lastName varchar(30)
);
insert into client values ("0688911992", "mohamed", "Zahi");
insert into client values ("068899332244", "Ahmed", "Alaoui");
insert into client values ("0622198527", "Ali", "Idrissi");