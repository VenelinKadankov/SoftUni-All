CREATE PROCEDURE usp_PlaceOrder (@jobId INT, @partSerialNumber VARCHAR(50), @partQty INT)
AS
BEGIN

DECLARE @status VARCHAR(12) = (SELECT Status FROM Jobs WHERE JobId = @jobId)

DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)

IF(@partQty <= 0)
THROW 50012, 'Part quantity must be more than zero!', 1;
ELSE IF(@status IS NULL)
THROW 50013, 'Job not found!', 1;
ELSE IF(@status = 'Finished')
THROW  50011, 'This job is not active!', 1;
ELSE IF(@partId IS NULL)
THROW 50014, 'Part not found!', 1;

DECLARE @ExistingOrderId INT
SET @ExistingOrderId = (SELECT o.OrderId FROM Orders o
								JOIN Jobs j ON j.JobId = o.JobId
								JOIN OrderParts op ON op.OrderId = o.OrderId
								WHERE O.IssueDate IS NULL AND j.JobId = @jobId AND op.PartId = @partId)


IF(@ExistingOrderId IS NULL)
BEGIN 

	INSERT INTO Orders(JobId, IssueDate)
		VALUES (@jobId, NULL);

	SELECT @ExistingOrderId = o.OrderId 
		FROM Orders o
		JOIN Jobs j ON j.JobId = o.JobId
		WHERE o.IssueDate IS NULL AND j.JobId = @jobId

	INSERT INTO OrderParts(OrderId, PartId, Quantity)
		VALUES (@ExistingOrderId, @partId, @partQty)

END
ELSE 
BEGIN
	UPDATE OrderParts
		SET Quantity += @partQty
		WHERE OrderId = @ExistingOrderId
END

END


DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH
