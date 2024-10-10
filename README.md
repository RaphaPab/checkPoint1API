#CheckPoint 1   API de Cadastro de Pacientes e Planos de Saúde.NET


## Integrantes
- Raphael Pabst rm98525
- Silvio Junior rm550821
- Pedro Braga rm551061
- Eduardo Reis Braga rm551987
- Vinícius Martins Torres Abdala rm99455

## Implementação da API
# Tecnologias Utilizadas:
- ASP.NET Core Web API: Framework de desenvolvimento.
- Banco de dados Oracle: Para operações CRUD (Create, Read, Update, Delete).
- Swagger/OpenAPI: Documentação interativa dos endpoints.
- Padrão de Criação: Usaremos o JSON para o gerenciador de configurações.

# Arquitetura da API

## Objetivo

Desenvolver uma API em C# para gerenciar o cadastro de pacientes e planos de saúde de uma clínica, bem como criar a relação entre pacientes e seus respectivos planos.

---

## Padrão de Criação

Optamos pelo uso do padrão JSON (JavaScript Object Notation) no desenvolvimento de APIs devido aos inúmeros benefícios que ele proporciona, tanto em termos técnicos quanto de usabilidade. Um dos principais motivos é sua ampla compatibilidade. JSON é suportado por praticamente todas as linguagens de programação modernas, o que facilita a integração das APIs com diferentes sistemas e plataformas. Isso significa que independentemente do ambiente em que estejam trabalhando, podemos consumir e produzir dados de forma consistente em outras APIs.

Além disso, o JSON se destaca por sua leveza em comparação a outros formatos, como o XML. Sua estrutura mais simples permite que os dados sejam transmitidos mais rapidamente pela rede, o que contribui diretamente para o melhor desempenho das APIs. Esse fator é especialmente importante em cenários onde há limitações de banda, pois o menor volume de dados trafegando reduz a latência e melhora a experiência do usuário final.

Outro ponto relevante é a flexibilidade oferecida pelo JSON. Por ser um formato adaptável, ele permite que campos e propriedades sejam adicionados ou removidos sem que isso comprometa a compatibilidade com versões anteriores de uma API. Essa característica é fundamental para garantir a evolução contínua dos serviços, permitindo ajustes e melhorias de forma ágil, sem causar interrupções ou falhas na comunicação entre diferentes versões da API. Dessa maneira, o uso de JSON contribui para um desenvolvimento mais eficiente e uma manutenção mais simples das soluções de software.

---


## Descrição do Projeto
- Serão implementados os requisitos abaixo:
 Cadastro de Pacientes:
 Cada paciente deve ter as seguintes informações:
 ● ID(gerado automaticamente)
 ● Nomecompleto
 ● Datadenascimento
 ● CPF
 ● Endereço(rua, número, bairro, cidade, estado, CEP)
 ● Telefone

 Cadastro de Planos de Saúde:
-  Cada plano de saúde deve ter as seguintes informações:
 ● ID(gerado automaticamente)
 ● Nomedoplano
 ● Códigodoplano (identificador único)
 ● Cobertura (ex: Ambulatorial, Hospitalar com Obstetrícia, etc.)

 Relacionamento entre Pacientes e Planos de Saúde:
-  Cada paciente pode estar vinculado a um ou mais planos de saúde.
 AAPI deve permitir:
 ● Associar umpaciente a um plano de saúde
 ● Removeraassociação entre um paciente e um plano de saúde
 ● Listar os planos de saúde associados a um paciente
 ● Listar todos os pacientes associados a um plano de saúde

---
## Como executar a API

**Pré-requisitos**
- .NET 6.0 ou superior
- Banco de Dados Oracle
  
**Passos para Execução**
  1. Clone o repositório:

    git clone https://github.com/RaphaPab/checkPoint1API
     
  3. Configure as variáveis de ambiente com as credenciais de acesso ao banco Oracle.

  4. Execute as migrações do banco de dados:

    dotnet ef database update

  4.Inicie a aplicação:
  
      Clique em https.
      
  ![image](https://github.com/user-attachments/assets/266cf312-9dbc-41ac-9c08-203886ca308b)



---

## Endpoints CRUD

Os endpoints da API seguem o padrão **CRUD** (Create, Read, Update, Delete) para os recursos:

- **Pacientes**
- **PlanosSaude**
- **PacientePlanoSaude**

Cada recurso interage com o banco de dados **Oracle** utilizando o **Entity Framework Core**, garantindo a integração e manipulação de dados de forma eficiente. Os seguintes métodos RESTful são implementados:

- **GET**: Recupera recursos.
- **POST**: Cria novos recursos.
- **PUT**: Atualiza recursos existentes.
- **DELETE**: Exclui recursos.


















