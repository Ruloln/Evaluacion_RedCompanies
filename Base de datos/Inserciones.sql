INSERT INTO aula(
            id, numero, edificio)
    VALUES (1,201,'A'),(2,302,'A'),(3,405,'F');

INSERT INTO profesor(
            id, nombre, apellido,identificacion,aula_id)
    VALUES (1,'Adriana','Vera','MWM987513',1),(2,'Gabriel','Miranda','YTJ321545',1),(3,'Luisa','Sandoval','WM332154',2);

INSERT INTO alumno(
            id, nombre, apellido,cedula,aula_id)
    VALUES (1,'Camila','González','201874856',1),(2,'Emilio','Díaz','201898245',2),(3,'Daniel','Rodríguez','201896384',1),(4,'Fernanda','Martínez','201719745',1),(5,'Javier','Gómez','201896873',3),(6,'María','Romero','201836289',3),(7,'Ximena','Sosa','201874891',1);

INSERT INTO promedio(
            id,promedio)
    VALUES (1,8.2),(2,7.8),(3,9.3),(4,6.4),(5,9.7),(6,8.6),(7,8.1);

INSERT INTO materia(
            id, espaniol, matematicas,historia,ciencias)
    VALUES (1,10,8,8,8),(2,8,8,8,9),(3,9,9,9,10),(4,10,10,10,9),(5,10,9,9,8),(6,10,10,7,8),(7,10,7,7,9);
