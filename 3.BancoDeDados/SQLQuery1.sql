-- 3.3 Queries estruturação das tabelas
-- 3.4 Queries para importação dos arquivos .csv com encoding apropriado
-- Pelo fato de haverem muitos dados a serem importados, pode ocorrer de demorar um pouco

USE TesteNivelamento
GO

-- CREATING TABLES


-- IMPORTING FILES
-- 1T2024 FILE

CREATE TABLE [1T2024] (
	[ID] UNIQUEIDENTIFIER PRIMARY KEY,
	[DATA] DATE NOT NULL,
	REG_ANS INT NOT NULL,
	CD_CONTA_CONTABIL INT NOT NULL,
	DESCRICAO NVARCHAR(MAX) NOT NULL,
	VL_SALDO_INICIAL DECIMAL(18, 2) NOT NULL,
	VL_SALDO_FINAL DECIMAL(18, 2) NOT NULL
);
	CREATE TABLE #TempTabela (
		Coluna1 VARCHAR(255), -- DATA
		Coluna2 VARCHAR(255), -- REG_ANS
		Coluna3 VARCHAR(255), -- CD_CONTA_CONTABIL
		Coluna4 NVARCHAR(MAX), -- DESCRICAO
		Coluna5 VARCHAR(255), -- VL_SALDO_INICIAL
		Coluna6 VARCHAR(255)  -- VL_SALDO_FINAL
	);

	BULK INSERT #TempTabela
	FROM 'C:\Users\lucas\Downloads\Files\1T2024\1T2024.csv'
	WITH (
		FORMAT = 'CSV',
		FIELDTERMINATOR = ';',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2, -- Ignora cabeçalho
		CODEPAGE = '65001' -- Para suporte UTF-8
	);

	INSERT INTO [1T2024] (
		[ID],
		[DATA], 
		REG_ANS, 
		CD_CONTA_CONTABIL, 
		DESCRICAO, 
		VL_SALDO_INICIAL, 
		VL_SALDO_FINAL
	)
	SELECT 
		NEWID(),
		TRY_CONVERT(DATE, Coluna1),
		TRY_CONVERT(INT, Coluna2),
		TRY_CONVERT(INT, Coluna3),
		Coluna4,
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna5, ',', '.')),
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna6, ',', '.'))
	FROM #TempTabela;
	GO
	DROP TABLE #TempTabela;
GO


-- 2T2024 FILE

CREATE TABLE [2T2024] (
	[ID] UNIQUEIDENTIFIER PRIMARY KEY,
	[DATA] DATE NOT NULL,
	REG_ANS INT NOT NULL,
	CD_CONTA_CONTABIL INT NOT NULL,
	DESCRICAO NVARCHAR(MAX) NOT NULL,
	VL_SALDO_INICIAL DECIMAL(18, 2) NOT NULL,
	VL_SALDO_FINAL DECIMAL(18, 2) NOT NULL
);
	CREATE TABLE #TempTabela2 (
		Coluna1 VARCHAR(255), -- DATA
		Coluna2 VARCHAR(255), -- REG_ANS
		Coluna3 VARCHAR(255), -- CD_CONTA_CONTABIL
		Coluna4 NVARCHAR(MAX), -- DESCRICAO
		Coluna5 VARCHAR(255), -- VL_SALDO_INICIAL
		Coluna6 VARCHAR(255)  -- VL_SALDO_FINAL
	);

	BULK INSERT #TempTabela2
	FROM  'C:\Users\lucas\Downloads\Files\2T2024\2T2024.csv'
	WITH (
		FORMAT = 'CSV',
		FIELDTERMINATOR = ';', 
		ROWTERMINATOR = '\n', 
		FIRSTROW = 2, -- Ignora cabeçalho
		CODEPAGE = '65001' -- Para suporte UTF-8
	);

	INSERT INTO [2T2024] (
		[ID],
		[DATA], 
		REG_ANS, 
		CD_CONTA_CONTABIL, 
		DESCRICAO, 
		VL_SALDO_INICIAL, 
		VL_SALDO_FINAL
	)
	SELECT 
		NEWID(),
		TRY_CONVERT(DATE, Coluna1),
		TRY_CONVERT(INT, Coluna2),
		TRY_CONVERT(INT, Coluna3),
		Coluna4,
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna5, ',', '.')),
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna6, ',', '.'))
	FROM #TempTabela2;
	DROP TABLE #TempTabela2;
GO


