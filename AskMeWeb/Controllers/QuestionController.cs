using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskMeWeb.Data;
using AskMeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AskMeWeb.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext _db;

        public QuestionController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /Question?q=help
        public IActionResult Index([FromQuery] string q)
        {
            IEnumerable<Question> model = null;
            if (q != null)
            {
                model = _db.Question.Where(qs => qs.title!.Contains(q)).OrderByDescending(qs => qs.createdAt);
            }
            else
            {
                model = _db.Question.OrderByDescending(q => q.createdAt);
            }
            return View(model);

        }

        // GET: /Question/Details/{id}
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Question model = _db.Question.Find(id);
            if(model == null) {
                return NotFound();
            }

            model.answers = _db.Answer.OrderByDescending(a => a.votes).Where(a => a.question == model).ToList<Answer>();
            return View(model);
        }

        // GET: /Question/Ask
        public IActionResult Ask()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Ask(Question question)
        {
            if (ModelState.IsValid) // for Validation on server side
            {
                _db.Question.Add(question);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = question.Id });
            }
            return View(question);
        }

        // POST: /Question/Upvote/{id}
        [HttpPost]
        public IActionResult Upvote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question model = _db.Question.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            model.upVote();
            _db.SaveChanges();
            return RedirectToAction("Details", new { id });
        }

        // POST: /Question/Downvote/{id}
        [HttpPost]
        public IActionResult Downvote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question model = _db.Question.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            model.downVote();
            _db.SaveChanges();
            return RedirectToAction("Details", new { id });
        }

        // POST: /Question/Answer/{id}
        [HttpPost]
        public IActionResult Answer([FromRoute] int id, [FromForm] Answer answer)
        {
            Question question = _db.Question.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            question.answers.Add(answer);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id });
        }
    }
}

