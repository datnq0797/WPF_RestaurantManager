﻿CREATE DATABASE QLNHAHANG
SET DATEFORMAT MDY
USE QLNHAHANG
GO
---CHỨC VỤ
CREATE TABLE [CHUCVU]
(
	[MACV] INT IDENTITY(1,1) ,
	[TENCV] NVARCHAR(200) NOT NULL,
	[PHUCAP] FLOAT,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [CHUCVU] ADD PRIMARY KEY([MACV])
--- LOAI TÀI KHOẢN
CREATE TABLE [LOAITK]
(
	[MALOAITK] INT IDENTITY(1,1),
	[TENLOAITK] NVARCHAR(200) NOT NULL
) 
GO
ALTER TABLE [LOAITK] ADD PRIMARY KEY([MALOAITK])
 ---TÀI KHOẢN
 CREATE TABLE [TAIKHOAN]
 (
	[MATK] INT IDENTITY(1,1) ,
	[USER] VARCHAR(200) NOT NULL,
	[PASS] VARCHAR(200) NOT NULL,
	[MALOAITK] INT NOT NULL,
	[HINHANH] NVARCHAR(200) NULL,
	[TRANGTHAITK] NVARCHAR(200)  NULL
 )
 GO
 ALTER TABLE [TAIKHOAN] ADD PRIMARY KEY([MATK]),
FOREIGN KEY  (MALOAITK) REFERENCES LOAITK(MALOAITK)
GO
 ---NHÂN VIÊN
 CREATE TABLE [NHANVIEN]
 (
	[MANV] INT IDENTITY(1,1) NOT NULL,
	[MACV] INT NOT NULL,
	[MATK] INT NOT NULL,
	[TENNV] NVARCHAR(200) NOT NULL,
	[NGAYSINH] DATETIME NOT NULL,
	[QUEQUAN] NVARCHAR(200) NOT NULL,
	[CMND] VARCHAR(20) NOT NULL,
	[GIOITINH] INT NOT NULL,
	[TTGD] NVARCHAR(200) NOT NULL,
	[HINH_ANH] VARCHAR(200) NOT NULL,
	[SDT] VARCHAR(20) NOT NULL,
	[LUONGCANBAN] FLOAT ,
	[TRANGTHAI] VARCHAR(200)
 )
 GO
ALTER TABLE [NHANVIEN] ADD PRIMARY KEY(MANV),
FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV),
FOREIGN KEY(MATK) REFERENCES TAIKHOAN(MATK)



GO
----PHIEUNHAP
CREATE TABLE [PHIEUNHAP]
(
	[MAPN] INT IDENTITY(1,1) NOT NULL,
	[MANV] INT NOT NULL,
	[NGAYNHAPPHIEU] DATETIME NOT NULL

) 
GO
ALTER TABLE [PHIEUNHAP] ADD PRIMARY KEY(MAPN),
FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

---LOAIMH
CREATE TABLE [LOAIMH]
(
	[MALOAIMH] INT IDENTITY(1,1),
	[TENLOAIMH] NVARCHAR(200) NOT NULL

)
GO
ALTER TABLE [LOAIMH] ADD PRIMARY KEY(MALOAIMH)
GO
---MAT_HANG
CREATE TABLE [MATHANG]
(
	[MAMH] INT IDENTITY(1,1) ,
	[MALOAIMH] INT NOT NULL,
	[TENMH] NVARCHAR(200) NOT NULL,
	[SOLUONG] INT NOT NULL,
	[HANSUDUNG] DATETIME NOT NULL,
	[GIA] FLOAT NOT NULL,
	[DVT] VARCHAR(20) NOT NULL

)
GO
ALTER TABLE [MATHANG] ADD PRIMARY KEY(MAMH),
FOREIGN KEY (MALOAIMH) REFERENCES LOAIMH(MALOAIMH)
GO
---CT_PHIEUNHAP
 CREATE TABLE [CTPHIEUNHAP]
 (
	[MAPN] INT NOT NULL,
	[MAMH] INT NOT NULL,
	[SLNHAP] INT NOT NULL,
 )
 GO
 ALTER TABLE [CTPHIEUNHAP] ADD PRIMARY KEY(MAPN,MAMH),
 FOREIGN KEY (MAPN) REFERENCES PHIEUNHAP(MAPN),
 FOREIGN KEY(MAMH) REFERENCES MATHANG(MAMH)
 
 GO
 ---KHUYEN MAI
 CREATE TABLE [KHUYENMAI]
 (
	[MAKM] INT IDENTITY(1,1) ,
	[TENCT] NVARCHAR(200) NOT NULL,
	[CHIETKHAU] INT NOT NULL,
	[TGBATDAU] DATETIME NOT NULL,
	[TGKETTHUC] DATETIME NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
 )
