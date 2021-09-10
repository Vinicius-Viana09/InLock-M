CREATE DATABASE INLOCK
GO

USE INLOCK
GO

CREATE TABLE STUDIO(
idStudio SMALLINT PRIMARY KEY IDENTITY,
nomeStudio VARCHAR(25) NOT NULL UNIQUE
);
GO

CREATE TABLE JOGOS(
idJogos INT PRIMARY KEY IDENTITY,
nomeJogo VARCHAR(50) NOT NULL UNIQUE,
dataLancamento VARCHAR(10) NOT NULL,
descricaoJogo VARCHAR(200),
valorJogo VARCHAR (8) NOT NULL,
idStudio SMALLINT FOREIGN KEY REFERENCES STUDIO(idStudio)
);
GO

CREATE TABLE TIPOUSUARIO(
idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
nomeTipoUsuario VARCHAR(15) NOT NULL
);
GO

CREATE TABLE USUARIO(
idUsuario INT PRIMARY KEY IDENTITY,
emailUsuario VARCHAR(50) NOT NULL UNIQUE,
senhaUsuario CHAR(8) NOT NULL,
idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario)
);
GO

DROP TABLE USUARIO

