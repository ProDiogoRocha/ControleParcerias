CREATE OR ALTER PROCEDURE spParceriaLike
(
	@CodigoParceria INT = 0
)
AS 
BEGIN
	INSERT INTO ParceriaLike (CodigoParceria, DataHoraCadastro) VALUES(@CodigoParceria, GETDATE());
END