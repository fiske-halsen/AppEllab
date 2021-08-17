using App.data;
using App.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly SchoolContext _context;
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration, SchoolContext context)
        {
            _context = context;
            _configuration = configuration;

        }

        /* [HttpGet]
         public async Task<ActionResult<IEnumerable<Student>>> Get()
         {
             Console.WriteLine("hello");
             return await _context.Students.ToListAsync();
         }*/

        /* [HttpPost]
         public async Task<ActionResult<Student>> PostStudent(Student student)
         {
             _context.Students.Add(student);
             await _context.SaveChangesAsync();

             return CreatedAtAction(student.FirstMidName, new { id = student.ID }, student);
         }*/

        //[HttpGet]
        //public ActionResult<IEnumerable<Student>> get()
        //{

        //    string query = @"";
        //    datatable table = new datatable();
        //    string sqldatasource = _configuration.getconnectionstring("defaultconnection");
        //    console.writeline(sqldatasource);
        //    mysqldatareader myreader;
        //    using (SqlConnection mycon = new SqlConnection(sqldatasource))
        //    {
        //        mycon.open();
        //        using (SqlCommand mycommand = new SqlCommand(query, mycon))
        //        {
        //            myreader = mycommand.ExecuteReader();
        //            table.load(myreader);
        //            myreader.close();

        //        }
        //    }
        //    return null;
        //}

        //    }
        [HttpGet]
        public string Get()
        {
            string queryString =
                "SELECT * FROM Table_2";
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    Trace.WriteLine(reader.GetString(0));
                }

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            
            Console.WriteLine("--------------------");
            reader.Close();

            return null;


        }

    }
}
