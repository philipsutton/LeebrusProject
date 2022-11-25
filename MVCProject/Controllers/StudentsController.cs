using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class StudentsController : Controller
    {
        
        public IActionResult Index()
        {
            //connect to db
            SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            //fire query
            com.CommandText = "select * from student";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();

            var students = new List<Student>();
            while (dr.Read())
            {
                Student student = new Student();
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Email = dr["Email"].ToString();
                student.Address = dr["Address"].ToString();
                students.Add(student);
            }

            ViewBag.Names = students;
            ViewBag.Title = "Students";

            return View(students);
        }

        public IActionResult Studies()
        {
            return View();
        }
    }
}
