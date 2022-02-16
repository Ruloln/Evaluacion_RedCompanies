using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using Evaluacion_RedCompanies.Models;

namespace Evaluacion_RedCompanies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class alumnoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public alumnoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select al.id as ""Id"",
                        al.nombre as ""Nombre"",
                        al.apellido as ""Apellido"",
                        al.cedula as ""Cedula"",
                        concat (p.nombre, ' ', p.apellido) AS ""profesor"" ,
                        concat (a.numero, ' ', a.edificio) AS ""aula"",
                        m.espaniol as ""Espaniol"",
                        m.matematicas as ""Matematicas"",
                        m.historia as ""Historia"",
                        m.ciencias as ""Ciencias"",
                        prom.promedio as ""Promedio""
                        from alumno al
            INNER JOIN profesor p 
    ON p.aula_id = al.aula_id
INNER JOIN aula a 
    ON al.aula_id = a.id
INNER JOIN promedio prom 
    ON prom.id = al.id
INNER JOIN materia m 
    ON al.id = m.id
";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EvalAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            string JSONString = string.Empty;
            JSONString =  JsonConvert.SerializeObject(table);
            return new JsonResult(JSONString);
        }


        [HttpPost]
        public JsonResult Post(alumno a)
        {
            string query = @"
                insert into alumno (id, nombre, apellido,cedula,aula_id) 
                values   (@id,@nombre, @apellido, @cedula,@aula_id) 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EvalAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", a.id);
                    myCommand.Parameters.AddWithValue("@nombre", a.nombre);
                    myCommand.Parameters.AddWithValue("@apellido", a.apellido);
                    myCommand.Parameters.AddWithValue("@cedula", a.cedula);
                    myCommand.Parameters.AddWithValue("@aula_id", a.aula_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Alumnos agregados");
        }

        [HttpPut]
        public JsonResult Put(alumno a)
        {
            string query = @"
                update alumno
                set id = @id,
                nombre = @nombre,
                apellido = @apellido,
                cedula = @cedula,
                aula_id = @aula_id
                where id=@id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EvalAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", a.id);
                    myCommand.Parameters.AddWithValue("@nombre", a.nombre);
                    myCommand.Parameters.AddWithValue("@apellido", a.apellido);
                    myCommand.Parameters.AddWithValue("@cedula", a.cedula);
                    myCommand.Parameters.AddWithValue("@aula_id", a.aula_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Actualizacion completada");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from alumno
                where id=@id 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EvalAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Eliminacion completada");
        }


    }
}