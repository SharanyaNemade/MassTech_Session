create database Masstech_Team3;

use Masstech_Team3;


create table Users
(
id int identity primary key,
email varchar(100),
username varchar(100),
password varchar(100),
role varchar(100)
);


select * from Users;




CREATE PROCEDURE sp_SaveUsers
    @email VARCHAR(100),
    @username VARCHAR(100),
    @password VARCHAR(100),
    @role VARCHAR(100)
AS
BEGIN
	insert into users(email, username,password,role)
	values(@email,@username,@password,@role)
END



CREATE PROCEDURE sp_Login
	@str varchar(100),
	@pass varchar(100)
as
begin
	select * from users where (username=@str OR email=@str) AND password=@pass;
END



--insert into(id,email,username,password,role)
--VALUES(1)