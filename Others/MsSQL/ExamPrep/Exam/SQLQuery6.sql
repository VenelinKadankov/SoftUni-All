SELECT Description, C.Name
	FROM Reports R
	JOIN Categories C ON C.Id = R.CategoryId
	WHERE CategoryId IS NOT NULL
	ORDER BY Description, C.Name