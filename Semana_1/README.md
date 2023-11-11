
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

- Os tipos numéricos integrais representam números inteiros. Todos os tipos numéricos integrais são tipos de valor. Eles também são tipos simples e podem ser inicializados com literais. 

#### Características dos tipos integrais

O C# é compatível com os seguintes tipos integrais predefinidos:

| Palavra-chave | Tipo de C#                                          | Intervalo                                        | Tamanho                               | Tipo .NET             |
|---------------|-----------------------------------------------------|--------------------------------------------------|----------------------------------------|-----------------------|
| sbyte         | Inteiro de 8 bits com sinal                         | -128 a 127                                      | 8 bits                                | System.SByte          |
| byte          | Inteiro de 8 bits sem sinal                         | 0 a 255                                          | 8 bits                                | System.Byte           |
| short         | Inteiro de 16 bits com sinal                        | -32.768 a 32.767                                | 16 bits                               | System.Int16          |
| ushort        | Inteiro de 16 bits sem sinal                        | 0 a 65.535                                      | 16 bits                               | System.UInt16         |
| int           | Inteiro assinado de 32 bits                         | -2.147.483.648 a 2.147.483.647                  | 32 bits                               | System.Int32          |
| uint          | Inteiro de 32 bits sem sinal                        | 0 a 4.294.967.295                               | 32 bits                               | System.UInt32         |
| long          | Inteiro assinado de 64 bits                         | -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807 | 64 bits                           | System.Int64          |
| ulong         | Inteiro de 64 bits sem sinal                        | 0 a 18.446.744.073.709.551.615                 | 64 bits                               | System.UInt64         |
| nint          | Depende da plataforma (computada em runtime)       | Inteiro de 32 bits ou de 64 bits com sinal      | Depende da plataforma                 | System.IntPtr         |
| nuint         | Depende da plataforma (computada em runtime)       | Inteiro de 32 bits ou de 64 bits sem sinal      | Depende da plataforma                 | System.UIntPtr        |


### Exemplos

class Program
{

    static void Main()
    {

        sbyte valor_sby;
        byte valor_by;
        short valor_sho;
        ushort valor_usho;
        int valor_int;
        uint valor_uint;
        long valor_long;
        ulong valor_ulong;

        valor_sby = sbyte.MinValue;
        valor_by = byte.MaxValue;
        valor_sho = short.MinValue;
        valor_int = int.MaxValue;
        valor_uint = uint.MinValue;
        valor_long = long.MaxValue;
        valor_ulong = ulong.MinValue;

        Console.WriteLine($"O menor valor sbyte é {valor_sby}");
        Console.WriteLine($"O maior valor byte é {valor_by}");
        Console.WriteLine($"O menor valor short é {valor_sho}");
        Console.WriteLine($"O maior valor int é {valor_int}");
        Console.WriteLine($"O menor valor uint é {valor_uint}");
        Console.WriteLine($"O maior valor long é {valor_long}");
        Console.WriteLine($"O menor valor ulong é {valor_ulong}");
    }
}

#### Questão 3 (Conversão de Tipos de Dados)

Usaria a conversão explícita pois precisa especificar explicitamente no código, pois podem resultar em perda de dados ou estouro. Para resolver pode usar o operador de conversão (tipo) para setar o tipo de dados antes da variável. 

        double a = 5.0;
        int b = (int)a;
        
        Console.WriteLine (a);
