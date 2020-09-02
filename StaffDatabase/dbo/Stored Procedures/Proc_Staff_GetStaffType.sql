
CREATE PROCEDURE Proc_Staff_GetStaffType 
	@staffId INT
AS
BEGIN
	SELECT StaffType FROM Staff WHERE StaffId = @staffId;
END