GO 
ALTER TABLE [KHUYENMAI] ADD PRIMARY KEY(MAKM)
GO
---LOAI MON AN
CREATE TABLE [LOAIMONAN]
(
	[MALOAIMONAN] VARCHAR(20) NOT NULL,
	[TENLOAIMONAN] NVARCHAR(200) NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [LOAIMONAN] ADD PRIMARY KEY(MALOAIMONAN)
GO
---BAN AN
CREATE TABLE [BANAN]
(
	[SOBAN] INT IDENTITY(1,1) NOT NULL,
	[LOAIBAN] VARCHAR(20) NOT NULL
)
GO
ALTER TABLE [BANAN] ADD PRIMARY KEY([SOBAN])
GO
---MENU
CREATE TABLE [MENU]
(
	[MAMONAN] INT IDENTITY(1,1),
	[MALOAIMONAN] VARCHAR(20) NOT NULL,
	[MAKM] INT NULL,
	[TENMONAN] NVARCHAR(200) NOT NULL,
	[GIABAN] FLOAT NOT NULL,
	[HINH_MONAN] VARCHAR(200) NOT NULL,
	[DVT] VARCHAR(20) NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [MENU] ADD PRIMARY KEY(MAMONAN),
FOREIGN KEY(MALOAIMONAN) REFERENCES LOAIMONAN(MALOAIMONAN),
FOREIGN KEY(MAKM) REFERENCES KHUYENMAI(MAKM)
GO
---LOAIKH
CREATE TABLE [LOAIKH]
(
	[MALOAIKH] VARCHAR(20) NOT NULL,
	[TENLOAIKH] NVARCHAR(200) NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [LOAIKH] ADD PRIMARY KEY(MALOAIKH)
GO
---KHACH HANG
CREATE TABLE [KHACHHANG]
(
	[MAKH] INT IDENTITY(1,1) ,
	[MALOAIKH] VARCHAR(20) NOT NULL,
	[TENKH] NVARCHAR(200) NOT NULL,
	[QUEQUAN] NVARCHAR(200) NOT NULL,
	[CMND] VARCHAR(20) NOT NULL,
	[SDT] VARCHAR(20) NOT NULL,
	[GIOITINH] INT NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [KHACHHANG]  ADD  PRIMARY KEY(MAKH),
FOREIGN KEY(MALOAIKH) REFERENCES LOAIKH(MALOAIKH)
GO
---ORDER 
CREATE TABLE [ORDER]
(
	[MAOD] INT IDENTITY(1,1),
	[SOTIENDAT] FLOAT NULL,
	[NGAYDAT] DATETIME NOT NULL,
	[SOKHACH] INT NOT NULL,
	[MANV] INT NOT  NULL,
	[MAKH] INT NOT NULL,
	[TRANGTHAI] NVARCHAR(200) NULL
)
GO
ALTER TABLE [ORDER] ADD PRIMARY KEY(MAOD),
FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)
GO
---CT_ORDER
CREATE TABLE [CHITIETORDER]
(
	[MAMONAN] INT  NOT NULL,
	[MAOD] INT NOT NULL,
	[SOLUONG] INT
) 
GO
ALTER TABLE [CHITIETORDER] ADD PRIMARY KEY(MAMONAN,MAOD),
FOREIGN KEY(MAMONAN) REFERENCES MENU(MAMONAN),
FOREIGN KEY(MAOD) REFERENCES [ORDER](MAOD)
GO
---BILL 
CREATE TABLE [BILL]
(
	[MABILL] INT IDENTITY(1,1),
	[MAKH] INT NOT NULL,
	[SOBAN] INT NOT NULL,
	[MANV] INT NOT NULL,
	[MAOD] INT NOT NULL,
	[SOLUONGKHACH] INT NOT NULL,
	[CHECKIN] DATETIME NOT NULL,
	[CHECKOUT] DATETIME NOT NULL
	 
)
GO 
ALTER TABLE BILL ADD PRIMARY KEY(MABILL),
FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH),
FOREIGN KEY(SOBAN) REFERENCES BANAN(SOBAN),
FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
FOREIGN KEY(MAOD) REFERENCES [ORDER](MAOD)

----DROP TABLE
DROP TABLE CTPHIEUNHAP
DROP TABLE MATHANG 
DROP TABLE LOAIMH
DROP TABLE PHIEUNHAP
DROP TABLE CHITIETORDER
DROP TABLE MENU
DROP TABLE KHUYENMAI
DROP TABLE BILL
DROP TABLE BANAN 
DROP TABLE [ORDER]
DROP TABLE NHANVIEN
DROP TABLE KHACHHANG
DROP TABLE LOAIKH
DROP TABLE CHUCVU
DROP TABLE TAIKHOAN
DROP TABLE LOAIMONAN
DROP TABLE LOAITK

--------NHẬP LIỆU
--- CHỨC VỤ
INSERT INTO CHUCVU VALUES(N'Quản lý',500.000,null)--1
INSERT INTO CHUCVU VALUES(N'Tiếp thực',200.000,null)--2
INSERT INTO CHUCVU VALUES(N'Phục vụ',200.000,null)--3
INSERT INTO CHUCVU VALUES(N'Kế toán',300.000,null)--4
INSERT INTO CHUCVU VALUES(N'Đầu bếp',300.000,null)--5
--- LOẠI TÀI KHOẢN
INSERT INTO LOAITK VALUES(N'ADMIN')
INSERT INTO LOAITK VALUES(N'USER')
--- TÀI KHOẢN
INSERT INTO TAIKHOAN VALUES('QUANLY','1234',1,null,NULL)
INSERT INTO TAIKHOAN VALUES('NVKETOAN','4321',2,null,null)
INSERT INTO TAIKHOAN VALUES('DAT','5678',2,null,null)
--- NHÂN VIÊN
INSERT INTO NHANVIEN VALUES('1','3',N'NGUYỄN QUỐC ĐẠT','6/7/1997',N'TPHCM','123456789',1,N'ĐỘC THÂN','DASDADA','0779878661',10000000,null)
INSERT INTO NHANVIEN VALUES('2','3',N'NGÔ TẤN TÀI','5/6/2000',N'TPHCM','65432134',1,N'ĐỘC THÂN','ASDSA','01229878661',20000000,null)
INSERT INTO NHANVIEN VALUES('3','2',N'NGUYÊN THỊ B','7/6/1998',N'HẢI PHÒNG','0987654321',0,N'ĐÃ CÓ GIA ĐÌNH','12313','5390822',5000000,null)
-- LOẠI MẶT HÀNG
INSERT INTO LOAIMH VALUES(N'HÓA CHẤT TẨY RỬA')--1
INSERT INTO LOAIMH VALUES(N'THỰC PHẨM ĐÔNG LẠNH')--2
INSERT INTO LOAIMH VALUES(N'THỰC PHẨM ĐÓNG HỘP')--3
INSERT INTO LOAIMH VALUES(N'NGUYÊN LIỆU KHÔ')--4
INSERT INTO LOAIMH VALUES(N'CÁC LOẠI THỊT')--5
INSERT INTO LOAIMH VALUES(N'THỨC UỐNG')--6
--- MẶT HÀNG
INSERT INTO MATHANG VALUES(1,N'TẨY RỬA SÀN B1',3,'30/4/2022',150000,'THUNG')
INSERT INTO MATHANG VALUES(1,N'TẨY RỈ SÉT G2',6,'30/4/2022',200000,'THUNG')
INSERT INTO MATHANG VALUES(5,N'THỊT GÀ',3,'30/3/2021',500000,'KG')
INSERT INTO MATHANG VALUES(6,N'COCA',3,'30/4/2022',250000,'THUNG')
INSERT INTO MATHANG VALUES(2,N'KEM VANI',3,'30/4/2021',300000,'HOP')

---PHIẾU NHẬP
INSERT INTO PHIEUNHAP VALUES(1,'23/3/2021')
INSERT INTO PHIEUNHAP VALUES(2,'25/3/2021')

---CHI TIẾT PHIẾU NHẬP
INSERT INTO CTPHIEUNHAP VALUES(1,6,4)
INSERT INTO CTPHIEUNHAP VALUES(1,7,5)
INSERT INTO CTPHIEUNHAP VALUES(1,8,2)
INSERT INTO CTPHIEUNHAP VALUES(2,9,10)
INSERT INTO CTPHIEUNHAP VALUES(2,10,11)
INSERT INTO CTPHIEUNHAP VALUES(2,9,12)

---KHUYẾN MÃI
INSERT INTO KHUYENMAI VALUES(N'BẢO NGỌC LƯU XUÂN',20,'2/2/2021','30/4/2021',null)
INSERT INTO KHUYENMAI VALUES(N'MỪNG NGÀY 8/3',30,'1/3/2021','10/3/2021',null)

---LOẠI MÓN ĂN 
INSERT INTO LOAIMONAN VALUES('TM',N'TRÁNG MIỆNG',null)
INSERT INTO LOAIMONAN VALUES('MC',N'MÓN CHÍNH',null)
INSERT INTO LOAIMONAN VALUES('KV',N'KHAI VỊ',null)
INSERT INTO LOAIMONAN VALUES('ALC',N'THỨC UỐNG CÓ CỒN',null)

---MENU
INSERT INTO MENU VALUES('TM',NULL,N'KEM KIWI DÂU',50000,'123','DIA',null)
INSERT INTO MENU VALUES('TM',NULL,N'BÁNH KEM DÂU CHOCOLATE',50000,'123','DIA',null)
INSERT INTO MENU VALUES('TM',NULL,N'BÁNH KHÚC CÂY GIÁNG SINH',80000,'123','DIA',null)
INSERT INTO MENU VALUES('TM',NULL,N'BÁNH QUY DỨA HOA TULIP',90000,'123','DIA',null)
INSERT INTO MENU VALUES('MC',1,N'SÚP CUA BẮP MỸ, GÀ XÉ, NẤM HƯƠNG',900000,'123','NOI',null)
INSERT INTO MENU VALUES('MC',1,N'CÁ PHILE SỐT CHANH DÂY',700000,'123','DIA',null)
INSERT INTO MENU VALUES('MC',NULL,N'SƯỜN HẦM TIÊU XANH- BÁNH MÌ',500000,'123','DIA',null)
INSERT INTO MENU VALUES('MC',NULL,N'CƠM CHIÊN HẢI SẢN',600000,'123','DIA',null)
INSERT INTO MENU VALUES('KV',2,N'GỎI CỦ HỦ DỪA',200000,'123','DIA',null)
INSERT INTO MENU VALUES('KV',2,N'SƯỜN KINH ĐÔ',300000,'123','DIA',null)

---LOẠI KHÁCH HÀNG
INSERT INTO LOAIKH VALUES('VIP',N'KHÁCH VIP',null)
INSERT INTO LOAIKH VALUES('NOR',N'KHÁCH THƯỜNG',null)
---KHÁCH HÀNG
INSERT INTO KHACHHANG VALUES('VIP',N'ĐÀO NGỌC TÂN',N'HẢI DƯƠNG','12314314','0779878661',1,null)
INSERT INTO KHACHHANG VALUES('NOR',N'TRẦN VĂN C',N'TPHCM','00000000','6758930212',0,null)

---ORDER
INSERT INTO [ORDER] VALUES(5000000,'23/3/2021',12,1,1,'HIEN')
INSERT INTO [ORDER] VALUES(NULL,'24/3/2021',5,2,2,'HIEN')

---CHI TIẾT ORDER
INSERT INTO CHITIETORDER VALUES(5,2,2)
INSERT INTO CHITIETORDER VALUES(9,2,2)
INSERT INTO CHITIETORDER VALUES(1,3,1)
INSERT INTO CHITIETORDER VALUES(2,3,1)

---BÀN ĂN
INSERT INTO BANAN VALUES('VIP')
INSERT INTO BANAN VALUES('THUONG')

---BILL
INSERT INTO BILL VALUES(2,1,1,2,12,'23/3/2021','23/3/2021')



-------------------------------------------------------------------------------------
//--------số lượng món ăn bán được của từng món
CREATE PROC SOLUONG_MONAN (@MONTH INT)
AS
BEGIN
	SELECT MENU.TENMONAN,SUM(SOLUONG) AS SOLUONG
	FROM MENU,CHITIETORDER,[ORDER]
	WHERE MENU.MAMONAN = CHITIETORDER.MAMONAN AND MONTH(NGAYDAT) = @MONTH
	GROUP BY MENU.TENMONAN
END

EXEC SOLUONG_MONAN 3


-----best staff
CREATE PROC BESTSTAFF(@MONTH INT)
AS
BEGIN 
	
		SELECT NHANVIEN.MANV,NHANVIEN.TENNV,HINH_ANH,COUNT(MAMONAN) AS SOLUONGMON
		FROM CHITIETORDER,[ORDER],NHANVIEN
		WHERE [ORDER].MAOD = CHITIETORDER.MAOD AND NHANVIEN.MANV = [ORDER].MANV AND MONTH(NGAYDAT) = @MONTH
		GROUP BY NHANVIEN.MANV,NHANVIEN.TENNV,HINH_ANH
		ORDER BY COUNT(MAMONAN) DESC
	
END

----doanh thu tháng
CREATE PROC DOANHTHU
AS
BEGIN 
	
		SELECT SUM(SOLUONG*GIABAN) AS DOANHSO
		FROM CHITIETORDER,MENU,KHUYENMAI
		WHERE CHITIETORDER.MAMONAN = MENU.MAMONAN AND KHUYENMAI.MAKM = MENU.MAKM
END


----HÀNG TỒN ,NHẬP
CREATE VIEW HANG_TON_NHAP
AS
	SELECT MH.MAMH,MH.TENMH,SOLUONG,SLNHAP
	FROM CTPHIEUNHAP CT,MATHANG MH
	WHERE CT.MAMH = MH.MAMH
	GROUP BY MH.MAMH,MH.TENMH,SOLUONG,SLNHAP

------TOTAL
ALTER proc total (@maod int)
as 
begin
IF CHIETKHAU = NULL
BEGIN
	select TENMONAN,SOLUONG*GIABAN AS TOTAL
	from CHITIETORDER CT,MENU MN,KHUYENMAI KM
	where  CT.MAMONAN = MN.MAMONAN AND MAOD = 3
	GROUP BY TENMONAN,SOLUONG*GIABAN
	 
END
ELSE
BEGIN
	select   TENMONAN,GIABAN-(CHIETKHAU*(SOLUONG*GIABAN)/100) AS TOTAL
	from CHITIETORDER CT,MENU MN,KHUYENMAI KM
	where  CT.MAMONAN = MN.MAMONAN AND MN.MAKM = KM.MAKM AND MAOD = 3
	GROUP BY TENMONAN,GIABAN-(CHIETKHAU*(SOLUONG*GIABAN)/100)
	END
end


-----lấy số lượng món ăn theo loại.
CREATE VIEW SOLUONGMON_THEOLOAI
AS
	SELECT TENLOAIMONAN,COUNT(MAMONAN) AS SOLUONGMON
	FROM LOAIMONAN,MENU
	WHERE MENU.MALOAIMONAN = LOAIMONAN.MALOAIMONAN
	GROUP BY TENLOAIMONAN
