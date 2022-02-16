CREATE TABLE aula (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	numero integer ,
	edificio VARCHAR ( 50 ) 
);
CREATE TABLE profesor (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	nombre VARCHAR ( 50 ) ,
	apellido VARCHAR ( 50 ),
	identificacion VARCHAR ( 50 ),
	aula_id integer,
	FOREIGN KEY (aula_id) REFERENCES aula(id) ON delete cascade
);

CREATE TABLE alumno (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	nombre VARCHAR ( 50 ) ,
	apellido VARCHAR ( 50 ),
	cedula VARCHAR ( 50 ),
	aula_id integer,
	FOREIGN KEY (aula_id) REFERENCES aula(id) ON delete cascade
);
CREATE TABLE promedio (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	promedio float ,
	FOREIGN KEY (id) REFERENCES alumno(id) ON delete cascade
);

CREATE TABLE materia (
	id integer PRIMARY KEY UNIQUE NOT NULL,
	espaniol float ,
	matematicas float ,
	historia float ,
	ciencias float ,
	FOREIGN KEY (id) REFERENCES alumno(id) ON delete cascade
);
