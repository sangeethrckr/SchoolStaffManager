CREATE TABLE [dbo].[Staff] (
    [StaffId]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [PhoneNumber]  NVARCHAR (50) NOT NULL,
    [Salary]       DECIMAL (18)  NOT NULL,
    [HouseName]    NVARCHAR (50) NOT NULL,
    [City]         NVARCHAR (50) NOT NULL,
    [State]        NVARCHAR (50) NOT NULL,
    [PinCode]      NVARCHAR (50) NOT NULL,
    [StaffType]    TINYINT       NOT NULL,
    [CreatedDate]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [ModifiedDate] DATETIME      DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([StaffId] ASC)
);





