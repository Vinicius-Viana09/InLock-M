USE INLOCK;
GO

INSERT INTO STUDIO(nomeStudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo,descricaoJogo,valorJogo,idStudio)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', 'R$ 99,00',1), ('Red Dead Redemption II', 'Jogo
eletr�nico de a��o-aventura western.', 'R$120,00',2)
GO

INSERT INTO USUARIO(emailUsuario,senhaUsuario,tipoUsuario)
VALUES ('admin@admin.com', 'admin', 'ADMINISTRADOR'), ('cliente@cliente.com', 'cliente', 'CLIENTE')
GO