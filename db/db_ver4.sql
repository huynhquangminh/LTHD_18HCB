CREATE PROC QuenMatKhauUser (
	@matk varchar(100), 
	@tendangnhap varchar(100), 
	@matkhaumoi varchar(500)
)
AS BEGIN 
	IF EXISTS (SELECT 1 FROM TaiKhoan WHERE mataikhoan = @matk AND tendangnhap = @tendangnhap) 
	BEGIN 
		UPDATE TaiKhoan
		SET matkhau = @matkhaumoi
		WHERE mataikhoan =@matk
		RETURN 1
	END
END

GO
CREATE PROC DoiMatKhauUser (
	@matk varchar(100), 
	@tendangnhap varchar(100), 
	@matkhau varchar(500), 
	@matkhaumoi varchar(500)
)
AS BEGIN 
	IF EXISTS (SELECT 1 FROM TaiKhoan WHERE mataikhoan = @matk AND tendangnhap = @tendangnhap) 
	BEGIN 
		UPDATE TaiKhoan
		SET matkhau = @matkhaumoi
		WHERE mataikhoan =@matk
		RETURN 1
	END
END

