# Bottle

## 1. Modelo Treinado

O modelo utilizado foi treinado com YOLO, detectando a tampa e o bico inteiro da garrafa. Consideramos que a garrafa está fechada quando é encontrado o bico e a tampa. Posteriormente pode ser feito mais tratamentos para identificiar se a tampa está no bico da garrafa, pois neste momento, se uma tampa fora do bico da garrafa for encontrada, o sistema identificará como uma garrafa fechada. Isso é um ponto de melhoria.

Foi colocado o modelo em um link do OneDrive pelo fato do seu tamanho ser maior que o GitHub permite.


### Segue abaixo o link do modelo treinado:
- [link modelo](https://1drv.ms/u/c/25c1ffdcff23db20/EbEWmFG5FFJGsEz9eP7CsE4BGWlUllcvYwr-tc1V88d-RQ?e=T1No8n)


## 2. Arquivo de configuração

Utilizamos um arquivo Dotenv (.env) para configurar parâmetros na API. Este arquivo se encontra no diretório raiz da aplicação.

Foi utilizado os seguintes parametros:

#### **PORT**
> Neste parâmetro, deve ser colocado a porta para acesso ao EndPoint da API

**MODEL**
> Neste parâmetro, deve ser colocado o caminho do arquivo do modelo treinado que foi baixado do link

**TH_CONFIDENCE_CAP**
> Neste parâmetro, deve ser um valor de Threshold para a detecção das tampas das garrafas

**TH_CONFIDENCE_BOTTLE**
> Neste parâmetro, deve ser um valor de Threshold para a detecção dos bicos das garrafas

**LOG_FILE_PATH** 
> Neste parâmetro, deve ser colocado o caminho para salvar o arquivo de Log da API





_italico_

__negrito__

~~riscado~~

**_negrito italico_**