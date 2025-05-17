IF EXISTS (  
    SELECT name  
    FROM sys.databases  
    WHERE name = 'QuanLyCCCD'  
)  
BEGIN  
    USE master
    ALTER DATABASE QuanLyCCCD SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyCCCD;
END  
GO

CREATE DATABASE QuanLyCCCD;
GO

USE QuanLyCCCD;
GO

-- Tạo bảng CongDanCCCD (gộp CongDan và CCCD)
CREATE TABLE CongDanCCCD (
    soCCCD VARCHAR(12) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    ngaySinh DATE NOT NULL,
    gioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    queQuan NVARCHAR(50),
    noiO NVARCHAR(50),
    ngayCap DATE NOT NULL,
    noiCap NVARCHAR(100) NOT NULL,

);
GO

-- Tạo bảng GiayToLienQuan với cột ChiTiet mới
CREATE TABLE GiayToLienQuan (
    soGiayTo NVARCHAR(50) PRIMARY KEY,
    soCCCD VARCHAR(12) NOT NULL,
    loaiGiayTo NVARCHAR(50) NOT NULL,
    ngayCap DATE NOT NULL,
    noiCap NVARCHAR(100) NOT NULL,
    ngayHetHan DATE,
    chiTiet NVARCHAR(200), -- Cột mới để lưu thông tin bổ sung
    CHECK (NgayHetHan IS NULL OR NgayHetHan > NgayCap),
    FOREIGN KEY (SoCCCD) REFERENCES CongDanCCCD(SoCCCD) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE SaiPham (
    maSaiPham CHAR(10) PRIMARY KEY,
    SoCCCD VARCHAR(12) NOT NULL,
    loiSaiPham NVARCHAR(200) NOT NULL,
    ngaySai DATE NOT NULL,
    noiSaiPham NVARCHAR(100),
    mucPhat MONEY,
    trangThai NVARCHAR(50) ,
    FOREIGN KEY (SoCCCD) REFERENCES CongDanCCCD(SoCCCD) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
-- Thêm dữ liệu mẫu vào bảng CongDanCCCD
INSERT INTO CongDanCCCD (SoCCCD, HoTen, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, NoiO, NgayCap, NoiCap)
VALUES 
    ('123456789001', N'Nguyễn Văn An', '1990-01-15', N'Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', '2020-01-01', N'Cục QLDC Hà Nội'),
    ('123456789002', N'Trần Thị Bình', '1992-05-20', N'Nữ', N'Kinh', N'Phật giáo', N'TP.HCM', N'TP.HCM', '2021-02-10', N'Cục QLDC TP.HCM'),
    ('123456789003', N'Phạm Quốc Cường', '1985-03-10', N'Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', '2019-11-05', N'Cục QLDC Đà Nẵng'),
    ('123456789004', N'Lê Thị Dung', '1995-07-12', N'Nữ', N'Kinh', N'Thiên chúa', N'Hà Nội', N'Hà Nội', '2020-07-01', N'Cục QLDC Hà Nội'),
    ('123456789005', N'Hoàng Văn Em', '1988-08-08', N'Nam', N'Kinh', N'Không', N'TP.HCM', N'TP.HCM', '2021-01-01', N'Cục QLDC TP.HCM'),
    ('123456789006', N'Võ Thị Hoa', '1993-12-25', N'Nữ', N'Kinh', N'Không', N'Cần Thơ', N'Cần Thơ', '2022-05-20', N'Cục QLDC Cần Thơ'),
    ('123456789007', N'Đặng Văn Khoa', '1991-09-30', N'Nam', N'Kinh', N'Không', N'Hải Phòng', N'Hải Phòng', '2020-03-10', N'Cục QLDC Hải Phòng'),
    ('123456789008', N'Ngô Thị Lan', '1987-06-15', N'Nữ', N'Kinh', N'Không', N'Nghệ An', N'Nghệ An', '2019-08-01', N'Cục QLDC Nghệ An'),
    ('123456789009', N'Bùi Minh Long', '1990-04-01', N'Nam', N'Kinh', N'Không', N'Đồng Nai', N'Đồng Nai', '2021-09-25', N'Cục QLDC Đồng Nai'),
    ('123456789010', N'Dương Thị Mai', '1994-11-11', N'Nữ', N'Kinh', N'Không', N'Bình Dương', N'Bình Dương', '2022-01-18', N'Cục QLDC Bình Dương');
GO

  
go
-- Thêm dữ liệu mẫu vào bảng GiayToLienQuan
INSERT INTO GiayToLienQuan (SoGiayTo, SoCCCD, LoaiGiayTo, NgayCap, NoiCap, NgayHetHan, ChiTiet)
VALUES 
    ('BHYT001', '123456789001', N'Bảo Hiểm Y Tế', '2022-01-01', N'Hà Nội', '2025-01-01', N'Nơi ĐK KCB: BV Bạch Mai'),
    ('BLX001', '123456789001', N'Bằng Lái Xe', '2023-06-01', N'Hà Nội', '2028-06-01', N'Hạng A1 - Xe Mô Tô'),
    ('BHYT002', '123456789002', N'Bảo Hiểm Y Tế', '2021-05-10', N'TP.HCM', '2024-05-10', N'Nơi ĐK KCB: BV Chợ Rẫy'),
    ('GPLX002', '123456789002', N'Bằng Lái Xe', '2023-07-01', N'TP.HCM', '2028-07-01', N'Hạng B2 - Ô Tô Con'),
    ('BHYT003', '123456789003', N'Bảo Hiểm Y Tế', '2020-03-15', N'Đà Nẵng', '2023-03-15', N'Nơi ĐK KCB: BV Đà Nẵng'),
    ('BLX003', '123456789003', N'Bằng Lái Xe', '2022-09-20', N'Đà Nẵng', '2027-09-20', N'Hạng A1 - Xe Mô Tô'),
    ('BHYT004', '123456789004', N'Bảo Hiểm Y Tế', '2023-02-01', N'Hà Nội', '2026-02-01', N'Nơi ĐK KCB: BV Việt Đức'),
    ('GPLX004', '123456789004', N'Bằng Lái Xe', '2021-11-10', N'Hà Nội', '2026-11-10', N'Hạng B1 - Ô Tô Số Tự Động'),
    ('BHYT005', '123456789005', N'Bảo Hiểm Y Tế', '2022-07-05', N'TP.HCM', '2025-07-05', N'Nơi ĐK KCB: BV Từ Dũ'),
    ('BLX005', '123456789005', N'Bằng Lái Xe', '2020-12-15', N'TP.HCM', '2025-12-15', N'Hạng A2 - Xe Mô Tô Phân Khối Lớn'),
    ('BHYT006', '123456789006', N'Bảo Hiểm Y Tế', '2021-04-01', N'Cần Thơ', '2024-04-01', N'Nơi ĐK KCB: BV Cần Thơ'),
    ('GPLX006', '123456789006', N'Bằng Lái Xe', '2023-08-20', N'Cần Thơ', '2028-08-20', N'Hạng B2 - Ô Tô Con'),
    ('BHYT007', '123456789007', N'Bảo Hiểm Y Tế', '2020-06-10', N'Hải Phòng', '2023-06-10', N'Nơi ĐK KCB: BV Hải Phòng'),
    ('BLX007', '123456789007', N'Bằng Lái Xe', '2022-03-25', N'Hải Phòng', '2027-03-25', N'Hạng A1 - Xe Mô Tô'),
    ('BHYT008', '123456789008', N'Bảo Hiểm Y Tế', '2023-01-20', N'Nghệ An', '2026-01-20', N'Nơi ĐK KCB: BV Nghệ An'),
    ('GPLX008', '123456789008', N'Bằng Lái Xe', '2021-09-15', N'Nghệ An', '2027-03-25', N'Hạng B1 - Ô Tô Số Tự Động'),
    ('BHYT009', '123456789009', N'Bảo Hiểm Y Tế', '2022-05-01', N'Đồng Nai', '2025-05-01', N'Nơi ĐK KCB: BV Đồng Nai'),
    ('BLX009', '123456789009', N'Bằng Lái Xe', '2020-10-10', N'Đồng Nai', '2027-03-25', N'Hạng A1 - Xe Mô Tô'),
    ('BHYT010', '123456789010', N'Bảo Hiểm Y Tế', '2021-07-05', N'Bình Dương', '2024-07-05', N'Nơi ĐK KCB: BV Bình Dương'),
    ('GPLX010', '123456789010', N'Bằng Lái Xe', '2023-04-18', N'Bình Dương', '2027-03-25', N'Hạng B2 - Ô Tô Con');
GO

INSERT INTO SaiPham (maSaiPham, SoCCCD, loiSaiPham, ngaySai, noiSaiPham, mucPhat, trangThai)
VALUES 
    ('SP001', '123456789001', N'Sử dụng CCCD giả mạo', '2023-10-15', N'Hà Nội', 2000000, N'Đã xử lý'),
    ('SP002', '123456789002', N'Không xuất trình CCCD khi yêu cầu', '2023-11-20', N'TP.HCM', 500000, N'Chưa xử lý'),
    ('SP003', '123456789003', N'Khai báo thông tin sai lệch', '2024-01-05', N'Đà Nẵng', 1000000, N'Đang xử lý'),
    ('SP004', '123456789004', N'Sử dụng CCCD hết hạn', '2024-03-12', N'Hà Nội', 300000, N'Đã xử lý'),
    ('SP005', '123456789005', N'Không cập nhật thông tin CCCD', '2024-06-25', N'TP.HCM', 400000, N'Chưa xử lý');
GO


select sp.*, cc.HoTen, cc.NgaySinh, cc.GioiTinh, cc.DanToc, cc.TonGiao  ,cc.QueQuan
from SaiPham  sp
join CongDanCCCD cc on sp.SoCCCD = cc.SoCCCD
