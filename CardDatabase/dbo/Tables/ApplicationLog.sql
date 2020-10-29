CREATE TABLE [dbo].[ApplicationLog] (
    [ApplicationLogID]   INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]          VARCHAR (100) NULL,
    [LastName]           VARCHAR (100) NOT NULL,
    [DateOfBirth]        DATE          NOT NULL,
    [AnnualIncome]       INT           NOT NULL,
    [EligibleCreditCard] VARCHAR (50)  NOT NULL,
    [DateApplied]        SMALLDATETIME CONSTRAINT [DF_ApplicationLog_DateApplied] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ApplicationLog] PRIMARY KEY CLUSTERED ([ApplicationLogID] ASC)
);

