SELECT COUNT(*) AS Count
	FROM WizzardDeposits


SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits



SELECT TOP (2) DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)


SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup


SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM (  SELECT DepositGroup , MagicWandCreator, DepositAmount
			FROM WizzardDeposits
			WHERE MagicWandCreator = 'Ollivander family') AS K
	GROUP BY DepositGroup


SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM (  SELECT DepositGroup , MagicWandCreator, DepositAmount
			FROM WizzardDeposits
			WHERE MagicWandCreator = 'Ollivander family') AS K
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC



SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup


SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount
	FROM
		(SELECT
			CASE  
				WHEN Age BETWEEN 0 AND 10
					THEN '[0-10]'
				WHEN Age < 20
					THEN '[11-20]'
				WHEN Age < 30
					THEN '[21-30]'
				WHEN Age < 40 
					THEN '[31-40]'
				WHEN Age < 50
					THEN '[41-50]'
				WHEN Age < 60
					THEN '[51-60]'
				WHEN Age >= 60
					THEN '[60+]'
				ELSE NULL
			END AS AgeGroup
			FROM WizzardDeposits) AS K
	GROUP BY AgeGroup



SELECT FirstLetter
	FROM
	(SELECT LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest') AS K
	GROUP BY FirstLetter
	ORDER BY FirstLetter