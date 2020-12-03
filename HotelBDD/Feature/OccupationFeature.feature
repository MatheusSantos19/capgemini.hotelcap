Funcionalidade: Occupation
			

Esquema do Cenario: Cadastrar Ocupacao
	Dado que o endpoint é 'Occupation/Create'
	E que o método http é 'Post'
	E que a quantidade de diaria é 1
	E que a data é 2020-02-25
	E que o id do cliente é 1
	E que o id do quarto ocupacao é 24
	Quando criar a ocupacao
	Então a resposta sera 201


	