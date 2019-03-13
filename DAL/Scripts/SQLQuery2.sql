CREATE DATABASE PrimerParcialApIIDb
go
Use PrimerParcialApIIDb
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

create table Prestamos
(
	PrestamosId int primary key identity(1,1),
	Fecha Date,
	CuentaId int not null,
	Capital money,
	Interes float,
	Tiempo int,
	Total float
);

create table Cuotas
(
	Id int primary key identity(1,1),
	NoCuotas int,
	PrestamosId int not null,
	Interes float,
	Capital money,
	MontoPorCuota money,
	Balance money

);

select * from Cuentas;
select * from Depositos;	
select * from Prestamos;	
select * from Cuotas;	