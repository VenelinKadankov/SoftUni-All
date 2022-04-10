SELECT j.JobId, IIF(SUM(op.Quantity * p.Price) IS NULL, 0, SUM(op.Quantity * p.Price)) AS Price
	FROM Jobs j
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
	WHERE j.Status = 'Finished'
	GROUP BY j.JobId
	ORDER BY Price DESC, j.JobId