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
    public class materiaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public materiaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select
                        id as ""Id"",
                        espaniol as ""Espaniol"",
                        matematicas as ""Matematicas"",
                        historia as ""Historia"",
                        ciencias as ""Ciencias""
                        from materia";

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
        public JsonResult Post(materia m)
        {
            string query = @"
                insert into materia (id,espaniol,matematicas,historia,ciencias) 
                values               (@id,@espaniol,@matematicas,@historia,@ciencias) 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EvalAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", m.id);
                    myCommand.Parameters.AddWithValue("@espaniol", m.espaniol);
                    myCommand.Parameters.AddWithValue("@matematicas", m.matematicas);
                    myCommand.Parameters.AddWithValue("@historia", m.historia);
                    myCommand.Parameters.AddWithValue("@ciencias", m.ciencias);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Calificaciones agregadas");
        }

        [HttpPut]
        public JsonResult Put(materia m)
        {
            string query = @"
                update materia
                set id = @id,
                espaniol = @espaniol,
                matematicas = @matematicas,
                historia = @historia
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
                    myCommand.Parameters.AddWithValue("@id", m.id);
                    myCommand.Parameters.AddWithValue("@espaniol", m.espaniol);
                    myCommand.Parameters.AddWithValue("@matematicas", m.matematicas);
                    myCommand.Parameters.AddWithValue("@historia", m.historia);
                    myCommand.Parameters.AddWithValue("@ciencias", m.ciencias);
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
                delete from materia
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