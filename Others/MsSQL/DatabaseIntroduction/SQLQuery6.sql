
CREATE TABLE People
(
	Id TINYINT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(4,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(2) NOT NULL,
	Birthday DATE NOT NULL,
	Biography VARCHAR(MAX)
)

--DROP TABLE People

INSERT INTO People 
([Name], Picture, Height, [Weight], Gender, Birthday, Biography) 
VALUES
('Pesho', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', 1.90, 90.5, 'm', '1/12/1900', 'usfbbgeukngkshbf'),
('Gosho', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', 1.90, 90.5, 'm', '1/12/1900', 'usfbbgeukngkshbf'),
('Tosho', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', 1.90, 90.5, 'm', '1/12/1900', 'usfbbgeukngkshbf'),
('Losho', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', 1.90, 90.5, 'm', '1/12/1900', 'usfbbgeukngkshbf'),
('Iosho', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSs-LYMmSq5Grt_zXV6R73IE73aK297CFShRQ&usqp=CAU', 1.90, 90.5, 'm', '1/12/1900', 'usfbbgeukngkshbf')
