CREATE TABLE [dbo].[ApplicationLog] (
    [ApplicationLogID]   INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]          VARCHAR (100) NULL,
    [LastName]           VARCHAR (100) NOT NULL,
    [DateOfBirth]        DATE          NOT NULL,
    [AnnualIncome]       INT           NULL,
    [CreditCardID]       INT           NULL,
    [DateApplied]        SMALLDATETIME CONSTRAINT [DF_ApplicationLog_DateApplied] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ApplicationLog] PRIMARY KEY CLUSTERED ([ApplicationLogID] ASC), 
    CONSTRAINT [FK_ApplicationLog_CreditCard] FOREIGN KEY ([CreditCardID]) REFERENCES [CreditCard]([CreditCardID])
);

