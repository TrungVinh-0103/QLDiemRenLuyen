CREATE DATABASE QLRenLuyenSinhVien;
GO

USE QLRenLuyenSinhVien;
GO

CREATE TABLE TaiKhoan (
    MaDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50) NOT NULL,
    LoaiTaiKhoan NVARCHAR(20) NOT NULL
);

CREATE TABLE Truong (
    MaTruong NVARCHAR(10) PRIMARY KEY,
    TenTruong NVARCHAR(100)
);

CREATE TABLE Khoa (
    MaKhoa NVARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100),
    MaTruong NVARCHAR(10),
    FOREIGN KEY (MaTruong) REFERENCES Truong(MaTruong)
);

CREATE TABLE NienKhoa (
    MaNienKhoa NVARCHAR(10) PRIMARY KEY,
    TenNienKhoa NVARCHAR(50),
    Duration INT NOT NULL DEFAULT 4
);

CREATE TABLE Lop (
    TenLop NVARCHAR(50),
    MaKhoa NVARCHAR(10),
    MaNienKhoa NVARCHAR(10),
    PRIMARY KEY (TenLop, MaKhoa, MaNienKhoa),
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa),
    FOREIGN KEY (MaNienKhoa) REFERENCES NienKhoa(MaNienKhoa)
);
ALTER TABLE Lop
ADD SiSo INT DEFAULT 0;

CREATE TABLE HocKy (
    MaHocKy NVARCHAR(10) PRIMARY KEY,
    TenHocKy NVARCHAR(50),
    Nam INT
);
--====================================================================
CREATE TABLE SinhVien (
    MaSV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    QueQuan NVARCHAR(100),
    TenLop NVARCHAR(50),
    MaKhoa NVARCHAR(10),
    MaNienKhoa NVARCHAR(10),
    TrangThai NVARCHAR(50),
	Email NVARCHAR(50),
    FOREIGN KEY (TenLop, MaKhoa, MaNienKhoa) REFERENCES Lop(TenLop, MaKhoa, MaNienKhoa)
);
ALTER TABLE SinhVien
ADD STT INT;
select * from SinhVien
--ALTER TABLE SinhVien
--ADD Email NVARCHAR(100);
--GO
-- Cập nhật dữ liệu mẫu cho Email
--UPDATE SinhVien
--SET Email = MaSV + '@student.nctu.edu.vn'
--WHERE Email IS NULL;
GO
--====================================================================
CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL, -- Lưu mật khẩu (nên mã hóa trong thực tế)
    Email NVARCHAR(100),
    VaiTro NVARCHAR(20) NOT NULL -- 'GVCN' hoặc 'HoiDong'
);
GO

CREATE TABLE GVCN (
    MaGVCN NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

CREATE TABLE HoiDong (
    MaHoiDong NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
--====================================================================
CREATE TABLE DiemRenLuyen (
    MaSV NVARCHAR(10),
    MaHocKy NVARCHAR(10),
    Nam INT,
    Diem INT,
    XepLoai NVARCHAR(50),
    PRIMARY KEY (MaSV, MaHocKy, Nam),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaHocKy) REFERENCES HocKy(MaHocKy)
);

CREATE TABLE PhieuDanhGia (
    MaPhieu BIGINT IDENTITY(1,1) PRIMARY KEY,
    MaSV NVARCHAR(10),
    MaHocKy NVARCHAR(10),
    Nam INT,
    LoaiPhieu NVARCHAR(20),
    Diem1_1 INT,--8
    Diem1_2 INT,
    Diem1_3 INT,
    Diem1_4 INT,
    Diem1_5 INT,
    Diem1_6 INT,
    Diem1_7 INT,
    Diem1_8 INT,
    Diem2_1 INT,--7
    Diem2_2 INT,
    Diem2_3 INT,
    Diem2_4 INT,
    Diem2_5 INT,
    Diem2_6 INT,
    Diem2_7 INT,
    Diem3_1 INT,--7
    Diem3_2 INT,
    Diem3_3 INT,
    Diem3_4 INT,
    Diem3_5 INT,
    Diem3_6 INT,
    Diem3_7 INT,
    Diem4_1 INT,--5
    Diem4_2 INT,
    Diem4_3 INT,
    Diem4_4 INT,
    Diem4_5 INT,
    Diem5_1 INT,--6
    Diem5_2 INT,
    Diem5_3 INT,
    Diem5_4 INT,
    Diem5_5 INT,
    Diem5_6 INT,
    TongDiem INT,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaHocKy) REFERENCES HocKy(MaHocKy)
);
GO
--====Xoa cot Minh chung
ALTER TABLE PhieuDanhGia DROP COLUMN ImageMinhChung;
SELECT * FROM PhieuDanhGia
--====THÊM bảng MinhChung để có thể cung cấp nhiều ảnh
CREATE TABLE MinhChung (
    MaMinhChung INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu BIGINT NOT NULL,
    ImageData VARBINARY(MAX) NOT NULL,
    FOREIGN KEY (MaPhieu) REFERENCES PhieuDanhGia(MaPhieu)
);
select * from MinhChung
select sv.HoTen, sv.MaSV, sv.GioiTinh, sv.TenLop, sv.TrangThai, drl.MaSV, drl.MaHocKy, drl.Nam, drl.Diem, drl.XepLoai from SinhVien as sv,  DiemRenLuyen as drl
select MaSV, Diem from DiemRenLuyen
select TenLop, MaKhoa, MaNienKhoa from Lop 
select TenTruong, MaTruong from Truong
select tk.MaDangNhap, tk.MatKhau, tk.LoaiTaiKhoan from TaiKhoan as tk
GO
--================================================================================================================
-- Triggers
CREATE TRIGGER tr_InsertSinhVien_TaiKhoan
ON SinhVien
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TaiKhoan (MaDangNhap, MatKhau, LoaiTaiKhoan)
    SELECT MaSV, '111', 'SinhVien'
    FROM inserted
    WHERE NOT EXISTS (
        SELECT 1 FROM TaiKhoan WHERE MaDangNhap = inserted.MaSV
    );
