
CREATE PROCEDURE Proc_Staff_BulkInsertion 
	@staffTable StaffTableType READONLY
AS
BEGIN
	
	INSERT INTO Staff
		(Name,PhoneNumber,Salary,HouseName,City,State,PinCode,StaffType,CreatedDate,ModifiedDate)
	SELECT StaffName,PhoneNumber,Salary,HouseName,City,State,PinCode,StaffType,GETDATE(),GETDATE()
		FROM @staffTable

	INSERT INTO TeachingStaff
		(StaffId,Subject,ClassAssigned,CreatedDate,ModifiedDate)
	SELECT S.StaffId,T.Specificdata,T.ClassAssigned,GETDATE(),GETDATE()
		FROM Staff as S INNER JOIN @staffTable as T ON S.Name = T.StaffName AND S.PhoneNumber = T.PhoneNumber AND T.StaffType = 0;


	INSERT INTO AdminStaff
		(StaffId,Post,CreatedDate,ModifiedDate)
	SELECT S.StaffId,T.Specificdata,GETDATE(),GETDATE()
		FROM Staff as S INNER JOIN @staffTable as T ON S.Name = T.StaffName AND S.PhoneNumber = T.PhoneNumber AND T.StaffType = 1;

	INSERT INTO SupportStaff
		(StaffId,Post,CreatedDate,ModifiedDate)
	SELECT S.StaffId,T.Specificdata,GETDATE(),GETDATE()
		FROM Staff as S INNER JOIN @staffTable as T ON S.Name = T.StaffName AND S.PhoneNumber = T.PhoneNumber AND T.StaffType = 2;


END