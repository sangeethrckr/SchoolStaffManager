
CREATE PROCEDURE Proc_Staff_UpdateStaff
	@StaffId INT,
	@Name NVARCHAR(50),
	@PhoneNUmber NVARCHAR(50),
	@ClassAssigned INT = NULL,
	@Post NVARCHAR(50) = NULL,
	@HouseName NVARCHAR(50),
	@City NVARCHAR(50),
	@State NVARCHAR(50),
	@PinCode NVARCHAR(50),
	@Salary DECIMAL(18,0)

AS
BEGIN
	
	DECLARE @StaffType TINYINT = (SELECT StaffType FROM Staff WHERE StaffId = @StaffId)

	IF @StaffType = 0
    BEGIN
        
        UPDATE TeachingStaff SET ClassAssigned = @ClassAssigned,ModifiedDate = GETDATE() WHERE StaffId = @StaffId;
        
    END


    IF @StaffType = 1
    BEGIN
        UPDATE AdminStaff SET Post = @Post,ModifiedDate = GETDATE() WHERE StaffId = @StaffId;
    END


    IF @StaffType = 2
    BEGIN
        UPDATE SupportStaff SET Post = @Post,ModifiedDate = GETDATE() WHERE StaffId = @StaffId;
    END


	UPDATE Staff SET
            Name = @Name,
            PhoneNumber = @PhoneNUmber,
            HouseName = @HouseName,
			City = @City,
			State = @State,
			PinCode = @PinCode,
			Salary = @Salary,
            ModifiedDate = GETDATE()
    WHERE StaffId = @StaffId;

END