create database MP3
go
use MP3
go
create table TheLoai
(
maloai int identity primary key,
tenloai nvarchar(30)
)
go
create table CaSi
(
id int identity(1,1) primary key,
maloai int references TheLoai(maloai),
ten nvarchar(100) not null,
namsinh int,
nghenghiep nvarchar(100)
)
go
create table BaiHat
(
idBaiHat int identity(1,1) primary key,
id int references CaSi(id),
maloai int references TheLoai(maloai),
tenBai nvarchar(100) not null,
ngaysx smalldatetime,
dungluong int,
luutru nvarchar(200) not null,
data varbinary(MAX)

)
go
