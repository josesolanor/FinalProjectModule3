# Proyecto Final Modulo 3 – Prueba de software – QTesting

_Autor: Jose G Solano Romero_

_Proyecto final para el modulo 3 Prueba de software Qtesting_
_La implementación de todos los niveles de pruebas en el diagrama piramidal, es decir Pruebas Unitarias, Pruebas de Integración y Prueba de UI automatizadas._

La implementacion del proyecto y sus pruebas se desarrollaron bajo tecnologia Microsoft de la siguiente manera:

* Aplicacion API - Asp.net API Core 2.2
* Aplicacion Cliente - Asp.net MVC Core 2.2 
* Cliente Tester API - MSTest
* Cliente Teste Cliente - NUnit, Specflow

## Pre-requisitos e Instalacion 📋

Para poder ejecutar el proyecto y sus pruebas se puede utilizar diferentes herramientas (las mas recomendadas):

* Visual Studio 2019
* Visual Studio Code

Para ambas herramientas es necesario tener ciertos paquetes y librerias instaladas

### Visual Studio 
_Cualquier version, Visual studio solo soporta Windows y Mac_

Para poder ejecutar correctamente el proyecto en el IDE [Visual Studio](https://visualstudio.microsoft.com/es/downloads/), este debe ser instalado con las siguientes herramientas de desarrollo

![image](https://user-images.githubusercontent.com/43735720/64465903-f139f280-d0dc-11e9-9deb-014da2f7a541.png)

Tambien debemos tener instalado el SDK de Core 2.2 (Esto suele venir incluido en la version 2019)

[.NET Core 2.2 SDK](https://dotnet.microsoft.com/download)

para verificar que el Core 2.2 SDK se haya instalado correctamente solo debemos ejecutar en la consola (cmd, powershell, bash, etc..) la siguiente linea

```
dotnet --version
```
La version debe ser 2.2.X

### Visual Studio Code

Debe instalarse el Editor de texto [Visual Studio Code](https://visualstudio.microsoft.com/es/downloads/)

Tambien debemos tener instalado el SDK de Core 2.2

[.NET Core 2.2 SDK](https://dotnet.microsoft.com/download)

Una vez instalado Visual Studio Code, se debe instalar las siguientes Extensiones (Para visualizar mejor las pruebas)

[Dotnet Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)

Tambien la extension (En caso de no instalarse automaticament) de lenguaje c#

[VSCode Csharp](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

## Cargando el proyecto 🔧

Se debe clonar el proyecto del repositorio [Github](https://github.com/josesolanor/FinalProjectModule3) y ser abierto por un IDE o Editor de texto

La solucion cuenta con cuatro proyectos: un cliente MVC, un Web services y dos Test Client

## Ejecutando API y Cliente 🚀

### Visual Studio

Una vez tengamos abierto el proyecto en el IDE Visual Studio debemos configurar el IDE para ejecutar dos proyectos a la vez

Nos vamos a la Solucion("Wallet") > Click Derecho y nos vamos a "Propiedades"

En la ventana emergente, vamos al menu "Propiedades Comunes" > "Proyecto de inicio"

Dentro marcamos "Proyectos de inicio multiples" y en "Apiwallet" y "ClientWallet" elegimos como Accion > Iniciar
Finalmente Aplicamos.
![image](https://user-images.githubusercontent.com/43735720/64466899-5ba16180-d0e2-11e9-933f-d32b1ff06b27.png)

Ahora podemos ejecutar los dos proyectos a la vez Apretando la tecla F5 o el Boton "Iniciar"

### Visual Studio Code

Una vez tengamos abierto el proyecto en el Editor de texto VS Code debemos abrir una terminal por proyecto _ejemplo_

![image](https://user-images.githubusercontent.com/43735720/64465600-9227ae00-d0db-11e9-84bc-708bbb1e9e66.png)

Dentro de cada terminal,  debemos acceder a las carpetas de las soluciones

Para el proyecto Web Services 
```
cd ApiWallet/
```

Para el proyecto Cliente
```
cd ClientWallet/
```

Y para inicializar cada proyecto debemos ejecutar el siguiente comando en cada terminal
```
dotnet run
```

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
