CREATE TABLE Users 
(
	Id TINYINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL, 
	[Password] VARCHAR(26),
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

DROP TABLE Users

INSERT INTO Users
(Username, Password, ProfilePicture, LastLoginTime,IsDeleted)
VALUES
('Pesho', 'pass123', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', '12/3/1900', 0),
('Gosho', 'pass123', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', '12/3/1900', 0),
('Tosho', 'pass123', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', '12/3/1900', 0),
('Losho', 'pass123', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', '12/3/1900', 0),
('Fosho', 'pass123', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', '12/3/1900', 0)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0707A9A205

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername
PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_PasswordIsAtLeast5CharsLong CHECK Password.Length > 5
