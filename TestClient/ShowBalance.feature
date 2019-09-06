Feature: Ver Saldo
	Como un cliente de API web (no humano)
	Requiero verificar mi saldo actual

Scenario: Visualizar mi saldo actual
	Given Que soy un cliente http
	When Hago un request GET hacia el url de mi saldo
	Then Recibo una respuesta con http 200
	And Recibo el valor de mi saldo con valor 100
