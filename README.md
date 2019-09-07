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

Dentro marcamos "Proyectos de inicio multiples" > en "Apiwallet" y "ClientWallet" elegimos como Accion > Iniciar
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

### Visual Studio

Para ejecutar la pruebas, debemos ir a la pestaña "Prueba" > "Windows" > "Explorador de pruebas" o ejecutar el comando "Ctrl+E, T"

![image](https://user-images.githubusercontent.com/43735720/64467160-f484ac80-d0e3-11e9-8462-ed8d685b8e91.png)

En el "Explorador de pruebas" podemos ver como se cargan todas la pruebas de ambos proyectos, las pruebas unitarias, de integracion y UI

![image](https://user-images.githubusercontent.com/43735720/64467177-3dd4fc00-d0e4-11e9-85b6-2d3a656769bf.png)

Solo deben ejecutarse las pruebas y listo..

OJO _La prueba de UI tiene una manera especial de ejecutarse_

### Visual Studio Code

Si se instalo la extension [Dotnet Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) solo debe seleccionar en la pestaña lateral las pruebas y hacerlas correr

_Es probable que estas no carguen a la primera, puede ser necesario volver a ejecutarlas hasta que estas carguen_

![image](https://user-images.githubusercontent.com/43735720/64467336-a1abf480-d0e5-11e9-83ea-b3418786ffbe.png)

y listo..

OJO _La prueba de UI tiene una manera especial de ejecutarse_

### Prueba de UI automatizada

Finalmente para ejecutar la prueba de Ui automatizada (independiente de si es el IDE o VS Code) primero debe estar ambos proyectos corriendo, tanto el Cliente como la API.

_Esto se debe a que la prueba llama al host de manera local_

Una vez se tenga ambos proyectos corriendo y funcionando, abrimos una terminal en la carpeta root del proyecto "TestClient"

![image](https://user-images.githubusercontent.com/43735720/64467470-cfde0400-d0e6-11e9-94d5-bdac0b07b6e3.png)

y ejecutamos el comando 
```
dotnet test
```
y listo, esto ejecutara la prueba de UI automatizada, añadiendo el valor de 10 al saldo actual.

Gracias!!!...

