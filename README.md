# Evaluacion_RedCompanies
CRUD net core framework

Este CRUD esta hecho en .Net core v 6.0 con las herramientas de Visual studio, postman y postgresql

Partimos de crear la tabla de aula ya que esta será la unica tabla que no contenga una llave foranea

CREATE TABLE aula (
	id integer PRIMARY KEY UNIQUE NOT NULL, 
	numero integer ,
	edificio VARCHAR ( 50 ) 
);

la tabla profesor con llave foranea hacia aula

CREATE TABLE profesor (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	nombre VARCHAR ( 50 ) ,
	apellido VARCHAR ( 50 ),
	identificacion VARCHAR ( 50 ),
	aula_id integer,
	FOREIGN KEY (aula_id) REFERENCES aula(id) ON delete cascade
);

y de igual manera alumno

CREATE TABLE alumno (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	nombre VARCHAR ( 50 ) ,
	apellido VARCHAR ( 50 ),
	cedula VARCHAR ( 50 ),
	aula_id integer,
	FOREIGN KEY (aula_id) REFERENCES aula(id) ON delete cascade
);

continuamos con el promedio

CREATE TABLE promedio (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	promedio float ,
	FOREIGN KEY (id) REFERENCES alumno(id) ON delete cascade
);

y terminamos con la nueva tabla del esquema que es materia

CREATE TABLE materia (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	espaniol float ,
	matematicas float ,
	historia float ,
	ciencias float ,
	FOREIGN KEY (id) REFERENCES alumno(id) ON delete cascade
);
Se manejo como columnas el tipo de materia para darles un valor de calificacion a la hora de la consulta

Procedemos a poblar la base con los elementos del archivo Inserciones.sql

INSERT INTO aula(
            id, numero, edificio)
    VALUES (1,201,'A'),(2,302,'A'),(3,405,'F');

INSERT INTO profesor(
            id, nombre, apellido,identificacion,aula_id)
    VALUES (1,'Adriana','Vera','MWM987513',1),(2,'Gabriel','Miranda','YTJ321545',1),(3,'Luisa','Sandoval','WM332154',2);

INSERT INTO alumno(
            id, nombre, apellido,cedula,aula_id)
    VALUES (1,'Camila','GonzÃ¡lez','201874856',1),(2,'Emilio','DÃ­az','201898245',2),(3,'Daniel','RodrÃ­guez','201896384',1),(4,'Fernanda','MartÃ­nez','201719745',1),(5,'Javier','GÃ³mez','201896873',3),(6,'MarÃ­a','Romero','201836289',3),(7,'Ximena','Sosa','201874891',1);

INSERT INTO promedio(
            id,promedio)
    VALUES (1,8.2),(2,7.8),(3,9.3),(4,6.4),(5,9.7),(6,8.6),(7,8.1);

INSERT INTO materia(
            id, espaniol, matematicas,historia,ciencias)
    VALUES (1,10,8,8,8),(2,8,8,8,9),(3,9,9,9,10),(4,10,10,10,9),(5,10,9,9,8),(6,10,10,7,8),(7,10,7,7,9);
    
Y una vez listos con las tablas ya pobladas procedemos a crear el proyecto

Abrimos visual studio

Clickeamos nuevo proyecto

Elegimos ASP dot net core Web API .

![image](https://user-images.githubusercontent.com/13893851/154372149-3115f321-a7d1-4c33-941d-8b6e25174f16.png)

Ahora echemos un vistazo a algunos de los archivos importantes en el proyecto.

launchSettings.json contiene los detalles de cómo se debe iniciar el proyecto.

Las carpeta controllers contienen controladores en los que escribimos nuestros métodos API.

En appSettings.json haremos la conexion a nuestra base de datos

Program.cs contiene el metodo principal de nuestra aplicación.

La clase startup configura todos los servicios necesarios para nuestra aplicación.

Necesitamos hacer un par de cambios en la clase de inicio.

Una es habilitar el CORS.


De forma predeterminada, todos los proyectos de API web vienen con una seguridad que bloquea las solicitudes provenientes de diferentes dominios. Básicamente estamos escribiendo instrucciones para deshabilitar esa seguridad y permitir que se atiendan las solicitudes.
![image](https://user-images.githubusercontent.com/13893851/154372745-0deb35e3-4880-4451-a103-78c19f8a71e3.png)

También es necesario un cambio más en la clase de serializador para mantener el serializador json como nuestro valor predeterminado.

Instalaremos un paquete nuget para hacer esto.
![image](https://user-images.githubusercontent.com/13893851/154372880-52f61b1e-b0fd-4fb4-bc3d-c3605739b47b.png)

Para la conexion a postgres se requiere bajar la dependencia NpgSQL
![image](https://user-images.githubusercontent.com/13893851/154373005-e30f409d-a5ca-4baa-a742-0bad82f69ee7.png)

Se agregan los controladores que seran los encargados de despachar las peticiones y se crean modelos de los elementos a usar (alumno y materia en este caso).

procedemos a crear las funciones trigger que haran actualizaciones directas al promedio

y por ultimo probamos (de preferencia con una api como postman)
los metodos get,post, put y delete



