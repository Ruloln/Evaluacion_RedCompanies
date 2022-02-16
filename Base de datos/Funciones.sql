CREATE OR REPLACE FUNCTION califications_insert_trigger_fnc()

  RETURNS trigger AS

$$

BEGIN



    INSERT INTO "promedio" ( "id", "promedio")

         VALUES(NEW."id", (Select  (Coalesce(espaniol,0) + Coalesce(matematicas,0) + Coalesce(historia,0)+ Coalesce(ciencias,0))  /
       (Coalesce(espaniol/espaniol, 0) + Coalesce(matematicas/matematicas, 0) + Coalesce(historia/historia, 0)+ Coalesce(ciencias/ciencias, 0)) from materia where id=NEW."id")
);



RETURN NEW;

END;

$$

LANGUAGE 'plpgsql';



CREATE TRIGGER califications_insert_trigger

  AFTER INSERT

  ON "materia"

  FOR EACH ROW

  EXECUTE PROCEDURE califications_insert_trigger_fnc();
  CREATE OR REPLACE FUNCTION califications_update_trigger_fnc()

  RETURNS trigger AS

$$

BEGIN



    update "promedio" set promedio=(Select  (Coalesce(espaniol,0) + Coalesce(matematicas,0) + Coalesce(historia,0)+ Coalesce(ciencias,0))  /
       (Coalesce(espaniol/espaniol, 0) + Coalesce(matematicas/matematicas, 0) + Coalesce(historia/historia, 0)+ Coalesce(ciencias/ciencias, 0)) from materia where id="promedio".id)
;



RETURN NEW;

END;

$$

LANGUAGE 'plpgsql';



CREATE TRIGGER califications_update_trigger

  AFTER update

  ON "materia"

  FOR EACH ROW

  EXECUTE PROCEDURE califications_update_trigger_fnc();