END;
GO
CREATE TRIGGER tr_InsertNhanVien_TaiKhoan
ON GVCN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TaiKhoan (MaDangNhap, MatKhau, LoaiTaiKhoan)
    SELECT MaNV, '0000', 'GVCN'
    FROM inserted
    WHERE NOT EXISTS (
        SELECT 1 FROM TaiKhoan WHERE MaDangNhap = inserted.MaNV
    );
END;
GO
CREATE TRIGGER tr_InsertHoiDong_TaiKhoan
ON HoiDong
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TaiKhoan (MaDangNhap, MatKhau, LoaiTaiKhoan)
    SELECT MaHoiDong, '0000', 'HoiDong'
    FROM inserted
    WHERE NOT EXISTS (
        SELECT 1 FROM TaiKhoan WHERE MaDangNhap = inserted.MaHoiDong
    );
END;
GO
GO
CREATE TRIGGER tr_ValidateLopNienKhoa
ON Lop
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Khoa k ON i.MaKhoa = k.MaKhoa
        JOIN NienKhoa nk ON i.MaNienKhoa = nk.MaNienKhoa
        WHERE k.MaKhoa IN ('7720101', '7720501', '7720110') AND nk.Duration != 6
    )
    BEGIN
        RAISERROR (N'Lớp thuộc khoa Y khoa, Răng Hàm Mặt hoặc Y học dự phòng phải có niên khóa kéo dài 6 năm.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE TRIGGER tr_ValidateHocKyNam
ON HocKy
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted i
        CROSS APPLY (
            SELECT TOP 1 CAST(LEFT(TenNienKhoa, 4) AS INT) AS StartYear, 
                         CAST(RIGHT(TenNienKhoa, 4) AS INT) AS EndYear
            FROM NienKhoa
            WHERE MaNienKhoa IN (SELECT MaNienKhoa FROM Lop WHERE TenLop IN (
                SELECT TenLop FROM SinhVien WHERE MaSV IN (
                    SELECT MaSV FROM PhieuDanhGia WHERE MaHocKy = i.MaHocKy
                )
            ))
        ) nk
        WHERE i.Nam < nk.StartYear OR i.Nam > nk.EndYear
    )
    BEGIN
        RAISERROR (N'Năm học kỳ không nằm trong khoảng niên khóa của lớp.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE TRIGGER tr_ValidatePhieuDanhGia
ON PhieuDanhGia
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE 
            i.Diem1_1 > 15 OR i.Diem1_2 > 5 OR i.Diem1_3 > 5 OR i.Diem1_4 > 4 OR i.Diem1_5 > 5 OR
            i.Diem2_1 > 10 OR i.Diem2_2 > 5 OR i.Diem2_3 > 3 OR i.Diem2_4 > 5 OR i.Diem2_5 > 3 OR i.Diem2_6 > 5 OR
            i.Diem3_1 > 4 OR i.Diem3_2 > 5 OR i.Diem3_3 > 3 OR i.Diem3_4 > 3 OR i.Diem3_5 > 3 OR i.Diem3_7 > 6 OR
            i.Diem4_1 > 10 OR i.Diem4_2 > 5 OR i.Diem4_3 > 5 OR i.Diem4_4 > 5 OR
            i.Diem5_1 > 6 OR i.Diem5_3 > 5 OR i.Diem5_4 > 5 OR
            i.TongDiem > 100
    )
    BEGIN
        RAISERROR (N'Điểm số vượt quá giới hạn cho phép hoặc tổng điểm vượt quá 100.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE TRIGGER tr_SyncDiemRenLuyen
ON PhieuDanhGia
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    MERGE INTO DiemRenLuyen AS target
    USING (
        SELECT 
            i.MaSV, 
            i.MaHocKy, 
            i.Nam, 
            i.TongDiem,
            CASE 
                WHEN i.TongDiem >= 90 THEN N'Xuất sắc'
                WHEN i.TongDiem >= 80 THEN N'Tốt'
                WHEN i.TongDiem >= 65 THEN N'Khá'
                WHEN i.TongDiem >= 50 THEN N'Trung bình'
                WHEN i.TongDiem >= 35 THEN N'Yếu'
                ELSE N'Kém'
            END AS XepLoai
        FROM inserted i
        WHERE i.LoaiPhieu = 'HoiDong'
    ) AS source
    ON target.MaSV = source.MaSV 
       AND target.MaHocKy = source.MaHocKy 
       AND target.Nam = source.Nam
    WHEN MATCHED THEN
        UPDATE SET 
            Diem = source.TongDiem,
            XepLoai = source.XepLoai
    WHEN NOT MATCHED THEN
        INSERT (MaSV, MaHocKy, Nam, Diem, XepLoai)
        VALUES (source.MaSV, source.MaHocKy, source.Nam, source.TongDiem, source.XepLoai);
END;
GO

CREATE TRIGGER tr_PreventDeleteLop
ON Lop
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM SinhVien s
        JOIN deleted d ON s.TenLop = d.TenLop AND s.MaKhoa = d.MaKhoa AND s.MaNienKhoa = d.MaNienKhoa
    )
    BEGIN
        RAISERROR (N'Không thể xóa lớp vì vẫn còn sinh viên thuộc lớp này.', 16, 1);
    END
    ELSE
    BEGIN
        DELETE FROM Lop
        WHERE EXISTS (
            SELECT 1 FROM deleted d
            WHERE d.TenLop = Lop.TenLop AND d.MaKhoa = Lop.MaKhoa AND d.MaNienKhoa = Lop.MaNienKhoa
        );
    END
