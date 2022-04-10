SELECT c.FirstName + ' ' + c.LastName,
	DATEDIFF(DAY, j.IssueDate, '4/24/2017') AS Days,
	J.Status
	FROM Clients c
	JOIN Jobs j ON j.ClientId = c.ClientId
	WHERE Status != 'Finished'
	ORDER BY Days DESC, c.ClientId