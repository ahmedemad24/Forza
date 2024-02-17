USE [CYPOSDb]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[EncryptData]
		@StartDate = '2023-10-11',
		@EndDate = '2023-11-20',
		@NumberDevices = 4,
		@EncryptedKey = N'E$Pn9Tb6VQ8j#gK1&zXy4Fc7RmW2h5L!'

SELECT	'Return Value' = @return_value

GO
