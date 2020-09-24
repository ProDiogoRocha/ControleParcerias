CREATE TABLE Parceria
(
	Codigo INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(255) NOT NULL,
	Descricao TEXT NOT NULL,
	URLPagina VARCHAR(1000),
	Empresa VARCHAR(40) NOT NULL,
	DataInicio DATE NOT NULL,
	DataTermino DATE NOT NULL,
	QtdLikes INT NOT NULL,
	DataHoraCadastro DATETIME NOT NULL
)

CREATE TABLE ParceriaLike
(
	Codigo INT PRIMARY KEY IDENTITY NOT NULL,
	CodigoParceria INT NOT NULL,
	DataHoraCadastro DATETIME NOT NULL
)


ALTER TABLE ParceriaLike
ADD CONSTRAINT PARC_PARCLIKE FOREIGN KEY (CodigoParceria) REFERENCES Parceria (Codigo);