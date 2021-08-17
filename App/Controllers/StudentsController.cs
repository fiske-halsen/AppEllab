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

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            string query = @"select * from dbo.Table2";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(sqlDataSource);
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);

        }







    }
}
