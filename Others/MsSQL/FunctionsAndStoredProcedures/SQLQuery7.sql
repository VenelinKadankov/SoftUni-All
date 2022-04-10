CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @Counter INT = LEN(@word);
	DECLARE @StartPoint INT = 1;
	DECLARE @TrueOrFalse BIT = 1;

	DECLARE @Substring NVARCHAR(50) = SUBSTRING(@word, @StartPoint, @Counter) ;

	WHILE(@Counter > 0)
	BEGIN
		DECLARE @Symbol NVARCHAR(2) = LEFT(@Substring, 1);

		IF @setOfLetters LIKE ('%' + @Symbol + '%')
			SET @TrueOrFalse = 1;
		ELSE 
		BEGIN
			SET @TrueOrFalse = 0;
			BREAK;
		END

		SET @Counter = @Counter - 1;
		SET @StartPoint = @StartPoint + 1;
		SET @Substring = SUBSTRING(@word, @StartPoint, @Counter);

	END

	RETURN @TrueOrFalse
END

GO

SELECT dbo.ufn_IsWordComprised ('bobr','Guy')