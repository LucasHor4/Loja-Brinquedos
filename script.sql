-- criando banco de dados
-- drop database EcomLoja;
create database EcomLoja;

-- usanado EcomLoja

use EcomLoja;

-- criando tabelas

create table Produto(
id int primary key auto_increment,
Nome varchar(40),
Preco decimal(10.2),
Descricao varchar(100),
ImageUrl varchar(255),
Estoque int
);

create table pedido(
Id int primary key auto_increment ,
DataPedido datetime,
Total decimal(10,2),
Status varchar(50),
Endereco varchar(100),
FormaPagamento varchar(100),
Frete decimal (10,2)
);

create table itemPedido(
Id int primary key auto_increment ,
PedidoId int,
ProdutoId int,
Quantidade int,
PrecoUnitario decimal(10,2)
);

-- CONSULTANDO AS TABELAS DO BANCO

select * from produto;
select * from pedido;
select * from itemPedido;

insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('J','Descricao Jogo-1',150.00, 'images/jogo1.jpg',10);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('RRR','Roleta russa, remix',550.00, 'images/jogo2.jpg',100);