-- =============================================
-- Author:		Iftikhar Siddique
-- Create date: 29th October 2020
-- Description:	Returns list of all credit card applicants.
-- =============================================
CREATE PROCEDURE [dbo].[ApplicationLog_GetList] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ApplicationLogID, 
		FirstName,
		LastName,
		DateOfBirth,
		AnnualIncome,
		EligibleCreditCard,
		DateApplied
	FROM ApplicationLog

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ApplicationLog_GetList] TO [webuser]
    AS [dbo];

