-- =============================================
-- Author:		Iftikhar Siddique
-- Create date: 29th October 2020
-- Description:	Adds credit card application to ApplicationLog.
-- =============================================
CREATE PROCEDURE [dbo].[ApplicationLog_Add] 
	@FirstName			AS VARCHAR(100),
	@LastName				AS VARCHAR(100),
	@DateOfBirth		AS DATE,
	@AnnualIncome		AS INT,
	@CreditCardID		AS INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ApplicationLog 
	(
		FirstName,
		LastName,
		DateOfBirth,
		AnnualIncome,
		CreditCardID
	) 
	VALUES 
	(
		@FirstName,
		@LastName,
		@DateOfBirth,
		@AnnualIncome,
		@CreditCardID
	) 

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ApplicationLog_Add] TO [webuser]
    AS [dbo];

