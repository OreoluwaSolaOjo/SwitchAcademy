using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwitchAcademy.Persistence.Models;
using System.Collections;

namespace SwitchAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsBankController : ControllerBase
    {
        private readonly DataContext _context;
        public QuestionsBankController(DataContext context)
        {
            _context = context;
        }

        /*  Get api/question*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionsBank>>> GetQuestions()
        {
            /*Get 10 random questions*/
            var random10Qns = await (_context.QuestionsBanks
                .Select(x => new
                {
                    QuestionsBankId = x.QuestionsBankId,
                    QuestionContent = x.QuestionContent,
                    Options = new string[] {x.option1, x.option2,
                    x.option3, x.option4},
                    TrainingTrackId = x.TrainingTrackId,
                })
                .OrderBy(y => Guid.NewGuid())
                .Take(10)).ToListAsync();

            return Ok(random10Qns);

        }

        [HttpGet("get-questions-by-trainingtrack/{id}")]
        public async Task<ActionResult<QuestionsBank>> GetQuestionsByTrainingTrack(int id)
        {
            var questions = await _context.QuestionsBanks.Where(x => x.TrainingTrackId == id).ToListAsync();
            var random10Qns = await ( _context.QuestionsBanks.Where(x => x.TrainingTrackId == id)
               .Select(x => new
               {
                   QuestionsBankId = x.QuestionsBankId,
                   QuestionContent = x.QuestionContent,
                   Options = new string[] {x.option1, x.option2,
                    x.option3, x.option4},
                   TrainingTrackId = x.TrainingTrackId,
               })
               .OrderBy(y => Guid.NewGuid())
               .Take(10)).ToListAsync();

            return Ok(random10Qns);

            if (questions == null)
            {
                return NotFound();
            }
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionsBank>> GetQuestion(int id)
        {
            var question = await _context.QuestionsBanks.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

      /*  Post: api/Question/getanswers*/
        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<QuestionsBank>> RetrieveAnswers(int[] questionBankIds)
        {
            /*     To get the answers to the questions generated*/
            var answers = await (_context.QuestionsBanks
                .Where(x => questionBankIds.Contains(x.QuestionsBankId))
                 .Select(y => new
                 {
                     QuestionsBankId = y.QuestionsBankId,
                     QuestionContent = y.QuestionContent,
                     Options = new string[] {y.option1, y.option2,
                    y.option3, y.option4},
                     TrainingTrackId = y.TrainingTrackId,
                     Answer = y.Answer,
                 })).ToListAsync();
            return Ok(answers);
        }
    }
}