END;
GO

CREATE TRIGGER tr_CalculateTongDiem
ON PhieuDanhGia
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE PhieuDanhGia
    SET TongDiem = ISNULL(Diem1_1, 0) + ISNULL(Diem1_2, 0) + ISNULL(Diem1_3, 0) + ISNULL(Diem1_4, 0) + 
                   ISNULL(Diem1_5, 0) + ISNULL(Diem1_6, 0) + ISNULL(Diem1_7, 0) + ISNULL(Diem1_8, 0) +
                   ISNULL(Diem2_1, 0) + ISNULL(Diem2_2, 0) + ISNULL(Diem2_3, 0) + ISNULL(Diem2_4, 0) + 
                   ISNULL(Diem2_5, 0) + ISNULL(Diem2_6, 0) + ISNULL(Diem2_7, 0) +
                   ISNULL(Diem3_1, 0) + ISNULL(Diem3_2, 0) + ISNULL(Diem3_3, 0) + ISNULL(Diem3_4, 0) + 
                   ISNULL(Diem3_5, 0) + ISNULL(Diem3_6, 0) + ISNULL(Diem3_7, 0) +
                   ISNULL(Diem4_1, 0) + ISNULL(Diem4_2, 0) + ISNULL(Diem4_3, 0) + ISNULL(Diem4_4, 0) + 
                   ISNULL(Diem4_5, 0) +
                   ISNULL(Diem5_1, 0) + ISNULL(Diem5_2, 0) + ISNULL(Diem5_3, 0) + ISNULL(Diem5_4, 0) + 
                   ISNULL(Diem5_5, 0) + ISNULL(Diem5_6, 0)
    WHERE MaPhieu IN (SELECT MaPhieu FROM inserted);
END;
GO

CREATE TRIGGER trg_UpdateSiSo_AfterInsertDelete
ON SinhVien
AFTER INSERT, DELETE
AS
BEGIN
    EXEC sp_UpdateSiSo;
END
GO
--================================================================================================================
-- Stored Procedures
CREATE PROCEDURE sp_AuthenticateUser
    @MaDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaDangNhap, LoaiTaiKhoan
    FROM TaiKhoan
    WHERE MaDangNhap = @MaDangNhap AND MatKhau = @MatKhau;
END;
GO

