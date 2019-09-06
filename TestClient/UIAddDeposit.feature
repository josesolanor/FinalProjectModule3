Feature: UIAddDeposit
	Como Usuario Final (humano)
	Quiero registrar una transaccion de tipo deposito

Scenario: Registro un deposito
	Given El monto de 10 bolivianos
	When Navego a la pagina principal
	And Hago click en el boton Depositar
	And Lleno el campo del monto a depositar
	And Hago click en Aceptar
	Then Se debe actualizar el saldo