-- 3T2024 FILE
CREATE TABLE [3T2024] (
	[ID] UNIQUEIDENTIFIER PRIMARY KEY,
	[DATA] DATE NOT NULL,
	REG_ANS INT NOT NULL,
	CD_CONTA_CONTABIL INT NOT NULL,
	DESCRICAO VARCHAR(MAX) NOT NULL,
	VL_SALDO_INICIAL DECIMAL(18, 2) NOT NULL,
	VL_SALDO_FINAL DECIMAL(18, 2) NOT NULL
);

	CREATE TABLE #TempTabela3 (
		Coluna1 VARCHAR(255), -- DATA
		Coluna2 VARCHAR(255), -- REG_ANS
		Coluna3 VARCHAR(255), -- CD_CONTA_CONTABIL
		Coluna4 NVARCHAR(MAX), -- DESCRICAO
		Coluna5 VARCHAR(255), -- VL_SALDO_INICIAL
		Coluna6 VARCHAR(255)  -- VL_SALDO_FINAL
	);

	BULK INSERT #TempTabela3
	FROM  'C:\Users\lucas\Downloads\Files\3T2024\3T2024.csv'
	WITH (
		FORMAT = 'CSV',
		FIELDTERMINATOR = ';', 
		ROWTERMINATOR = '\n', 
		FIRSTROW = 2, -- Ignora cabeçalho
		CODEPAGE = '65001' -- Para suporte UTF-8
	);

	INSERT INTO [3T2024] (
			[ID],
			[DATA], 
			REG_ANS, 
			CD_CONTA_CONTABIL, 
			DESCRICAO, 
			VL_SALDO_INICIAL, 
			VL_SALDO_FINAL
		)
	SELECT 
		NEWID(),
		TRY_CONVERT(DATE, Coluna1),
		TRY_CONVERT(INT, Coluna2),
		TRY_CONVERT(INT, Coluna3),
		Coluna4,
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna5, ',', '.')),
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna6, ',', '.'))
	FROM #TempTabela3;
	DROP TABLE #TempTabela3;
GO


-- 4T2024 FILE
CREATE TABLE [4T2024] (
	[ID] UNIQUEIDENTIFIER PRIMARY KEY,
	[DATA] DATE NOT NULL,
	REG_ANS INT NOT NULL,
	CD_CONTA_CONTABIL INT NOT NULL,
	DESCRICAO VARCHAR(MAX) NOT NULL,
	VL_SALDO_INICIAL DECIMAL(18, 2) NOT NULL,
	VL_SALDO_FINAL DECIMAL(18, 2) NOT NULL
);

	CREATE TABLE #TempTabela4 (
		Coluna1 VARCHAR(255), -- DATA
		Coluna2 VARCHAR(255), -- REG_ANS
		Coluna3 VARCHAR(255), -- CD_CONTA_CONTABIL
		Coluna4 NVARCHAR(MAX), -- DESCRICAO
		Coluna5 VARCHAR(255), -- VL_SALDO_INICIAL
		Coluna6 VARCHAR(255)  -- VL_SALDO_FINAL
	);

	BULK INSERT #TempTabela4
	FROM  'C:\Users\lucas\Downloads\Files\4T2024\4T2024.csv'
	WITH (
		FORMAT = 'CSV',
		FIELDTERMINATOR = ';', 
		ROWTERMINATOR = '\n', 
		FIRSTROW = 2, -- Ignora cabeçalho
		CODEPAGE = '65001' -- Para suporte UTF-8
	);

	INSERT INTO [4T2024] (
		[ID],
		[DATA], 
		REG_ANS, 
		CD_CONTA_CONTABIL, 
		DESCRICAO, 
		VL_SALDO_INICIAL, 
		VL_SALDO_FINAL
	)
	SELECT 
		NEWID(),
		TRY_CONVERT(DATE, Coluna1),
		TRY_CONVERT(INT, Coluna2),
		TRY_CONVERT(INT, Coluna3),
		Coluna4,
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna5, ',', '.')),
		TRY_CONVERT(DECIMAL(18,2), REPLACE(Coluna6, ',', '.'))
	FROM #TempTabela4;
	DROP TABLE #TempTabela4;
GO


