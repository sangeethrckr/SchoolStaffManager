
CREATE PROCEDURE Proc_Staff_RemoveStaff
	@StaffID INT
AS
BEGIN
	DECLARE @StaffType TINYINT = (SELECT StaffType FROM Staff WHERE StaffId = @StaffId)

	IF @StaffType = 0
    BEGIN
       DELETE FROM TeachingStaff WHERE StaffId = @StaffID;
    END


    IF @StaffType = 1
    BEGIN
        DELETE FROM AdminStaff WHERE StaffId = @StaffID;
    END


    IF @StaffType = 2
    BEGIN
        DELETE FROM SupportStaff WHERE StaffId = @StaffID;
    END

	DELETE FROM Staff WHERE StaffId = @StaffID;
END