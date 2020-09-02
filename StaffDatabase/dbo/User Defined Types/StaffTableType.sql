CREATE TYPE [dbo].[StaffTableType] AS TABLE (
    [StaffName]     NVARCHAR (50) NOT NULL,
    [PhoneNumber]   NVARCHAR (50) NOT NULL,
    [Salary]        DECIMAL (18)  NOT NULL,
    [HouseName]     NVARCHAR (50) NOT NULL,
    [City]          NVARCHAR (50) NOT NULL,
    [State]         NVARCHAR (50) NOT NULL,
    [PinCode]       NVARCHAR (50) NOT NULL,
    [StaffType]     TINYINT       NOT NULL,
    [SpecificData]  NVARCHAR (50) NOT NULL,
    [ClassAssigned] NVARCHAR (50) NULL);

