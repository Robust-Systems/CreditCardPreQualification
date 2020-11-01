-- =============================================
-- Author:		Iftikhar Siddique
-- Create date: 30th October 2020
-- Description:	Returns credit card by ID.
-- =============================================
CREATE PROCEDURE CreditCard_Get
	@CreditCardID INT 
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
		C.ImageFileName
	FROM CreditCard C 
	WHERE
		C.CreditCardID = @CreditCardID

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[CreditCard_Get] TO [webuser]
    AS [dbo];

