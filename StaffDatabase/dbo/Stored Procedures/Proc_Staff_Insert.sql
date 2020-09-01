
CREATE PROCEDURE Proc_Staff_Insert
	@Name NVARCHAR(50),
	@PhoneNumber NVARCHAR(50),
	@Salary DECIMAL(18,0),
	@HouseName NVARCHAR(50),
	@City NVARCHAR(50),
	@State NVARCHAR(50),
	@PinCode NVARCHAR(50),
	@StaffType TINYINT,
	@Subject NVARCHAR(50) = NULL,
	@ClassAssigned INT = NULL,
	@Post NVARCHAR(50) = NULL
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO Staff 
		(Name,PhoneNumber,Salary,HouseName,City,State,PinCode,StaffType,CreatedDate,ModifiedDate)
	VALUES (@Name,@PhoneNumber,@Salary,@HouseName,@City,@State,@PinCode,@StaffType,GETDATE(),GETDATE());

	IF @StaffType = 0
	BEGIN
		INSERT INTO TeachingStaff
			(StaffId,Subject,ClassAssigned,CreatedDate,ModifiedDate)
		VALUES
			((SELECT StaffId FROM Staff WHERE Name = @Name),@Subject,@ClassAssigned,GETDATE(),GETDATE());
	END

	IF @StaffType = 1
	BEGIN
		INSERT INTO AdminStaff
			(StaffId,Post,CreatedDate,ModifiedDate)
		VALUES
			((SELECT StaffId FROM Staff WHERE Name = @Name),@Post,GETDATE(),GETDATE());
	END

	IF @StaffType = 2
	BEGIN
		INSERT INTO SupportStaff
			(StaffId,Post,CreatedDate,ModifiedDate)
		VALUES
			((SELECT StaffId FROM Staff WHERE Name = @Name),@Post,GETDATE(),GETDATE());
	END

END