# DrinkOrDareApi

Criação de uma API para um projeto da faculdade. O projeto consiste em um site para jogar verdade ou desafio, porém com uma virada, essa virada seria que na realidade o jogo seria beba ou desafio.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Pré-requisitos

Para fazer funcionar você precisa de ambiente de desenvolvimento de API (recomendo o Postman).

## Testar

Caso você tenha baixado o postman este link irá adicionar ao seu postman uma coleção de chamadas para a API já prontas: https://www.getpostman.com/collections/90060e9e770b6a80d257.

Caso não insira a seguinte URL antes dos comandos fornecidos abaixo: https://drinkordareapi.azurewebsites.net

### Comandos

Para simplicar os comandos irei me referênciar à URL como {URL}.

#### {URL}/Users/Login

Este end-point será de login de usuários já cadastrados.

Nele é necessário enviar junto com a requisição um json com o seguinte formato:

{
	"Email": "seu email",
	"Password": "sua senha"
}	

#### {URL}/Users/Register

Este end-point será para cadastrar usuários no site.

Nele é necessário enviar junto com a requisição um json com o seguinte formato:

{
	"Email": "seu email",
	"DisplayName": "seu nome de display",
	"Password": "sua senha"
}	

#### {URL}/Users/TempLogin

Este end-point será de login de usuários não cadastrados.

Nele é necessário enviar junto com a requisição um json com o seguinte formato:

{
	"DisplayName": "seu nome de display"
}	

Nas três primeiras chamadas a resposta, caso seja de sucesso irá retornar um json com suas informações e um SessionToken, você necessitará dele para as próxima chamadas, então não esqueca de salva-lo.

Para facilitar vou me referênciar ao SessionToken como {ST}

#### {URL}/Dares

Este end-point será para obter o desafio, a quantidade de shots que deverá tomar caso não cumpra com o desafio e os pontos que irá receber ao terminar algum dos dois.

Nele é necessário enviar junto com a requisição um parametro no header com o seguinte formato:

{
  "uk":"{ST}"
}

#### {URL}/Users

Este end-point será para obter as informações sobre o usuário.

Nele é necessário enviar junto com a requisição um parametro no header com o seguinte formato:

{
  "uk":"{ST}"
}

#### {URL}/Users({id})

Este end-point será para obter as informações sobre qualquer usuário com base no id deste usuário.

Nele é necessário enviar na requisição o id do usuário aonde está {id} e junto com essa requisição um parametro no header com o seguinte formato:

{
  "uk":"{ST}"
}

Obrigado.