CREATE PROCEDURE sp_InsertLop
    @TenLop NVARCHAR(50),
    @MaKhoa NVARCHAR(10),
    @MaNienKhoa NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = @MaKhoa)
        AND EXISTS (SELECT 1 FROM NienKhoa WHERE MaNienKhoa = @MaNienKhoa)
    BEGIN
        INSERT INTO Lop (TenLop, MaKhoa, MaNienKhoa)
        VALUES (@TenLop, @MaKhoa, @MaNienKhoa);
        SELECT 1 AS Result;
    END
    ELSE
    BEGIN
        RAISERROR (N'Mã khoa hoặc niên khóa không hợp lệ.', 16, 1);
        SELECT 0 AS Result;
    END
END;
GO

CREATE PROCEDURE sp_UpdateLop
    @TenLop NVARCHAR(50),
    @MaKhoa NVARCHAR(10),
    @MaNienKhoa NVARCHAR(10),
    @NewTenLop NVARCHAR(50),
    @NewMaKhoa NVARCHAR(10),
    @NewMaNienKhoa NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = @NewMaKhoa)
        AND EXISTS (SELECT 1 FROM NienKhoa WHERE MaNienKhoa = @NewMaNienKhoa)
    BEGIN
        UPDATE Lop
        SET TenLop = @NewTenLop, MaKhoa = @NewMaKhoa, MaNienKhoa = @NewMaNienKhoa
        WHERE TenLop = @TenLop AND MaKhoa = @MaKhoa AND MaNienKhoa = @MaNienKhoa;
        SELECT 1 AS Result;
    END
    ELSE
    BEGIN
        RAISERROR (N'Mã khoa hoặc niên khóa không hợp lệ.', 16, 1);
        SELECT 0 AS Result;
    END
END;
GO

CREATE PROCEDURE sp_SearchLop
    @TenLop NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TenLop, MaKhoa, MaNienKhoa
    FROM Lop
    WHERE TenLop LIKE '%' + @TenLop + '%';
END;
GO
--Cap nhat si so
CREATE PROCEDURE sp_UpdateSiSo
AS
BEGIN
    UPDATE Lop
    SET SiSo = (
        SELECT COUNT(*)
        FROM SinhVien sv
        WHERE sv.TenLop = Lop.TenLop 
          AND sv.MaKhoa = Lop.MaKhoa 
          AND sv.MaNienKhoa = Lop.MaNienKhoa
    );
END
GO

CREATE PROCEDURE sp_InsertSinhVien
    @MaSV NVARCHAR(10),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @QueQuan NVARCHAR(100),
    @TenLop NVARCHAR(50),
    @MaKhoa NVARCHAR(10),
    @MaNienKhoa NVARCHAR(10),
    @TrangThai NVARCHAR(50),
	@Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM Lop WHERE TenLop = @TenLop AND MaKhoa = @MaKhoa AND MaNienKhoa = @MaNienKhoa)
        BEGIN
            INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, QueQuan, TenLop, MaKhoa, MaNienKhoa, TrangThai, Email)
            VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @QueQuan, @TenLop, @MaKhoa, @MaNienKhoa, @TrangThai, @Email);
            COMMIT TRANSACTION;
            SELECT 1 AS Result;
        END
        ELSE
        BEGIN
            RAISERROR (N'Lớp không hợp lệ.', 16, 1);
            ROLLBACK TRANSACTION;
            SELECT 0 AS Result;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        SELECT 0 AS Result;
    END CATCH
END;
GO

CREATE PROCEDURE sp_DeleteSinhVien
    @MaSV VARCHAR(10)
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem sinh viên có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
        BEGIN
            RAISERROR ('Sinh viên không tồn tại!', 16, 1);
            RETURN;
        END

        -- Xóa sinh viên
        DELETE FROM SinhVien WHERE MaSV = @MaSV;

        -- Kiểm tra và xóa các dữ liệu liên quan (nếu cần)
        DELETE FROM PhieuDanhGia WHERE MaSV = @MaSV;
        DELETE FROM DiemRenLuyen WHERE MaSV = @MaSV;

        RETURN 1; -- Thành công
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        RETURN 0; -- Thất bại
    END CATCH
END

GO
CREATE PROCEDURE sp_SearchSinhVien
    @MaSV NVARCHAR(10) = NULL,
    @HoTen NVARCHAR(100) = NULL,
    @TenLop NVARCHAR(50) = NULL,
    @MaKhoa NVARCHAR(10) = NULL,
    @MaNienKhoa NVARCHAR(10) = NULL,
	@Email NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSV, HoTen, NgaySinh, GioiTinh, QueQuan, TenLop, MaKhoa, MaNienKhoa, TrangThai, Email
    FROM SinhVien
    WHERE (@MaSV IS NULL OR MaSV = @MaSV)
      AND (@HoTen IS NULL OR HoTen LIKE '%' + @HoTen + '%')
      AND (@TenLop IS NULL OR TenLop = @TenLop)
      AND (@MaKhoa IS NULL OR MaKhoa = @MaKhoa)
      AND (@MaNienKhoa IS NULL OR MaNienKhoa = @MaNienKhoa)
	  AND (@Email IS NULL OR Email = @Email);
