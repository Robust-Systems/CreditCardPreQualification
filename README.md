# Credit Card pre-Qualification Web Application  

A basic web based pre-qualification tool for credit cards, implemented in MVC and C#.  

## Instructions  

- Download the code zip file:  
https://github.com/Robust-Systems/CreditCardPreQualification/archive/master.zip  

- or clone Git repository:  
https://github.com/Robust-Systems/CreditCardPreQualification.git  

- Open solution CreditCardPreQualification in Visual Studio 2019.  

- set project BankWebApp as startup project  

- create a temporary database on SQL server instance e.g. CreditCardPreQualification  

- build the solution  

- publish the CardDatabase project against the CreditCardPreQualification database  

- on SQL Server set the webuser login with a password e.g. b4n4n4  

- in BankWebApp project set connection string 'BankWebAppConnection' to point to the CreditCardPreQualification database with appropriate credentials e.g. user: webuser, password: b4n4n4  

- press Ctrl+F5 to run web app without debugging 

## Key Menu Options  

**Apply for Credit Card** brings up form to apply for a credit card and upon submission shows which card the applicant qualifies for  

**Application Log** shows the applications' history  
