USE INLOCK;
GO

INSERT INTO STUDIO(nomeStudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo,dataLancamento,descricaoJogo,valorJogo,idStudio)
VALUES ('Diablo 3', '15/5/2012', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', 'R$ 99,00',1), ('Red Dead Redemption II', '26/10/2018', 'Jogo
eletrônico de ação-aventura western.', 'R$120,00',2)
GO

INSERT INTO TIPOUSUARIO(nomeTipoUsuario)
VALUES ('ADMINISTRADOR'), ('CLIENTE')
GO

INSERT INTO USUARIO(emailUsuario,senhaUsuario,idTipoUsuario)
VALUES ('admin@admin.com', 'admin',1), ('cliente@cliente.com', 'cliente',2)
GO