
![.NET_logo](https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/100px-Microsoft_.NET_logo.svg.png)


## Respostas

#### Questão 1 (Configuração do Ambiente)

- Verificar a versão do .NET SDK instalada:

No ambiente Linux, para saber a versão do .NET SDK é necessário abrir o terminal e digitar o  seguinte comando:

`dotnet --version`

Se o mesmo estiver instalado irá aparecer no terminal a versão instalada. Caso contrário aparecerá um erro no terminal e precisará instalá-lo.

- Listar as versões do .NET SDK instaladas:

`dotnet --list-sdks`

Este comando lista todas as versões do .NET SDK instaladas no sistema.

- Remover uma versão específica do .NET SDK:

`sudo rm -rf /usr/share/dotnet/sdk/{version}` (Caminho que o SDK está instalado)

Substitua `{version}` pela versão específica que deseja remover.

- Atualizar para a versão mais recente do .NET SDK:

Executando os comandos para verificar a versão atual, de listar para saber as versões instaladas e executar posteriormente a de instalar, para obter a versão mais recente:

`dotnet --version`  (Verifique a versão atual)
`dotnet --list-sdks`  (Liste as versões instaladas)

Se houver uma versão mais recente disponível, você pode instalá-la usando o seguinte comando:

`dotnet --install-sdk`

(Este comando instala a versão mais recente disponível do .NET SDK)


#### Questão 2 (Tipos de Dados)





## Referência

 - [Documentação do .NET](https://learn.microsoft.com/pt-br/dotnet/fundamentals/)
 - [balta.io](https://balta.io/blogdotnet-instalacao-configuracao-e-primeiros-passos)

