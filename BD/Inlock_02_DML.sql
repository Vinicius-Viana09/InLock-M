USE INLOCK;
GO

INSERT INTO STUDIO(nomeStudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo,dataLancamento,descricaoJogo,valorJogo,idStudio)
VALUES ('Diablo 3', '15/5/2012', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', 'R$ 99,00',1), ('Red Dead Redemption II', '26/10/2018', 'Jogo
eletr�nico de a��o-aventura western.', 'R$120,00',2)
GO

INSERT INTO TIPOUSUARIO(nomeTipoUsuario)
VALUES ('ADMINISTRADOR'), ('CLIENTE')
GO

INSERT INTO USUARIO(emailUsuario,senhaUsuario,idTipoUsuario)
VALUES ('admin@admin.com', 'admin',1), ('cliente@cliente.com', 'cliente',2)
GO