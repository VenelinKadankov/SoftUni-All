--SELECT DepositGroup,  IsDepositExpired , AVG(DepositInterest) AS AverageInterest
--	FROM WizzardDeposits
--	WHERE DepositStartDate > '1985-01-01'
--	GROUP BY DepositGroup, IsDepositExpired
--	ORDER BY DepositGroup DESC, IsDepositExpired


--SELECT BusinessEntityID, YEAR(QuotaDate) AS SalesYear, SalesQuota AS CurrentQuota,   
--    LEAD(SalesQuota, 1,0) OVER (ORDER BY YEAR(QuotaDate)) AS NextQuota  
--FROM Sales.SalesPersonQuotaHistory  
--WHERE BusinessEntityID = 275 AND YEAR(QuotaDate) IN ('2005','2006');  

SELECT SUM([Difference])
	FROM	
		(SELECT Id, DepositAmount - LEAD (DepositAmount, 1, 0) OVER (ORDER BY Id) AS [Difference]
		FROM WizzardDeposits) AS K		
	WHERE Id < ( SELECT  MAX(Id) FROM WizzardDeposits)

	-- и двете са верни за 12-та

SELECT SUM(DIFFERENCE) AS SumDifference
	FROM
		(SELECT h.DepositAmount - g.DepositAmount as [Difference]
		FROM WizzardDeposits h
		JOIN WizzardDeposits g ON g.Id = h.Id + 1) as k
