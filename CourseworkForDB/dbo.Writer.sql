CREATE TABLE [dbo].[Writer] (
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [Patronymic] NVARCHAR (50)  NOT NULL,
    [Address]    NVARCHAR (100) NOT NULL,
    [Telephone]  NVARCHAR (20)  NOT NULL
	PRIMARY KEY CLUSTERED ([ID] ASC), 
    [ID] INT NOT NULL,
	CONSTRAINT [FK_Writer_ToTable] FOREIGN KEY ([ID]) REFERENCES [dbo].[Contract] ([IdContract]) ON DELETE CASCADE ON UPDATE CASCADE
);

