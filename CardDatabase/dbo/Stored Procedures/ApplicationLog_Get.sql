-- =============================================
-- Author:		Iftikhar Siddique
-- Create date: 1st November 2020
-- Description:	Returns a credit card applicant.
-- =============================================
CREATE PROCEDURE [dbo].[ApplicationLog_Get] 
	@ApplicationLogID AS INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ApplicationLogID, 
		FirstName,
		LastName,
		DateOfBirth,
		AnnualIncome,
		CreditCardID,
		DateApplied
	FROM ApplicationLog
	WHERE
		ApplicationLogID = @ApplicationLogID

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ApplicationLog_Get] TO [webuser]
    AS [dbo];

