create database PrimerParcialAP2
go
use PrimerParcialAP2
go

create table Cuentas(
CuentaId int identity primary  key not null,
Fecha date,
Nombre varchar(20),
Balance money
);

go

create table Depositos(
DepositoId int identity primary key not null,
Fecha date,
CuentaId int not null,
Concepto varchar(max),
Monto money
);

select * from Cuentas
select * from Depositos