-- Relatorio_Cadop FILE
CREATE TABLE Relatorio_Cadop
(
	[ID] UNIQUEIDENTIFIER PRIMARY KEY,
	Registro_ANS INT,
	CNPJ CHAR(14),
	Nome_Fantasia VARCHAR(140),
	Razao_Social VARCHAR(140),
	Modalidade VARCHAR(50),
	Logradouro VARCHAR(40),
	Numero INT,
	Complemento VARCHAR(40),
	Bairro VARCHAR(30),
	Cidade VARCHAR(30),
	UF CHAR(2),
	CEP CHAR(8),
	DDD CHAR(2),
	Telefone VARCHAR(20),
	Fax VARCHAR(20),
	Endereco_eletronico VARCHAR(255),
	Representante VARCHAR(50),
	Cargo_Representante VARCHAR(40),
	Regiao_de_Comercializacao INT,
	Data_Registro_ANS DATE
);
	CREATE TABLE #TempTabelarRelatorioCadop (
		[Registro_ANS] [varchar](50) NULL,
		[CNPJ] [varchar](50) NULL,
		[Razao_Social] [varchar](150) NULL,
		[Nome_Fantasia] [varchar](150) NULL,
		[Modalidade] [varchar](50) NULL,
		[Logradouro] [varchar](50) NULL,
		[Numero] [varchar](50) NULL,
		[Complemento] [varchar](50) NULL,
		[Bairro] [varchar](50) NULL,
		[Cidade] [varchar](50) NULL,
		[UF] [varchar](50) NULL,
		[CEP] [varchar](50) NULL,
		[DDD] [varchar](50) NULL,
		[Telefone] [varchar](50) NULL,
		[Fax] [varchar](50) NULL,
		[Endereco_eletronico] [varchar](50) NULL,
		[Representante] [varchar](50) NULL,
		[Cargo_Representante] [varchar](50) NULL,
		[Regiao_de_Comercializacao] [varchar](50) NULL,
		[Data_Registro_ANS] [varchar](50) NULL
	);
		BULK INSERT #TempTabelarRelatorioCadop
		FROM  'C:\Users\lucas\Downloads\Files\Relatorio_cadop.csv'
		WITH (
			FORMAT = 'CSV',
			FIELDTERMINATOR = ';', 
			ROWTERMINATOR = '0x0A', 
			FIRSTROW = 2, -- Ignora cabeçalho
			CODEPAGE = '65001' -- Para suporte UTF-8
		);
		DROP TABLE #TempTabelarRelatorioCadop;

		INSERT INTO [Relatorio_Cadop] (
			[ID],
			Registro_ANS,
			CNPJ,
			Nome_Fantasia,
			Modalidade,
			Logradouro,
			Numero,
			Complemento,
			Bairro,
			Cidade,
			UF,
			CEP,
			DDD,
			Telefone,
			Fax,
			Endereco_eletronico,
			Representante,
			Cargo_Representante,
			Regiao_de_Comercializacao,
			Data_Registro_ANS
		)
		SELECT 
			NEWID(),
			TRY_CONVERT(INT, Registro_ANS),
			CNPJ,
			Nome_Fantasia,
			Modalidade,
			Logradouro,
			TRY_CONVERT(INT, Numero),
			Complemento,
			Bairro,
			Cidade,
			UF,
			CEP,
			DDD,
			Telefone,
			Fax,
			Endereco_eletronico,
			Representante,
			Cargo_Representante,
			TRY_CONVERT(INT, Regiao_de_Comercializacao),
			TRY_CONVERT(DATE, Data_Registro_ANS)
		FROM #TempTabelarRelatorioCadop;
		DROP TABLE #TempTabelarRelatorioCadop;
GO


-- DQL - Data Query Language
SELECT * FROM [1T2024]

-- 10 operadoras com maiores depesas em "EVENTOS/ SINISTROS CONHECIDOS OU AVISADOS DE ASSISTÊNCIA A SAÚDE MEDICO HOSPITALAR" no último semestre
SELECT TOP 10
	ID, [DATA], REG_ANS, CD_CONTA_CONTABIL, DESCRICAO, (VL_SALDO_FINAL - VL_SALDO_INICIAL) AS DESPESA, VL_SALDO_FINAL, VL_SALDO_INICIAL
FROM [1T2024]
ORDER BY DESPESA

-- 10 operadoras com maiores despesas em "EVENTOS/ SINISTROS CONHECIDOS OU AVISADOS DE ASSISTÊNCIA A SAÚDE MEDICO HOSPITALAR" no último ano?
SELECT TOP 10 * FROM(
	SELECT ID, [DATA], REG_ANS, CD_CONTA_CONTABIL, DESCRICAO, (VL_SALDO_FINAL - VL_SALDO_INICIAL) AS DESPESA, VL_SALDO_FINAL, VL_SALDO_INICIAL FROM [1T2024]
	UNION ALL
	SELECT ID, [DATA], REG_ANS, CD_CONTA_CONTABIL, DESCRICAO, (VL_SALDO_FINAL - VL_SALDO_INICIAL) AS DESPESA, VL_SALDO_FINAL, VL_SALDO_INICIAL FROM [2T2024]
	UNION ALL
	SELECT ID, [DATA], REG_ANS, CD_CONTA_CONTABIL, DESCRICAO, (VL_SALDO_FINAL - VL_SALDO_INICIAL) AS DESPESA, VL_SALDO_FINAL, VL_SALDO_INICIAL FROM [3T2024]
	UNION ALL
	SELECT ID, [DATA], REG_ANS, CD_CONTA_CONTABIL, DESCRICAO, (VL_SALDO_FINAL - VL_SALDO_INICIAL) AS DESPESA, VL_SALDO_FINAL, VL_SALDO_INICIAL FROM [4T2024]
) AS todos_trimestres
WHERE(DESCRICAO = 'EVENTOS/ SINISTROS CONHECIDOS OU AVISADOS  DE ASSISTÊNCIA A SAÚDE MEDICO HOSPITALAR')
ORDER BY DESPESA ASC