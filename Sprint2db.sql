

create table Customer
(
Customer_Id varchar(10) primary key,
Customer_Name varchar(20) not null,
Customer_Address varchar(20) not null,
Customer_Email varchar(20) unique not null,
Customer_Password varchar(20) not null,
Customer_Contact char(10) not null,
Customer_RegistationDate date ,
Customer_Role varchar(20) not null,
)

create table Recipe
(
Recipe_Id varchar(10) primary key,
Recipe_Name varchar(20) unique not null,
Recipe_Description varchar(100) not null,
Recipe_Stock varchar(20) not null,
Recipe_Price decimal not null,
)

create table ShoppingCart
(
ShoppingCart_Id varchar(10) primary key,
Customer_Id varchar(10) foreign key references Customer(Customer_Id),
Recipe_Id varchar(10) foreign key references Recipe(Recipe_Id)
)


create table Orders
(
Order_Id varchar(10) primary key,
ShoppingCart_Id varchar(10) foreign key references shoppingcart(Shoppingcart_Id),
Customer_Id varchar(10) foreign key references Customer(Customer_Id),
Recipe_Id varchar(10) foreign key references Recipe(Recipe_Id),
Order_Date date
)

create table Shipping
(
Shipping_Id varchar(10) primary key,
Order_Id varchar(10) foreign key references orders(order_id),
Customer_Id varchar(10) foreign key references customer(Customer_id),
Shipping_Date date
)
insert into Customer values('C100','Rahul','Bangalore','Rahul@gmail.com','Rahul@123','9878987','06-04-2021','customer')
insert into Customer values('C111','Ram','Bangalore','Ram@gmail.com','Ram@123','9878987','06-04-2021','customer')

select * from recipe
select * from customer
select * from ShoppingCart
select * from orders
select * from shipping



drop table Shipping
drop table Orders
drop table ShoppingCart
drop table Customer





