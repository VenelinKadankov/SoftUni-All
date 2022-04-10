SELECT FirstName,
	LastName,
	FORMAT(BirthDate, 'MM-dd-yyyy'),
	C.Name,
	Email
	FROM Accounts A
	JOIN Cities C ON C.Id = A.CityId
	WHERE LEFT(Email, 1) = 'e'
	ORDER BY C.Name