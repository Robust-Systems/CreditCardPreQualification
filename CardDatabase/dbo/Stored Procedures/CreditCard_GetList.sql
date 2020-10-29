-- =============================================
-- Author:		Iftikhar Siddique
-- Create date: 29th October 2020
-- Description:	Returns list of all credit cards.
-- =============================================
CREATE PROCEDURE CreditCard_GetList 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		C.CreditCardID, 
		C.CardName,
		C.AgeRestriction,
		C.AnnualIncomeRestriction,
		C.PromotionalMessage,
		C.APR,
		IsDefault = CAST(ISNULL(D.CreditCardID, 0) AS BIT)
	FROM CreditCard C LEFT OUTER JOIN DefaultCreditCard D ON C.CreditCardID = D.CreditCardID

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[CreditCard_GetList] TO [webuser]
    AS [dbo];

