USE INLOCK;
GO

INSERT INTO STUDIO(nomeStudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo,descricaoJogo,valorJogo,idStudio)
VALUES ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', 'R$ 99,00',1), ('Red Dead Redemption II', 'Jogo
eletrônico de ação-aventura western.', 'R$120,00',2)
GO

INSERT INTO USUARIO(emailUsuario,senhaUsuario,tipoUsuario)
VALUES ('admin@admin.com', 'admin', 'ADMINISTRADOR'), ('cliente@cliente.com', 'cliente', 'CLIENTE')
GO