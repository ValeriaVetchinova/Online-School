using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Models;

namespace OnlineSchool.Controllers
{
    [ApiController]
    [Route("Course")]
    public class CourseCotroller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            Course? course = db.Courses.FirstOrDefault(t => t.Id == id);
            if (course == null) { return NotFound(); }
            return Ok(course);
        }
        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            return Ok(db.Courses);
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            db.Courses.Add(course);
            db.SaveChanges();
            return Ok(course);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            OnlineSchoolContext db = new OnlineSchoolContext();
            Course? course = db.Courses.FirstOrDefault(t => t.Id == id);
            if (course == null)
                return NotFound();
            db.Courses.Remove(course);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        
        public IActionResult Edit(Course course)
        {
            var db = new OnlineSchoolContext();
            db.Courses.Update(course);
            db.SaveChanges();
            return Ok(course);
        }

    }
}
