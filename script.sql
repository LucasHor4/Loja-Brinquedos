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

insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('MP-44 Optimus Prime','Descricao Jogo-1',1538.00, 'images/prime.jpeg',1000);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Pelúcia Tralalero Tralala','Tralalero Tralala lalalala',84.99, 'images/trala.jpeg',1000);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Labubu Marrom','É marrom',357.47, 'images/labu.jpeg',1000);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Kit Bobbie Goods','O mãe, compra bobbie goods.',163.00, 'images/bob.jpeg',1000);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Omnitrix Deluxe','A história começou com um relógio esquisito...',269.00, 'images/omni.jpeg',1000);
insert into Produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Estatueta P.E.K.K.A Clash Royale','BUTTERFLY💀',893.00, 'images/pekka.jpeg',1000);