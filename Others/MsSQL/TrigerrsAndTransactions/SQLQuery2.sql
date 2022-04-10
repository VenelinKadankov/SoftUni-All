--CREATE TABLE NotificationEmails
--(
--	Id INT IDENTITY PRIMARY KEY,
--	Recipient NVARCHAR(50),
--	Subject NVARCHAR(50),
--	Body NVARCHAR(200)
--)


CREATE OR ALTER TRIGGER tr_OnLogsSendEmailOdDataChange
ON Logs FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP (1) AccountId FROM inserted)
	DECLARE @OldSum DECIMAL = (SELECT TOP (1) OldSum FROM inserted)
	DECLARE @NewSum DECIMAL = (SELECT TOP (1) NewSum FROM inserted)

	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
	( 
	@AccountId,
	'Balance change for account: ' + CAST(@AccountId AS varchar(20)),
	'On ' + CONVERT(VARCHAR(50), GETDATE(), 103) + ' your balance was changed from ' +
	CAST(@OldSum AS VARCHAR(20)) + ' to ' + CAST(@NewSum AS VARCHAR(20))
	)

GO

SELECT * FROM Accounts WHERE Id = 1

UPDATE Accounts SET Balance += 1000 WHERE Id = 1

SELECT * FROM NotificationEmails