END;
GO

CREATE PROCEDURE sp_SearchSinhVienMultiField
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM SinhVien
    WHERE
        MaSV LIKE '%' + @Keyword + '%' OR
        HoTen LIKE '%' + @Keyword + '%' OR
        GioiTinh LIKE '%' + @Keyword + '%' OR
        QueQuan LIKE '%' + @Keyword + '%' OR
        TenLop LIKE '%' + @Keyword + '%' OR
        MaKhoa LIKE '%' + @Keyword + '%' OR
        MaNienKhoa LIKE '%' + @Keyword + '%' OR
        TrangThai LIKE '%' + @Keyword + '%' OR
        CONVERT(VARCHAR, NgaySinh, 103) LIKE '%' + @Keyword + '%' OR
        DATEDIFF(YEAR, NgaySinh, GETDATE()) LIKE '%' + @Keyword + '%'
END;
GO

CREATE PROCEDURE sp_FilterDiemRenLuyen
    @TenLop NVARCHAR(50) = NULL,
    @MaKhoa NVARCHAR(10) = NULL,
    @MaNienKhoa NVARCHAR(10) = NULL,
    @MaHocKy NVARCHAR(10) = NULL,
    @Nam INT = NULL,
    @MaSV NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV, sv.HoTen, l.TenLop, l.MaKhoa, l.MaNienKhoa, drl.MaHocKy, drl.Nam, drl.Diem, drl.XepLoai
    FROM SinhVien sv
    JOIN Lop l ON sv.TenLop = l.TenLop AND sv.MaKhoa = l.MaKhoa AND sv.MaNienKhoa = l.MaNienKhoa
    LEFT JOIN DiemRenLuyen drl ON sv.MaSV = drl.MaSV
        AND (@MaHocKy IS NULL OR drl.MaHocKy = @MaHocKy)
        AND (@Nam IS NULL OR drl.Nam = @Nam)
    WHERE (@TenLop IS NULL OR sv.TenLop = @TenLop)
      AND (@MaKhoa IS NULL OR sv.MaKhoa = @MaKhoa)
      AND (@MaNienKhoa IS NULL OR sv.MaNienKhoa = @MaNienKhoa)
      AND (@MaSV IS NULL OR sv.MaSV = @MaSV)
      AND sv.TrangThai = N'Đang học';
END;
GO

CREATE PROCEDURE sp_InsertPhieuDanhGia
    @MaSV NVARCHAR(10),
    @MaHocKy NVARCHAR(10),
    @Nam INT,
    @LoaiPhieu NVARCHAR(20),
    @Diem1_1 INT,
    @Diem1_2 INT,
    @Diem1_3 INT,
    @Diem1_4 INT,
    @Diem1_5 INT,
    @Diem1_6 INT,
    @Diem1_7 INT,
    @Diem1_8 INT,
    @Diem2_1 INT,
    @Diem2_2 INT,
    @Diem2_3 INT,
    @Diem2_4 INT,
    @Diem2_5 INT,
    @Diem2_6 INT,
    @Diem2_7 INT,
    @Diem3_1 INT,
    @Diem3_2 INT,
    @Diem3_3 INT,
    @Diem3_4 INT,
    @Diem3_5 INT,
    @Diem3_6 INT,
    @Diem3_7 INT,
    @Diem4_1 INT,
    @Diem4_2 INT,
    @Diem4_3 INT,
    @Diem4_4 INT,
    @Diem4_5 INT,
    @Diem5_1 INT,
    @Diem5_2 INT,
    @Diem5_3 INT,
    @Diem5_4 INT,
    @Diem5_5 INT,
    @Diem5_6 INT,
    @ImageMinhChung VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
        AND EXISTS (SELECT 1 FROM HocKy WHERE MaHocKy = @MaHocKy)
    BEGIN
        INSERT INTO PhieuDanhGia (
            MaSV, MaHocKy, Nam, LoaiPhieu, 
            Diem1_1, Diem1_2, Diem1_3, Diem1_4, Diem1_5, Diem1_6, Diem1_7, Diem1_8,
            Diem2_1, Diem2_2, Diem2_3, Diem2_4, Diem2_5, Diem2_6, Diem2_7,
            Diem3_1, Diem3_2, Diem3_3, Diem3_4, Diem3_5, Diem3_6, Diem3_7,
            Diem4_1, Diem4_2, Diem4_3, Diem4_4, Diem4_5,
            Diem5_1, Diem5_2, Diem5_3, Diem5_4, Diem5_5, Diem5_6,
            ImageMinhChung
        )
        VALUES (
            @MaSV, @MaHocKy, @Nam, @LoaiPhieu,
            @Diem1_1, @Diem1_2, @Diem1_3, @Diem1_4, @Diem1_5, @Diem1_6, @Diem1_7, @Diem1_8,
            @Diem2_1, @Diem2_2, @Diem2_3, @Diem2_4, @Diem2_5, @Diem2_6, @Diem2_7,
            @Diem3_1, @Diem3_2, @Diem3_3, @Diem3_4, @Diem3_5, @Diem3_6, @Diem3_7,
            @Diem4_1, @Diem4_2, @Diem4_3, @Diem4_4, @Diem4_5,
            @Diem5_1, @Diem5_2, @Diem5_3, @Diem5_4, @Diem5_5, @Diem5_6,
            @ImageMinhChung
        );
        SELECT 1 AS Result;
    END
    ELSE
    BEGIN
        RAISERROR (N'Mã sinh viên hoặc học kỳ không hợp lệ.', 16, 1);
        SELECT 0 AS Result;
    END
