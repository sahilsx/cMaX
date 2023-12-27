create table Users( id int not null primary key identity,
 Username varchar(100) not null,
Email varchar(100) not null unique ,
Password varchar(100) not null,
create_at DATETIME NOT NULL Default current_Timestamp
)
insert into Users(Username ,Email,Password)
values('sahil986','itxsaaho@gmail.com','sahil0983')
select * from Users

