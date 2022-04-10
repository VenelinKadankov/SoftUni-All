CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
DECLARE @result DECIMAL(15,2)

SET @result = (SELECT SUM(IIF((op.Quantity * p.Price) IS NULL, 0, (op.Quantity * p.Price))) AS [Price]
	FROM Jobs j
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
	WHERE j.JobId = @jobId)

RETURN @result

END

SELECT dbo.udf_GetCost(1)