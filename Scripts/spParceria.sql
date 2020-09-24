CREATE OR ALTER PROCEDURE spParceria
(
	@Codigo INT = 0,
	@Titulo VARCHAR(255) = '',
	@Descricao TEXT = '',
	@URLPagina VARCHAR(1000) = '',
	@Empresa VARCHAR(40) = '',
	@DataInicio DATE = NULL,
	@DataTermino DATE = NULL,
	@QtdLikes INT = 0,
	@DataHoraCadastro DATETIME = NULL,
	@TipoTransacao VARCHAR(7) = ''
)
AS 
BEGIN
DECLARE @CONSULTA VARCHAR(MAX)

	IF @TipoTransacao = 'INSERT'
		BEGIN
			SET @CONSULTA = 'INSERT INTO Parceria (Titulo, Descricao, URLPagina, Empresa, DataInicio, DataTermino, QtdLikes, DataHoraCadastro)
					VALUES(
							  '''+@Titulo+'''
							, '''+CAST(@Descricao as VARCHAR(MAX))+'''
							, '''+@URLPagina+'''
							, '''+@Empresa+'''
							, '''+CAST(@DataInicio AS VARCHAR(MAX))+'''
							, '''+CAST(@DataTermino AS VARCHAR(MAX))+'''
							, '+CAST(@QtdLikes AS VARCHAR(2))+'
							, '''+CAST(GETDATE() AS VARCHAR(MAX))+''')';
		END

	IF @TipoTransacao = 'UPDATE'
		BEGIN
			SET @CONSULTA = 'UPDATE Parceria SET 
								Titulo = '''+@Titulo+''', 
								Descricao = '''+CAST(@Descricao as VARCHAR(MAX))+''', 
								URLPagina = '''+@URLPagina+''', 
								Empresa = '''+@Empresa+''', 
								DataInicio = '+CAST(@DataInicio AS VARCHAR(MAX))+', 
								DataTermino = '+CAST(@DataTermino AS VARCHAR(MAX))+', 
								QtdLikes = '+@QtdLikes+', 
								DataHoraCadastro = '+CAST(@DataHoraCadastro AS VARCHAR(MAX))+
								'WHERE Codigo = '+@Codigo
		END

	IF @TipoTransacao = 'DELETE'
		BEGIN
			SET @CONSULTA = 'DELETE Parceria WHERE Codigo = '+CAST(@Codigo AS VARCHAR(2));
		END

	EXEC(@CONSULTA);
END