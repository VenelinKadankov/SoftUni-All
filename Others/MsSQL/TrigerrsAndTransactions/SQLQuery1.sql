--CREATE TABLE Logs 
--(	LogId INT IDENTITY PRIMARY KEY, 
--	AccountId INT NOT NULL REFERENCES Accounts(Id) , 
--	OldSum MONEY NOT NULL,
--	NewSum MONEY NOT NULL
--) 

--CREATE TABLE LogsWithTime 
--(	LogId INT IDENTITY PRIMARY KEY, 
--	AccountId INT NOT NULL REFERENCES Accounts(Id) , 
--	OldSum MONEY NOT NULL,
--	NewSum MONEY NOT NULL,
--	DateOfChange DATETIME
--) 

--CREATE OR ALTER TRIGGER tr_OnAccountChangeOnBalance
--ON Accounts FOR UPDATE
--AS
--	INSERT Logs(AccountId, OldSum, NewSum)
--	SELECT i.Id, d.Balance, i.Balance
--		FROM deleted d
--		JOIN inserted i ON i.Id = d.Id
--		WHERE i.Balance != d.Balance


--GO

--UPDATE Accounts SET Balance = Balance + 2222 WHERE Id = 5

--SELECT *
--	FROM Logs


CREATE TRIGGER tr_OnAccountChangeOnBalance
ON Accounts FOR UPDATE
AS
	DECLARE @NewSum DECIMAL (36,2) = (SELECT Balance FROM inserted)
	DECLARE @OldSum DECIMAL (36,2) = (SELECT Balance FROM deleted)
	DECLARE @AccountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs(AccountId, NewSum, OldSum) VALUES (@AccountId, @NewSum, @OldSum)

GO

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT * FROM Logs