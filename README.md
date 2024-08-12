# Projeto de API - Gerenciamento de Produtos

Este projeto é uma API desenvolvida em .NET Core 8 para gerenciamento de produtos. A API permite a criação, leitura, atualização e exclusão de produtos em um banco de dados MySQL.

## Sumário

- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)

## Pré-requisitos

Antes de iniciar, você precisará ter as seguintes ferramentas instaladas em sua máquina:

- [.NET Core SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/) (ou outro banco de dados suportado)
- [Git](https://git-scm.com/)
- Um editor de código, como [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

## Instalação

1. **Clone o repositório**

   Clone o repositório do projeto em sua máquina local:

   ```bash
   git clone https://github.com/programdor1805/Projeto-BackAnd-Entrevista.git
   cd seu-repositorio
   
2. **Restaurar pacotes NuGet**

	 Navegue até o diretório do projeto e execute o comando abaixo para restaurar os pacotes necessários:
	```bash
	dotnet restore
	

3. **Configurar o banco de dados**

	Certifique-se de que o MySQL está instalado e em execução. Crie um banco de dados para o projeto:

	```SQL
    CREATE DATABASE ecommerce_produto_api;	

     USE ecommerce_produto_api;
    
    CREATE TABLE Departamento (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Codigo VARCHAR(50),
        Descricao VARCHAR(300) 
    );
    
    -- Criação da tabela Produto
    CREATE TABLE Produto (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Codigo VARCHAR(50),
        Descricao VARCHAR(300) ,
        DepartamentoId INT,
        Preco DECIMAL ,
        Status BOOLEAN ,
        FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
    );

    
## Configuração

1.  **Atualizar as configurações do banco de dados**

      No arquivo appsettings.json, atualize a string de conexão para apontar para o banco de dados que você acabou de criar:
 
	```json
      "MySQlConnection": {
        "MySQlConnectionString": "Server=localhost;DataBase=ecommerce_produto_api;Uid=root;Pwd=root"
      }

