CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(36,4))
AS
BEGIN TRANSACTION
	
	DECLARE @SendersAccount DECIMAL(36,4) = (SELECT Balance FROM Accounts WHERE Id = @SenderId)
	DECLARE @ReceiversAccount DECIMAL(36,4) = (SELECT Balance FROM Accounts WHERE Id = @ReceiverId)

	IF (@SendersAccount IS NULL OR @ReceiversAccount IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid accounts information.', 1
	END

	IF (@Amount <= 0)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Amount can not be negative or zero.', 1
	END

	UPDATE Accounts SET Balance -= @Amount WHERE Id = @SenderId
	UPDATE Accounts SET Balance += @Amount WHERE Id = @ReceiverId

COMMIT

GO

EXEC usp_TransferMoney 1, 2, 66.66