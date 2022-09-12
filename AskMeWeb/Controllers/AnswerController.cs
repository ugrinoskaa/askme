using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskMeWeb.Data;
using AskMeWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AskMeWeb.Controllers
{
    public class AnswerController : Controller
    {
        private ApplicationDbContext _db;

        public AnswerController(ApplicationDbContext db)
        {
            _db = db;
        }

        //POST /Answer/Upvote/{id}
        [HttpPost]
        public IActionResult Upvote(int id)
        {
            Answer answer = _db.Answer.Find(id);

            if(answer == null)
            {
                return NotFound();
            }

            answer.upVote();
            _db.SaveChanges();
            return RedirectToAction("Details", "Question", new { id = answer.question.Id });
        }

        //POST /Answer/Downvote/{id}
        [HttpPost]
        public IActionResult Downvote(int id)
        {
            Answer answer = _db.Answer.Find(id);

            if (answer == null)
            {
                return NotFound();
            }

            answer.downVote();
            _db.SaveChanges();
            return RedirectToAction("Details", "Question", new { id = answer.question.Id });
        }

    }
}

