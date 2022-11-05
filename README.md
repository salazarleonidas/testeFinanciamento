# Teste Financiamento

## Instuções para execução do item 1 do teste

Para executar o back-end usar o comando

> cd TesteCredito/Service/TesteCredito
>
> dotnet run

Para executar o front-end, usar o comando:
> cd teste-credito-front
> 
> npm start

## Instruções o item 2 do teste

A resolução do teste esta no aquivo [ScriptsBancoDados](ScriptsBancoDados.sql). O teste foi feito no Sql Server.
O arquivo contem a criação do banco, das tabelas e dados para realização dos teste, as queries dos itens requisitados estão no final do arquivo.

## Resolução item 3 do teste

Microserviçoes é um design patern arquitetural, onde tem como objetivo criar pequenos serviços atomicos e autosuficiente que podem ser acessados através de API's, sendo suas principais vantagens a escalabilidade e a não dependência de tecnologias, podendo cada microserviço desenvolvido em tecnologias diferentes e se comunicando atraves de um contrato estabelecido.

Por exemplo:
Um cenário como proposto no item 1 do teste, onde um cliente solicita um financiamento. Podemos supor alguns serviços utilizados para a aprovação/rejeição do credito. O usuario(operador) solicita o financiamento para um cliente atraves do portal, esse por sua vez faz um requisição ao serviço FinanciamentoService. Para a análise de credito é necessário, nesse exemplo, fazer:

1. uma requisição ao serviço ClienteService, que retorna o rating financeiro do cliente;
1. uma requisição ao serviço RendaService, que retornará se a renda declarada é consistente;
1. uma requisição ao serviço DocumentoService, que retornará se o documento apresentado é realmente do cliente;

Com base nas informações retornadas pelos serviços e em validações realisadas no serviço FinanciamentoService, teremos o resultado do pedido de crédito.



