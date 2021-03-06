﻿CREATE TABLE [dbo].[SupportStaff] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [StaffId]      INT           NULL,
    [Post]         NVARCHAR (50) NOT NULL,
    [CreatedDate]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [ModifiedDate] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff] ([StaffId])
);





