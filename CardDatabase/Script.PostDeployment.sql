/*
Post-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.    
 Use SQLCMD syntax to include a file in the post-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the post-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/

-- Add/Merge Credit Card data

DECLARE @CreditCard AS TABLE (
	CreditCardID int NOT NULL,
	CardName varchar(50) NOT NULL,
	AgeRestriction int,
	AnnualIncomeRestriction int,
	PromotionalMessage varchar(200),
	APR decimal(4, 2),
	ImageFileName varchar(100)
)

INSERT INTO @CreditCard VALUES (1, 'Barclaycard', 18, 30000, 'Barclaycard Rewards gives you 0.25% cashback on your everyday spend both home and abroad, with no limit to the amount you can earn.', 22.90, 'Barclaycard.png')

INSERT INTO @CreditCard VALUES (2, 'Vanquis Visa Classic', 18, NULL, 'Start building your credit today with the Vanquis Classic credit card.', 39.90, 'Vanquis.png')

MERGE CreditCard AS tgt
USING @CreditCard AS src ON (tgt.CreditCardID = src.CreditCardID) 
--When records are matched, update the records if there is any change
WHEN MATCHED AND (EXISTS (SELECT tgt.CardName EXCEPT SELECT src.CardName)) 
	THEN UPDATE SET tgt.CardName = src.CardName, tgt.CardName = src.CardName 
WHEN MATCHED AND (EXISTS (SELECT tgt.AgeRestriction EXCEPT SELECT src.AgeRestriction)) 
	THEN UPDATE SET tgt.AgeRestriction = src.AgeRestriction
WHEN MATCHED AND (EXISTS (SELECT tgt.AgeRestriction EXCEPT SELECT src.AgeRestriction)) 
	THEN UPDATE SET tgt.AnnualIncomeRestriction = src.AnnualIncomeRestriction
WHEN MATCHED AND (EXISTS (SELECT tgt.AgeRestriction EXCEPT SELECT src.AgeRestriction)) 
	THEN UPDATE SET tgt.PromotionalMessage = src.PromotionalMessage
WHEN MATCHED AND (EXISTS (SELECT tgt.APR EXCEPT SELECT src.APR)) 
	THEN UPDATE SET tgt.APR = src.APR
WHEN MATCHED AND (EXISTS (SELECT tgt.ImageFileName EXCEPT SELECT src.ImageFileName)) 
	THEN UPDATE SET tgt.ImageFileName = src.ImageFileName
--When no records are matched, insert the incoming records from source table to target table
WHEN NOT MATCHED BY TARGET
	THEN INSERT (CreditCardID, CardName, AgeRestriction, AnnualIncomeRestriction, PromotionalMessage, APR, ImageFileName) VALUES 
	            (src.CreditCardID, src.CardName, src.AgeRestriction, src.AnnualIncomeRestriction, src.PromotionalMessage, src.APR, src.ImageFileName)
--When there is a row that exists in target and same record does not exist in source then delete this record target
WHEN NOT MATCHED BY SOURCE
THEN DELETE;