END;
GO

CREATE PROCEDURE sp_GetPhieuDanhGia
    @MaSV NVARCHAR(10),
    @MaHocKy NVARCHAR(10),
    @Nam INT,
    @LoaiPhieu NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        MaPhieu, MaSV, MaHocKy, Nam, LoaiPhieu, 
        Diem1_1, Diem1_2, Diem1_3, Diem1_4, Diem1_5, Diem1_6, Diem1_7, Diem1_8,
        Diem2_1, Diem2_2, Diem2_3, Diem2_4, Diem2_5, Diem2_6, Diem2_7,
        Diem3_1, Diem3_2, Diem3_3, Diem3_4, Diem3_5, Diem3_6, Diem3_7,
        Diem4_1, Diem4_2, Diem4_3, Diem4_4, Diem4_5,
        Diem5_1, Diem5_2, Diem5_3, Diem5_4, Diem5_5, Diem5_6,
        TongDiem, ImageMinhChung
    FROM PhieuDanhGia
    WHERE MaSV = @MaSV
      AND MaHocKy = @MaHocKy
      AND Nam = @Nam
      AND LoaiPhieu = @LoaiPhieu;
END;
GO

--==============4/6/2025====UPDATE 2 NEW PROC=========
CREATE PROCEDURE sp_InsertMinhChung
    @MaPhieu INT,
    @ImageData VARBINARY(MAX)
AS
BEGIN
    BEGIN TRY
        INSERT INTO MinhChung (MaPhieu, ImageData)
        VALUES (@MaPhieu, @ImageData);
        RETURN 1;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
        RETURN 0;
    END CATCH
END;

CREATE PROCEDURE sp_GetMinhChungByPhieu
    @MaPhieu INT
AS
BEGIN
    SELECT MaMinhChung, MaPhieu, ImageData
    FROM MinhChung
    WHERE MaPhieu = @MaPhieu;
END;
GO

CREATE PROCEDURE sp_ThongKeChuaDat
    @TenLop NVARCHAR(50) = NULL,
    @MaKhoa NVARCHAR(10) = NULL,
    @MaNienKhoa NVARCHAR(10) = NULL,
    @DiemNguong INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV, sv.HoTen, l.TenLop, l.MaKhoa, l.MaNienKhoa, drl.Diem, drl.XepLoai
    FROM SinhVien sv
    JOIN Lop l ON sv.TenLop = l.TenLop AND sv.MaKhoa = l.MaKhoa AND sv.MaNienKhoa = l.MaNienKhoa
    JOIN DiemRenLuyen drl ON sv.MaSV = drl.MaSV
    WHERE drl.Diem < @DiemNguong
      AND (@TenLop IS NULL OR sv.TenLop = @TenLop)
      AND (@MaKhoa IS NULL OR sv.MaKhoa = @MaKhoa)
      AND (@MaNienKhoa IS NULL OR sv.MaNienKhoa = @MaNienKhoa)
      AND sv.TrangThai = N'Đang học';
END;
GO
--=======TRIGGER========================================================================
CREATE TRIGGER trg_AutoSTT_SinhVien
ON SinhVien
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE sv
    SET STT = (
        SELECT COUNT(*) 
        FROM SinhVien s2 
        WHERE s2.TenLop = sv.TenLop AND s2.MaSV <= sv.MaSV
    )
    FROM SinhVien sv
    INNER JOIN inserted i ON sv.MaSV = i.MaSV;
END
DROP TRIGGER trg_AutoSTT_SinhVien;
ALTER TABLE SinhVien
DROP COLUMN STT;
--===============STT tam thoi===============
SELECT 
    ROW_NUMBER() OVER (ORDER BY MaSV) AS STT,
    MaSV, HoTen, NgaySinh, GioiTinh, QueQuan, TenLop, MaKhoa, MaNienKhoa, TrangThai
