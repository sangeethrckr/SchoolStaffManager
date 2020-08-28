CREATE TABLE [dbo].[Teachers] (
    [StaffId]       INT           NOT NULL,
    [Subject]       NVARCHAR (50) NOT NULL,
    [ClassAssigned] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([StaffId] ASC),
    CONSTRAINT [FK__Teachers__StaffI__3B75D760] FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff] ([StaffId])
);

