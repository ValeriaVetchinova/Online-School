using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Models;

namespace OnlineSchool.Controllers
{
    [ApiController]
    [Route("/teachers")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get()
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            return Ok(db.Teachers);
        }
        [HttpGet]
        public IActionResult All()
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            return Ok(db.Teachers);
        }
        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            db.Teachers.Add(teacher);
            db.SaveChanges();
            return Ok(teacher);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            Teacher? teacher = db.Teachers.FirstOrDefault(c => c.Id == id);
            if (teacher == null)
                return NotFound();
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return Ok(teacher);
        }
        [HttpPut]
        public IActionResult Edit(Teacher teacher)
        {
            var db = new OnlineSchoolContext();
            db.Teachers.Update(teacher);
            db.SaveChanges();
            return Ok(teacher);
        }
    }
}
