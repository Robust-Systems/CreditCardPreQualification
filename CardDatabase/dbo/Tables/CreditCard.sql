CREATE TABLE [dbo].[CreditCard] (
    [CreditCardID]            INT            IDENTITY (1, 1) NOT NULL,
    [CardName]                VARCHAR (50)   NOT NULL,
    [AgeRestriction]          INT            NULL,
    [AnnualIncomeRestriction] INT            NULL,
    [PromotionalMessage]      VARCHAR (200)  NULL,
    [APR]                     DECIMAL (4, 2) NULL,
    CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED ([CreditCardID] ASC),
    CONSTRAINT [UK_CreditCard_CardName] UNIQUE NONCLUSTERED ([CardName] ASC)
);

