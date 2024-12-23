# Bottle

A API foi desenvolvida em python com a utilização do Flask como framework. Também foi utilizado o YOLO para detecção de objetos e sua classificação.

As dependências da aplicação se encontram no arquivo:
> requirements.txt


O código do treinamento se encontra dentro da pasta:
> [Train](train)

## 1. Modelo Treinado

O modelo utilizado foi treinado com YOLO, detectando a tampa e o bico inteiro da garrafa. Consideramos que a garrafa está fechada quando é encontrado o bico e a tampa. Posteriormente pode ser feito mais tratamentos para identificiar se a tampa está no bico da garrafa, pois neste momento, se uma tampa fora do bico da garrafa for encontrada, o sistema identificará como uma garrafa fechada. Isso é um ponto de melhoria.

Foi colocado o modelo em um link do OneDrive pelo fato do seu tamanho ser maior que o GitHub permite.


### Segue abaixo o link do modelo treinado:
> [link modelo](https://1drv.ms/u/c/25c1ffdcff23db20/EbEWmFG5FFJGsEz9eP7CsE4BGWlUllcvYwr-tc1V88d-RQ?e=T1No8n)




## 2. Arquivo de configuração

Utilizamos um arquivo Dotenv (.env) para configurar parâmetros na API. Este arquivo se encontra no diretório raiz da aplicação.

Foi utilizado os seguintes parametros:

##### **PORT**
> Neste parâmetro, deve ser colocado a porta para acesso ao EndPoint da API

##### **MODEL**
> Neste parâmetro, deve ser colocado o caminho do arquivo do modelo treinado que foi baixado do link

##### **TH_CONFIDENCE_CAP**
> Neste parâmetro, deve ser um valor de Threshold para a detecção das tampas das garrafas

##### **TH_CONFIDENCE_BOTTLE**
> Neste parâmetro, deve ser um valor de Threshold para a detecção dos bicos das garrafas

##### **LOG_FILE_PATH** 
> Neste parâmetro, deve ser colocado o caminho para salvar o arquivo de Log da API

##### **LOG_DISABLE** 
> Neste parâmetro, podemos desabilitar a geração do LOG quando o valor dele é 1. Em qualquer outro caso, o LOG fica habilitado.



### Exemplo do arquivo de configuração (.env):

```
PORT = 2525
MODEL=content\models\garrafa.pt
TH_CONFIDENCE_CAP = 0.65
TH_CONFIDENCE_BOTTLE = 0.50
LOG_FILE_PATH = bottle.log 
LOG_DISABLE = 1
```
## 3. Consumindo API

O EndPoint da API gerada deve ser executada através de POST.

A url deve estar na seguinte formatação:
> http://endereço:porta//bottle

Um exemplo desta url executada localmente:
> http://localhost:2525/bottle


No BODY da requisição, deve-se mandar a imagem de forma binária com o seguinte Key: **image**

Podemos ver um exemplo executando no Postman:



![](/images/postman.png)




## 4. Retorno da API

A API retorna o seguinte JSon:
```
{
    "Bottle_Status": "close",
    "Confidence": 0.8229029774665833,
    "ElapsedTime": "0:00:00.339860",
    "BoxCap": [
        146.03700256347656,
        107.1209945678711,
        183.2393035888672,
        132.18280029296875
    ]
}
```



## 5. Aplicativo de testes

Foi desenvolvido uma aplicação windows em .NET para testar o consumo da API. 

Esta aplicação possui seu código publicado dentro da pasta DotNET do repositório.

Foi gerado um vídeo dando uma explicação simples do aplicativo de testes no seguinte link:

>  [link do vídeo no youtube](https://youtu.be/xPoQhEEQ7IY)


## 6. Treinamento

O treinamento foi feito através do YOLO. Devido a limitação de tempo, se treinou com poucas imagens. Seria interessante rotular mais imagens e retreinar.

O treinamento foi bem simples, com pouco código, através da utilização de 30 épocas. O resultado alcançado foi rasoavel, podendo melhorar muito com treinamento com um dataset maior.

Futuramente, pode-se pensar em gerar um classificador através de modelos pré-treinados com a execução de transfer learning para garantir que a tampa se encontra na garrafa a qual foi detectado o bico ou então a extração de outras caracteristicas com modelos de classificação tradicional'

O arquivo que de configuração do treinamento se encontra no seguinte endereço:
> train\yoloBottleTrain.yaml

Dentro da pasta **train\trainFiles** se encontra os arquivos de imagens e labels para treinamento e validação. 

O arquivo pré treinado do YOLO **yolo11x.pt** pode ser baixado no link a seguir:
>  [YOLO 11x](https://github.com/ultralytics/assets/releases/download/v8.3.0/yolo11x.pt)
