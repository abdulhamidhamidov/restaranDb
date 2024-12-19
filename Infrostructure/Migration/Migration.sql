Create TABLE Customers
(
    Id serial primary key ,
    Name varchar(50), 
    PhoneNumber varchar(50) unique 
);

create table Tables
(
    Id serial primary key ,
    TableNumber int unique check (TableNumber>0),
    IsOccupied boolean 
);

create table MenuItems
(
    Id serial primary key ,
    Name varchar(50),
    Price decimal,
    Category varchar(50) 
);
create table Orders
(
    Id serial primary key ,
CustomerId int references Customers(Id) on delete cascade ,
TableId int references Tables(Id) on delete cascade ,
Status varchar(50) 
);

insert into Customers(Name, PhoneNumber) values (@Name,@PhoneNumber);
select * from Customers;
select * from Customers where PhoneNumber=@PhoneNumber;
insert into  MenuItems (Name, Price, Category) values (@Name, @Price, @Category);
select * from MenuItems;


insert into Orders( CustomerId, TableId, Status) values ( @CustomerId, @TableId, @Status);
update Orders set  CustomerId=@CustomerId, TableId=@TableId, Status=@Status WHERE Id=@Id;
SELECT * FROM Orders


select * from Customers where Name=@Name;
select * from Orders o where o.CustomerId=@CustomerId;
select * from Tables where IsOccupied=true;
update Orders SET Status='под ремонт' WHERE CustomerId=@CustomerId;

select Sum() from Customers

                      
                      