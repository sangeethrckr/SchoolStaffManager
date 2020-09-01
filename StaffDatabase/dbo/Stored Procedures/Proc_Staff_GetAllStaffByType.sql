
CREATE PROCEDURE Proc_Staff_GetAllStaffByType
	@StaffType INT
AS
BEGIN
	SELECT S.StaffId,S.Name,S.PhoneNumber,S.Salary,S.HouseName,S.City,S.State,S.PinCode,T.Subject,T.ClassAssigned,A.Post,SU.Post,S.StaffType
	FROM Staff as S
	LEFT JOIN TeachingStaff as T ON T.StaffId = S.StaffId
	LEFT JOIN AdminStaff as A ON A.StaffId = S.StaffId
	LEFT JOIN SupportStaff as SU ON SU.StaffId = S.StaffId
	WHERE S.StaffType = @StaffType;
END