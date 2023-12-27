create table members(
Id int not null primary key identity,
Member_Name varchar(100) not null,
Membership varchar(100) not null  ,
Membership_Duration varchar(100) not null,
JOINED_on DATETIME NOT NULL Default current_Timestamp)
insert into members(Member_Name ,Membership,Membership_Duration)
values('sahil','basic','3 months')
select * from members
