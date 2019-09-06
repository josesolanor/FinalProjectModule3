Feature: AddTransaction
	Como un cliente de API web (no humano)
	Requiero agregar una transaccion mi saldo actual

Scenario: Realizando una Transaccion
	Given Que soy un cliente no humano http
	When Cargo los datos de TYPE 'Deposit' AMOUNT 100
	And Hago un request POST hacia el url de realizar transaccion
	Then Recibo una respuesta con el valor http 201
