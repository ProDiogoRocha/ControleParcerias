CREATE TRIGGER TGR_PARCERIA_LIKE
ON ParceriaLike
AFTER INSERT
AS
BEGIN
    DECLARE
    @LIKE  INT,
	@CODPARCERIA INT,
	@QTDLIKES INT

	SET @CODPARCERIA = (SELECT TOP 1 CodigoParceria FROM ParceriaLike ORDER BY Codigo DESC);
	SET @LIKE = (SELECT QtdLikes FROM Parceria WHERE Codigo = @CODPARCERIA);
	SET @QTDLIKES = @LIKE + 1;

    UPDATE Parceria SET QtdLikes = @QTDLIKES WHERE Codigo = @CODPARCERIA;
END