FROM SinhVien

--=====================================================================================
-- Insert Sample Data
INSERT INTO Truong (MaTruong, TenTruong)
VALUES ('DNC', N'Đại học Nam Cần Thơ');

INSERT INTO Khoa (MaKhoa, TenKhoa, MaTruong)
VALUES 
    ('7480201', N'Công nghệ thông tin', 'DNC'),
    ('7480103', N'Kỹ thuật phần mềm', 'DNC'),
    ('7480101', N'Khoa học máy tính', 'DNC'),
    ('7720101', N'Y khoa', 'DNC'),
    ('7720501', N'Răng Hàm Mặt', 'DNC'),
    ('7720110', N'Y học dự phòng', 'DNC');

INSERT INTO NienKhoa (MaNienKhoa, TenNienKhoa, Duration)
VALUES 
    ('K7', N'2019-2023', 4),
    ('K8', N'2020-2024', 4),
    ('K9', N'2021-2025', 4),
    ('K10', N'2022-2026', 4),
    ('K11', N'2023-2027', 4),
    ('K7Y', N'2019-2025', 6),
    ('K8Y', N'2020-2026', 6),
    ('K9Y', N'2021-2027', 6),
    ('K10Y', N'2022-2028', 6),
    ('K11Y', N'2023-2029', 6);

INSERT INTO Lop (TenLop, MaKhoa, MaNienKhoa)
VALUES 
    (N'DH22TIN02', '7480201', 'K10'),
    (N'DH22YKH04', '7720101', 'K10Y');
DELETE FROM Lop;
--Drop bang SinhVien co khoa ngoai
ALTER TABLE SinhVien NOCHECK CONSTRAINT ALL; --B1:tam close rang buoc cac bang lien quan
DELETE FROM Lop; --B2:sau do delete
ALTER TABLE SinhVien CHECK CONSTRAINT ALL; --B3:ke tiep thi open lai

--Kiem tra thg nao lien ket den Lop
SELECT 
    f.name AS ForeignKey,
    OBJECT_NAME(f.parent_object_id) AS TableName,
    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName
FROM 
    sys.foreign_keys AS f
INNER JOIN 
    sys.foreign_key_columns AS fc 
    ON f.object_id = fc.constraint_object_id
WHERE 
    f.referenced_object_id = OBJECT_ID('Lop');
--===================================================================================
INSERT INTO HocKy (MaHocKy, TenHocKy, Nam)
VALUES 
    ('HK1_2022', N'Học kỳ 1', 2022),
    ('HK2_2022', N'Học kỳ 2', 2022),
    ('HK1_2023', N'Học kỳ 1', 2023),
    ('HK2_2023', N'Học kỳ 2', 2023);
