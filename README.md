CREATE TABLE `usuarios` (
  `id` int NOT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `cidade` varchar(255) DEFAULT NULL,
  `regiao` varchar(255) DEFAULT NULL,
  `cep` varchar(20) DEFAULT NULL,
  `pais` varchar(100) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL
) 