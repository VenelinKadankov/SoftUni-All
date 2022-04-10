CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION

	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)
	DECLARE @CurrentAmount INT = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50004, 'Invalid bank account', 1;
		RETURN
	END

	--IF (@CurrentAmount IS NULL)
	--BEGIN
	--	ROLLBACK;
	--	THROW 50001, 'Invalid bank account', 2;
	--	RETURN
	--END

	--	IF (@AccountId IS NULL)
	--BEGIN
	--	ROLLBACK;
	--	THROW 50002, '@AccountId is invalid', 1;
	--	RETURN
	--END

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Amount can not be negative or zero', 1;
		RETURN
	END

	UPDATE Accounts SET Balance = Balance + @MoneyAmount WHERE @AccountId = Id


COMMIT

GO

EXEC usp_DepositMoney 1, 10

SELECT * FROM Accounts WHERE Id = 1

SELECT * FROM Logs

SELECT * FROM NotificationEmails