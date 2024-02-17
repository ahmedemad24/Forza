USE [CYPOSDb]
GO
/****** Object:  StoredProcedure [dbo].[DecryptData]    Script Date: 10/11/2023 8:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DecryptData]
    @EncryptedValue VARBINARY(MAX),
	@EncryptedKey NVARCHAR(100) 
AS
BEGIN
    DECLARE @DecryptedValue NVARCHAR(MAX);

    -- Decrypt the data using the same passphrase
    SET @DecryptedValue = DECRYPTBYPASSPHRASE(@EncryptedKey, @EncryptedValue);

    -- Display the decrypted value
    DECLARE @Delimiter NVARCHAR(5) = '#|||#';

    DECLARE @FirstDelimiterIndex INT = CHARINDEX(@Delimiter, @DecryptedValue);
    DECLARE @SecondDelimiterIndex INT = CHARINDEX(@Delimiter, @DecryptedValue, @FirstDelimiterIndex + LEN(@Delimiter));

    DECLARE @StartDatePart NVARCHAR(MAX);
    DECLARE @EndDatePart NVARCHAR(MAX);
    DECLARE @NumberDevicesPart NVARCHAR(MAX);

    -- Extract StartDate
    IF @FirstDelimiterIndex > 0
        SET @StartDatePart = SUBSTRING(@DecryptedValue, 1, @FirstDelimiterIndex - 1);

    -- Extract EndDate
    IF @SecondDelimiterIndex > 0 AND @FirstDelimiterIndex > 0
        SET @EndDatePart = SUBSTRING(@DecryptedValue, @FirstDelimiterIndex + LEN(@Delimiter), @SecondDelimiterIndex - @FirstDelimiterIndex - LEN(@Delimiter));

    -- Extract NumberDevices
    IF @SecondDelimiterIndex > 0
        SET @NumberDevicesPart = SUBSTRING(@DecryptedValue, @SecondDelimiterIndex + LEN(@Delimiter), LEN(@DecryptedValue));

    -- Convert parts to appropriate data types
    DECLARE @ParsedStartDate DATETIME = NULL;
    DECLARE @ParsedEndDate DATETIME = NULL;
    DECLARE @ParsedNumberDevices INT = NULL;

    IF @StartDatePart IS NOT NULL
        SET @ParsedStartDate = CAST(@StartDatePart AS DATETIME);

    IF @EndDatePart IS NOT NULL
        SET @ParsedEndDate = CAST(@EndDatePart AS DATETIME);

    IF @NumberDevicesPart IS NOT NULL
        SET @ParsedNumberDevices = CAST(@NumberDevicesPart AS INT);

    -- Display parsed components
    SELECT 
        @ParsedStartDate AS StartDate,
        @ParsedEndDate AS EndDate,
        @ParsedNumberDevices AS NumberDevices;
END;
GO
/****** Object:  StoredProcedure [dbo].[EncryptData]    Script Date: 10/11/2023 8:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EncryptData]
    @StartDate DATETIME,
    @EndDate DATETIME,
    @NumberDevices INT,
	@EncryptedKey NVARCHAR(100)
AS
BEGIN
    DECLARE @OriginalValue NVARCHAR(MAX) = CONVERT(NVARCHAR(MAX), @StartDate, 121) + '#|||#' + 
                             CONVERT(NVARCHAR(MAX), @EndDate, 121) + '#|||#' + 
                             CAST(@NumberDevices AS NVARCHAR(MAX));

    DECLARE @EncryptedValue VARBINARY(MAX);

    -- Encrypt the data using the passphrase
    SET @EncryptedValue = ENCRYPTBYPASSPHRASE(@EncryptedKey, @OriginalValue);

    -- Display the encrypted value
    SELECT @EncryptedValue AS EncryptedValue;


	--IF (SELECT TOP 1 ExpireDate FROM SettingTable) IS NULL
	--BEGIN
	--	INSERT INTO SettingTable (ExpireDate)
	--	VALUES (@EncryptedValue);
	--END
	--ELSE
	--BEGIN
	--	UPDATE SettingTable
	--	SET ExpireDate = @EncryptedValue
	--	WHERE Id = (SELECT TOP 1 Id FROM SettingTable);
	--END

END;
GO
