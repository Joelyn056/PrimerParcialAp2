CREATE DATABASE PrimerParcialAp2Db
go
Use PrimerParcialAp2Db
go

create table Cuentas 
(
	CuentaId int primary key identity(1,1),
	Fecha Date,
	Nombre varchar(20),
	Balance money
);

go
create table Depositos
(
	DepositoId int primary key identity(1,1),
	Fecha Date,
	Nombre varchar(30),
	CuentaId int not null,
	Concepto varchar(max),
	Monto money

);


select * from Cuentas;
select * from Depositos;	