INSERT INTO HocKy (MaHocKy, TenHocKy, Nam)
VALUES 
    ('HK1_2024', N'Học kỳ 1', 2024),
    ('HK2_2024', N'Học kỳ 2', 2024),
	('HK3_2024', N'Học kỳ 3', 2024),
    ('HK1_2025', N'Học kỳ 1', 2025),
    ('HK2_2025', N'Học kỳ 2', 2025),
	('HK3_2025', N'Học kỳ 3', 2025);

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, QueQuan, TenLop, MaKhoa, MaNienKhoa, TrangThai)
VALUES 
    ('221576', N'Đinh Trung Vĩnh', '2004-03-01', N'Nam', N'Hậu Giang', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
    ('220616', N'Trương Anh Tuấn', '2004-12-30', N'Nam', N'Đồng Tháp', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
	('224644', N'Phạm Trần Tuấn Vĩ', '2004-07-14', N'Nam', N'An Giang', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
	('220659', N'Nguyễn Hữu Ngạn', '2004-09-27', N'Nam', N'Kiên Giang', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
	('222786', N'Nguyễn Hoàng Phúc', '2004-07-31', N'Nam', N'Đồng Tháp', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
	('222918', N'Từ Công Vinh', '2004-07-26', N'Nam', N'An Giang', N'DH22TIN02', '7480201', 'K10', N'Đang học'),
	('222273', N'Nguyễn Thị Như Ý', '2004-12-11', N'Nữ', N'Kiên Giang', N'DH22TIN02', '7480201', 'K10', N'Nghỉ học');

INSERT INTO NhanVien (MaNV, HoTen, MatKhau, Email, VaiTro) VALUES
('NV001', N'Nguyễn Văn A', 'nv1', 'nva@nctu.edu.vn', 'GVCN'),
('NV002', N'Trần Thị B', 'nv2', 'ttb@nctu.edu.vn', 'GVCN'),
('NV003', N'Lê Văn C', 'nv3', 'lvc@nctu.edu.vn', 'HoiDong');
GO
DELETE FROM GVCN;
DELETE FROM HoiDong;
DELETE FROM NhanVien;

INSERT INTO GVCN (MaGVCN, MaNV) VALUES
('GVCN001', 'NV001'),
('GVCN002', 'NV002');
GO

INSERT INTO HoiDong (MaHoiDong, MaNV) VALUES
('HD001', 'NV003');
GO
INSERT INTO TaiKhoan(MaDangNhap, MatKhau, LoaiTaiKhoan) VALUES
('GVCN001', '0000', 'GVCN'),
('GVCN002', '0000', 'GVCN');
GO
INSERT INTO TaiKhoan(MaDangNhap, MatKhau, LoaiTaiKhoan) VALUES
('HD001', '0000', 'HoiDong');
GO
--=====================DROP=======================
DELETE FROM SinhVien;
--Drop bang SinhVien co khoa ngoai
ALTER TABLE PhieuDanhGia NOCHECK CONSTRAINT ALL; --B1:tam close rang buoc cac bang lien quan
DELETE FROM SinhVien; --B2:sau do delete
ALTER TABLE PhieuDanhGia CHECK CONSTRAINT ALL; --B3:ke tiep thi open lai

--Kiem tra thg nao lien ket den SinhVien
SELECT 
    f.name AS ForeignKey,
    OBJECT_NAME(f.parent_object_id) AS TableName,
    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName
FROM 
    sys.foreign_keys AS f
INNER JOIN 
    sys.foreign_key_columns AS fc 
    ON f.object_id = fc.constraint_object_id
WHERE 
    f.referenced_object_id = OBJECT_ID('SinhVien');

--================================================
INSERT INTO TaiKhoan (MaDangNhap, MatKhau, LoaiTaiKhoan)
VALUES ('admin', 'admin123', 'Admin');

INSERT INTO PhieuDanhGia (MaSV, MaHocKy, Nam, LoaiPhieu, Diem1_1, Diem1_2, Diem1_3, Diem1_4, Diem1_5, Diem1_6, Diem1_7, Diem1_8,
                          Diem2_1, Diem2_2, Diem2_3, Diem2_4, Diem2_5, Diem2_6, Diem2_7,
                          Diem3_1, Diem3_2, Diem3_3, Diem3_4, Diem3_5, Diem3_6, Diem3_7,
                          Diem4_1, Diem4_2, Diem4_3, Diem4_4, Diem4_5,
                          Diem5_1, Diem5_2, Diem5_3, Diem5_4, Diem5_5, Diem5_6, ImageMinhChung)
VALUES 
    ('221576', 'HK1_2022', 2022, 'SinhVien', 
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 5, 3, 5, 0, 4, 5, 3, 3, 3, 0, 6, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('221576', 'HK1_2022', 2022, 'GVCN',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 0, 3, 0, 0, 4, 5, 3, 3, 3, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('221576', 'HK1_2022', 2022, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 0, 3, 0, 0, 4, 5, 3, 3, 3, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('220616', 'HK1_2022', 2022, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 5, 3, 5, 0, 4, 5, 3, 3, 3, 0, 6, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('224644', 'HK1_2022', 2022, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 0, 0, 5, 0, 0, 5, 3, 3, 3, 0, 0, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('220659', 'HK1_2023', 2023, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 5, 3, 5, 0, 4, 5, 3, 3, 3, 0, 6, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('222786', 'HK1_2023', 2023, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 5, 3, 5, 0, 4, 0, 0, 3, 3, 0, 6, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL),
    ('222918', 'HK1_2023', 2023, 'HoiDong',
     5, 0, 5, 4, 5, 0, 0, 0, 4, 5, 3, 5, 3, 5, 0, 4, 5, 3, 3, 3, 0, 6, 5, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, NULL);
-- Tao Indexes
CREATE INDEX idx_DiemRenLuyen_MaSV_MaHocKy_Nam 
ON DiemRenLuyen(MaSV, MaHocKy, Nam);

CREATE INDEX idx_PhieuDanhGia_MaSV_MaHocKy_Nam 
ON PhieuDanhGia(MaSV, MaHocKy, Nam);
GO
--=====TEST PROC AND TRIGGER======================================================================================
EXEC sp_AuthenticateUser 'admin', 'admin123'; -- Trả về admin, Admin
SELECT * FROM PhieuDanhGia --WHERE MaSV = '221576'; -- Kiểm tra điểm
SELECT * FROM TaiKhoan
Select * from Khoa
Select * from NienKhoa
Select * from Lop
Select * from DiemRenLuyen
Select * from HocKy
Select * from SinhVien
Select * from MinhChung
Select * from NhanVien
Select * from GVCN
Select * from HoiDong
DELETE FROM TaiKhoan WHERE maDangNhap = '';



--=====END TEST PROC AND TRIGGER======================================================================================


