# Projeto de API - Gerenciamento de Produtos

Este projeto � uma API desenvolvida em .NET Core 8 para gerenciamento de produtos. A API permite a cria��o, leitura, atualiza��o e exclus�o de produtos em um banco de dados MySQL.

## Sum�rio

- [Pr�-requisitos](#pr�-requisitos)
- [Instala��o](#instala��o)
- [Configura��o](#configura��o)
- [Execu��o](#execu��o)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Uso](#uso)
- [Testes](#testes)
- [Contribui��es](#contribui��es)
- [Licen�a](#licen�a)

## Pr�-requisitos

Antes de iniciar, voc� precisar� ter as seguintes ferramentas instaladas em sua m�quina:

- [.NET Core SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/) (ou outro banco de dados suportado)
- [Git](https://git-scm.com/)
- Um editor de c�digo, como [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

## Instala��o

1. 1. **Clone o reposit�rio**

   Clone o reposit�rio do projeto em sua m�quina local:

   ```bash
   git clone https://github.com/programdor1805/Projeto-BackAnd-Entrevista.git
   cd seu-repositorio
   
2. **Restaurar pacotes NuGet**

	 Navegue at� o diret�rio do projeto e execute o comando abaixo para restaurar os pacotes necess�rios:
	```bash
	dotnet restore
	

3. **Configurar o banco de dados**

	Certifique-se de que o MySQL est� instalado e em execu��o. Crie um banco de dados para o projeto:

	```SQL
    CREATE DATABASE ecommerce_produto_api;

	Crie as Tabelas:

     USE ecommerce_produto_api;
    
    CREATE TABLE Departamento (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Codigo VARCHAR(50),
        Descricao VARCHAR(300) 
    );
    
    -- Cria��o da tabela Produto
    CREATE TABLE Produto (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Codigo VARCHAR(50),
        Descricao VARCHAR(300) ,
        DepartamentoId INT,
        Preco DECIMAL ,
        Status BOOLEAN ,
        FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
    );

