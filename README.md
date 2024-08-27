<h2>Dados do projeto: Api de estudo em ASP.NET v4.8</h2>

<h2>Banco de dados: MySQL</h2>

<h2>Códigos para criação do banco, das tabelas e inserts:</h2>

CREATE DATABASE testeapi;

CREATE TABLE fontes (
fonteID INT AUTO_INCREMENT PRIMARY KEY,
parametros VARCHAR(100)
);

CREATE TABLE motorista (
    MotoristaID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(11) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    Endereco VARCHAR(255),
    Telefone VARCHAR(15),
    Email VARCHAR(100) NOT NULL UNIQUE,
    DataCadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE carro (
    CarroID INT AUTO_INCREMENT PRIMARY KEY,
    MotoristaID INT NOT NULL,
    Placa VARCHAR(7) NOT NULL UNIQUE,
    Modelo VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    AnoFabricacao YEAR NOT NULL,
    Cor VARCHAR(50),
    Chassi VARCHAR(17) UNIQUE,
    DataCadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MotoristaID) REFERENCES Motorista(MotoristaID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-liquido-agua");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-liquido-diesel");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-liquido-gasolina");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-liquido-suco");

INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-solido-madeira");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-solido-metal");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-solido-plastico");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem aerobica-solido-cimento");

INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-liquido-agua");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-liquido-diesel");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-liquido-gasolina");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-liquido-suco");

INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-solido-madeira");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-solido-metal");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-solido-plastico");
INSERT INTO fontes (parametros) VALUES ("compostagem-compostagem anaerobica-solido-cimento");

INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-liquido-agua");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-liquido-diesel");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-liquido-gasolina");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-liquido-suco");

INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-solido-madeira");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-solido-metal");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-solido-plastico");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao aerobica-solido-cimento");

INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-liquido-agua");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-liquido-diesel");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-liquido-gasolina");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-liquido-suco");

INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-solido-madeira");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-solido-metal");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-solido-plastico");
INSERT INTO fontes (parametros) VALUES ("incineracao-incineracao anaerobica-solido-cimento");

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('João Silva', '12345678901', '1985-05-10', 'Rua A, 123, São Paulo, SP', '11987654321', 'joao.silva@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Maria Oliveira', '23456789012', '1990-08-15', 'Rua B, 456, Rio de Janeiro, RJ', '21987654321', 'maria.oliveira@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Carlos Souza', '34567890123', '1982-12-20', 'Rua C, 789, Belo Horizonte, MG', '31987654321', 'carlos.souza@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Ana Pereira', '45678901234', '1975-03-30', 'Rua D, 101, Curitiba, PR', '41987654321', 'ana.pereira@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Pedro Costa', '56789012345', '1995-07-25', 'Rua E, 202, Salvador, BA', '51987654321', 'pedro.costa@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Lucas Almeida', '67890123456', '1988-11-12', 'Rua F, 303, Porto Alegre, RS', '51987654322', 'lucas.almeida@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Fernanda Lima', '78901234567', '1992-09-17', 'Rua G, 404, Recife, PE', '81987654323', 'fernanda.lima@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Rafael Santos', '89012345678', '1980-02-22', 'Rua H, 505, Fortaleza, CE', '85987654324', 'rafael.santos@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Juliana Ferreira', '90123456789', '1993-06-28', 'Rua I, 606, Manaus, AM', '92987654325', 'juliana.ferreira@email.com');

INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email)
VALUES ('Bruno Rocha', '01234567890', '1986-01-15', 'Rua J, 707, Brasília, DF', '61987654326', 'bruno.rocha@email.com');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (1, 'ABC1234', 'Civic', 'Honda', 2020, 'Preto', '9BG116GW04C400001');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (2, 'XYZ5678', 'Corolla', 'Toyota', 2019, 'Branco', '8BR123FR00D400002');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (3, 'DEF9012', 'Fiesta', 'Ford', 2018, 'Prata', '7BG216AW06F400003');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (4, 'GHI3456', 'Golf', 'Volkswagen', 2021, 'Azul', '6BG356BW09G400004');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (5, 'JKL7890', 'Cruze', 'Chevrolet', 2022, 'Vermelho', '5BG456AW08H400005');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (6, 'MNO1234', 'Sentra', 'Nissan', 2020, 'Cinza', '4BG556CW07I400006');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (7, 'PQR5678', 'Duster', 'Renault', 2019, 'Verde', '3BG656DW06J400007');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (8, 'STU9012', 'Kicks', 'Nissan', 2021, 'Amarelo', '2BG756EW05K400008');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (9, 'VWX3456', 'Compass', 'Jeep', 2022, 'Laranja', '1BG856FW04L400009');

INSERT INTO Carro (MotoristaID, Placa, Modelo, Marca, AnoFabricacao, Cor, Chassi)
VALUES (10, 'YZA7890', 'HR-V', 'Honda', 2019, 'Branco', '0BG956GW03M400010');
