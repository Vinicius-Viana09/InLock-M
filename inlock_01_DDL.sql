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
descricaoJogo VARCHAR(200),
valorJogo VARCHAR (8) NOT NULL,
idStudio SMALLINT FOREIGN KEY REFERENCES STUDIO(idStudio)
);
GO

CREATE TABLE USUARIO(
idUsuario INT PRIMARY KEY IDENTITY,
emailUsuario VARCHAR(50) NOT NULL UNIQUE,
senhaUsuario CHAR(8) NOT NULL,
tipoUsuario VARCHAR(15) NOT NULL
);
GO