# Proyecto Final Modulo 3 – Prueba de software – QTesting

_Autor: Jose G Solano Romero_

_Proyecto final para el modulo 3 Prueba de software Qtesting_
_La implementación de todos los niveles de pruebas en el diagrama piramidal, es decir Pruebas Unitarias, Pruebas de Integración y Prueba de UI automatizadas._

La implementacion del proyecto y sus pruebas se desarrollaron bajo tecnologia Microsoft de la siguiente manera:

* Aplicacion API - Asp.net API Core 2.2
* Aplicacion Cliente - Asp.net MVC Core 2.2 
* Cliente Tester API - MSTest
* Cliente Teste Cliente - NUnit, Specflow

### Pre-requisitos 📋



[Dropwizard](http://www.dropwizard.io/1.0.2/docs/)
Gran parte del proyecto

* Cualquier célula viva con menos de dos vecinos vivos muere.
* Cualquier célula viva con dos o tres vecinos vivos sigue viviendo para la siguiente generación.
* Cualquier célula viva con más de tres vecinos vivos muere (cantidad maxima 8 vecinos en una grilla).
* Cualquier célula muerta con exactamente tres vecinos vivos se convierte en una célula viva.

### Instalaccion 🔧

_Para poder hacer correr el proyecto es necesario las siguientes herramientas_

* Python 3.7.
* Editor de texto o IDE (Visual Studio, Visual Studio Code, PyCharm, etc..).
* Un Entorno de Python (Puede ser el por defecto, o uno creado por el IDE)
* Tener instalado en el Entorno UnitTest para realizar las pruebas

### Ejecutando API y Cliente 🚀

_Clonar o descargar el proyecto desde el GitHub, de prefencia con un IDE que soporte o tenga integracion con Python_

_El IDE utilizado fue Visual Studio 2019 Enterprise, con modificaciones para trabajar con Python_

_En caso de usar editor de texto, abrir la carpeta del proyecto._


## Ejecutando las pruebas ⚙️

Si se utiliza un IDE, deberia reconocer las pruebas como tal, en caso de no realizarlo solo se debe referenciar el archivo "TestGameOfLife.py"

Si se utiliza un Editor de texto, es recomendable instalar una extension de prueba de python.

Si no se cuenta con una extension del editor de texto, o desea realizarlo mediante consola debe seguir los siguientes pasos:

Abrir la consola de sistema(cmd, bash, windows PowerShell, etc) y crear un entorno de python

```
$ python -m venv mi-entorno-virtual
```

Teniendo el Entorno Activado, dentro de la carpeta del proyecto, ejecutar el archivo de pruebas

```
$ py TestGameOfLife.py
```

Y podremos visualizar los resultados de las pruebas!!
