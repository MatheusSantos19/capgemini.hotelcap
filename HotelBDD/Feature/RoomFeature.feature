Funcionalidade: Room
	Teste Integrado para funcionalidade relacionada ao end-point Room

Esquema do Cenario: Cadastrar Quarto
	Dado que o endpoint é 'Room/Create'
	E que o método http é 'Post'
	E que o andar é 1
	E que o numero do quarto é 10
	E que o situação é A
	E que o tipo do quarto é 7
	Quando criar o quarto
	Então a resposta sera 201

Esquema do Cenario: Obter quarto
	Dado que o endpoint é 'Room/GetById'
	E que o método http é 'Get'
	E que o id é <id>
	Quando obter o quarto
	Então a resposta sera <resposta>

	Exemplos:
		| id | resposta |
		| 1  | 404      |	

Esquema do Cenario: Alterar Quarto
	Dado que o endpoint é 'Room/Update'
	E que o método http é 'Patch'
	E que o id do quarto é 24
	E que o situação é I
	Quando alterar o quarto
	Então a resposta sera 200