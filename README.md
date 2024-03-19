

# - Preview de la Prueba Tecnica (ASP.NET CORE 6 & Angular) By:  [Victor Esleiker Diaz Santana](https://www.linkedin.com/in/esleiker-diaz-34a636237/)

## ● Mostrar Suma de ITBIS

![Gif Mostrar Suma Itbis](https://github.com/Eleikel/DGII-Prueba-Tecnica/assets/80076300/2abf9e91-d33b-4568-b945-5fec0f906bda)


## ● Agregar nuevo Contribuyente y Filtrar

![Gif Agregar Contribuyente y Filtrar](https://github.com/Eleikel/DGII-Prueba-Tecnica/assets/80076300/305fee79-6210-4ccc-a54c-797d65cfec07)

## ● Agregar Comprobante Fiscal y verificar el total de Itbis

![Gif Agregar Comprobante Fiscal](https://github.com/Eleikel/DGII-Prueba-Tecnica/assets/80076300/adf7c07c-2091-482a-b47c-b65e38dd2654)

# - Configuración el API (ASP.NET Core 6)

Este README proporciona instrucciones paso a paso para configurar correctamente un proyecto ASP.NET Core 6 API.

## Paso 1: Cambiar el nombre del servidor en la cadena de conexión

1. Abre el archivo `appsettings.json` en el proyecto.
2. Busca la sección `"ConnectionStrings"` y dentro de ella, el campo `"DefaultConnection"`.
3. Modifica el valor del campo `"Server"` con el nombre del servidor al que deseas conectarte.

## Paso 2: Configuración de las migraciones

1. Abre una terminal en la raíz del proyecto.
2. Ejecuta el siguiente comando para crear las migraciones iniciales:

   ```bash
   dotnet ef migrations add InitialCreate
3. Una vez que las migraciones se han creado correctamente, aplica las migraciones a la base de datos con el siguiente comando:
   
   ```bash
   dotnet ef database update

## Paso 3: Ejecutar el proyecto

1. Asegúrate de que estás en el directorio raíz del proyecto.
2. Ejecuta el siguiente comando para iniciar la aplicación:
   
   ```bash
   dotnet run

Esto compilará y ejecutará la aplicación ASP.NET Core 6 API. Una vez iniciada, podrás acceder a la API a través de la URL `https://localhost:7051`




---




# - Configuración del Proyecto Web (Angular)

Este es un proyecto de Angular generado con Angular CLI. Este archivo README proporciona información sobre cómo configurar y ejecutar el proyecto en tu máquina local.

## Requisitos previos

Antes de comenzar, asegúrate de tener instalado lo siguiente en tu máquina:

- Node.js y npm: [Descargar e instalar Node.js](https://nodejs.org/)
- Angular CLI: Ejecuta el siguiente comando para instalarlo globalmente (si aún no lo has hecho):
  
     ```bash
   npm install -g @angular/cli

## Configuración del proyecto

1. Clona este repositorio o descarga el código fuente en tu máquina local.

2. Navega hasta la carpeta del proyecto en tu terminal.

3. Ejecuta el siguiente comando para instalar todas las dependencias del proyecto:
   ```bash
   npm install


## Ejecución del proyecto

Una vez que hayas configurado el proyecto, puedes ejecutarlo localmente con el siguiente comando:
   ```bash
   ng serve
Después de ejecutar este comando, podrás ver tu aplicación en tu navegador web en `http://localhost:4200/`
   
