CREATE DATABASE QLNhanVien;

CREATE TABLE Dangnhap(
    TaiKhoan CHAR(255),
    MatKhau CHAR(255),
	IDper int
)

insert into Dangnhap values('thanhqui', '123456',1)
insert into Dangnhap values('camtien', '12345',0)
insert into Dangnhap values('admin', '1234567',1)

select * from Dangnhap

drop table Dangnhap

create proc [dbo].[SP_AuthoLogin]
@Username nvarchar(20),
@Password nvarchar(20)
as
begin
    if exists (select * from Dangnhap where TaiKhoan = @Username and MatKhau = @Password and IDPer = 1)
        select 1 as code
    else if exists (select * from Dangnhap where TaiKhoan = @Username and MatKhau = @Password and IDPer = 0)
        select 0 as code
    else if exists(select * from Dangnhap where TaiKhoan = @Username and MatKhau != @Password) 
        select 2 as code
    else select 3 as code
end

DROP PROCEDURE [dbo].[SP_AuthoLogin];
GO

create proc [dbo].[SP_Suasanpham]

@ItemID char(50),
@ItemName char(50),
@Mobile char(50)
as
begin
    update Student set
    Name = @Ten,
    Email = @Email,
    Mobile = @Mobile
    where Id = @MaHS
end