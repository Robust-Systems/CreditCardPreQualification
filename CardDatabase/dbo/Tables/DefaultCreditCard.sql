CREATE TABLE [dbo].[DefaultCreditCard] (
    [Lock]         CHAR (1) CONSTRAINT [DF_DefaultCreditCard_Lock] DEFAULT ('X') NOT NULL,
    [CreditCardID] INT      NOT NULL,
    CONSTRAINT [PK_DefaultCreditCard] PRIMARY KEY CLUSTERED ([Lock] ASC),
    CONSTRAINT [CK_DefaultCreditCard_Lock] CHECK ([Lock]='X'),
    CONSTRAINT [FK_DefaultCreditCard_CreditCard] FOREIGN KEY ([CreditCardID]) REFERENCES [dbo].[CreditCard] ([CreditCardID])
);

