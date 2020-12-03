Funcionalidade: Client
	

Esquema do Cenario: Obter cliente inexistente e existente
	Dado que o endpoint é 'Client/GetById'
	E que o método http é 'Get'
	E que o id é <id>
	Quando obter o cliente
	Então a resposta sera <resposta>

	Exemplos:
		| id | resposta |
		| 1  | 200      |
		

Esquema do Cenario: Cadastrar cliente
	Dado que o endpoint é 'Client/Create'
	E que o método http é 'Post'
	E que o nome é 'Maria'
	E que o cpf é '12345678912'
	E que o hash é '7246b94a-220c-4641-bee0-9216707d5969'
	Quando criar o cliente
	Então a resposta sera 201 