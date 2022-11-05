use master
drop database if exists TesteCreditoDB;
create database TesteCreditoDB;


go

use TesteCreditoDB

go

drop table if exists Cliente;
create table Cliente(
	clienteId uniqueidentifier not null default newsequentialid(),
	cpf varchar(11) not null,
	nome varchar(100) not null,
	uf varchar(2) not null,
	celular varchar(11) not null,
	constraint PK_ClienteId primary key nonclustered(clienteId),
	constraint UK_CPF unique (cpf)
)

go

drop table if exists Financiamento;
create table Financiamento(
	financiamentoId uniqueidentifier not null default newsequentialid(),
	clienteId uniqueidentifier not null,
	tipoFinanciamneto int not null,
	valorTotal decimal(20,2) not null,
	dataUltimoVencimento date not null,
	constraint PK_FinanciamentoId primary key nonclustered(financiamentoId),
	constraint FK_ClienteId foreign key (clienteId) references Cliente(clienteId)
)

go

drop table if exists Parcela;
create table Parcela(
	financiamentoId uniqueidentifier not null,
	numeroParcela int not null,
	valorParcela decimal(20,2) not null,
	dataVencimento date not null,
	dataPagamento date null,
	constraint PK_ParcelaId primary key nonclustered(financiamentoId, numeroParcela),
	constraint FK_FinanciamentoId foreign key (financiamentoId) references Financiamento(financiamentoId)
)

go

drop table if exists #tempCliente;
drop table if exists #tempFinanciamento;

create table #tempCliente(id uniqueIdentifier);
create table #tempFinanciamento(id uniqueIdentifier);

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('12345678909', 'Juca Chaves', 'SP', '11999991234');

declare @cliId uniqueidentifier;
select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 150000.00, '2022-10-05')

declare @finId uniqueidentifier;
select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 30000.00, '2022-08-05', '2022-08-03')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 2, 30000.00, '2022-09-05', '2022-09-05')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 3, 30000.00, '2022-10-05', '2022-10-04')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 4, 30000.00, '2022-11-05', null)
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 5, 30000.00, '2022-12-05', null)



insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('98765432109', 'Carlos Rosa', 'SP', '11988884321');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 200000.00, '2022-10-16')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 40000.00, '2022-09-16', '2022-09-12')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 2, 40000.00, '2022-10-16', '2022-10-09')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 3, 40000.00, '2022-11-16', null)
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 4, 40000.00, '2022-12-16', null)
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 5, 40000.00, '2023-01-16', null)


insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('11122233345', 'Maria das Graças', 'MG', '31977779876');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 250000.00, '2022-10-10')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 50000.00, '2022-08-10', '2022-08-08')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 2, 50000.00, '2022-09-10', '2022-09-10')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 3, 50000.00, '2022-10-10', '2022-10-10')
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 4, 50000.00, '2022-11-10', null)
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 5, 50000.00, '2022-12-10', null)


insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('99988877767', 'Michael Jackson', 'BA', '71999990045');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 250000.00, '2022-10-25')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 125000.00, '2022-10-25', null)
insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 2, 125000.00, '2022-11-25', null)

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('22222222222', 'Carlos Manuel', 'SP', '11999990090');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 125000.00, '2022-10-22')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 125000.00, '2022-10-22', null)

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('33333333333', 'Miguel da Silva', 'SP', '11999990080');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 1250000.00, '2022-10-23')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 1250000.00, '2022-10-23', null)

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('44444444444', 'Ana Silvia', 'SP', '11999990070');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 30000.00, '2022-10-22')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 30000.00, '2022-10-22', null)

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('55555555555', 'Jaqueline Medeiros', 'SP', '11999990040');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 32000.00, '2022-10-20')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 32000.00, '2022-10-20', null)

insert into Cliente (cpf, nome, uf, celular)
output inserted.clienteId into #tempCliente
values ('66666666666', 'Soraia de Albuquerque', 'SP', '11999990050');

select @cliId = id from #tempCliente
delete from #tempCliente

insert into Financiamento(clienteId, tipoFinanciamneto, valorTotal, dataUltimoVencimento)
output inserted.financiamentoId into #tempFinanciamento
values (@cliId, 0, 22000.00, '2022-10-15')

select @finId = id from #tempFinanciamento
delete from #tempFinanciamento

insert into Parcela(financiamentoId, numeroParcela, valorParcela, dataVencimento, dataPagamento)
values (@finId, 1, 22000.00, '2022-10-15', null)

drop table #tempCliente
drop table #tempFinanciamento
go


--Item 2 - Listar todos os clientes do estado de SP que possuem mais de 60% das parcelas pagas;
with Resultado as (
select c.clienteId, c.nome, c.cpf, c.uf, c.celular, p1.financiamentoId
	, count(p1.financiamentoId) as quantidadeParcelas
from Cliente as c
inner join Financiamento as f
	on c.clienteId = f.clienteId
inner join Parcela as p1
	on f.financiamentoId = p1.financiamentoId
where c.uf = 'sp'
group by c.clienteId, c.nome, c.cpf, c.uf, c.celular, p1.financiamentoId
)
select r.clienteId, r.cpf, r.nome, r.celular
from Resultado as r
inner join Parcela p
	on p.financiamentoId = r.financiamentoId
where quantidadeParcelas*0.6 > (select count(*) from Parcela where financiamentoId = r.financiamentoId and dataPagamento is not null)
group by r.clienteId, r.cpf, r.nome, r.celular
having count(p.financiamentoId) > 1

--Item 2 - Listar os primeiros quatro clientes que possuem alguma parcela com mais de cinco dias
--         em atraso (Data Vencimento maior que data atual E data pagamento nula).
select top 4 c.*
from Cliente as c
inner join Financiamento as f
	on c.clienteId = f.clienteId
inner join Parcela as p
	on f.financiamentoId = p.financiamentoId
where dataPagamento is null and DATEDIFF(day, dataVencimento,  getdate()) > 5


