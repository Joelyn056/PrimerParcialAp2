CREATE DATABASE PrimerParcialAp2Db
go
Use PrimerParcialAp2Db
go

create table Cuentas 
(
	CuentaId int primary key identity(1,1),
	Fecha Date,
	Nombre varchar(50),
	Balance money
);

go
create table Depositos
(
	DepositoId int primary key identity(1,1),
	Fecha Date,
	Nombre varchar(30),
	CuentaId int references Cuentas(CuentaId),
	Concepto varchar(50),
	Monto money

);


select * from Cuentas;
select * from Depositos;