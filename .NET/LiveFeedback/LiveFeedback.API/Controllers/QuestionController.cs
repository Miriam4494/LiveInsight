using AutoMapper;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Interfaces.IServices;
using LiveFeedback.API.PostModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDTO>> GetQuestion(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionDTO>> AddQuestion([FromBody] QuestionPostModel questionPostModel)
        {
            var questionDto = _mapper.Map<QuestionDTO>(questionPostModel);
            questionDto = await _questionService.AddQuestionAsync(questionDto);
            if (questionDto == null) return BadRequest();
            return CreatedAtAction(nameof(GetQuestion), new { id = questionDto.Id }, questionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionDTO>> UpdateQuestion(int id, [FromBody] QuestionPostModel questionPostModel)
        {
            var questionDto = _mapper.Map<QuestionDTO>(questionPostModel);
            questionDto = await _questionService.UpdateQuestionAsync(id, questionDto);
            if (questionDto == null) return NotFound();
            return Ok(questionDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsByTitle(string title)
        {
            var questions = await _questionService.GetQuestionsByTitleAsync(title);
            return Ok(questions);
        }

        [HttpGet("content/{content}")]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsByContent(string content)
        {
            var questions = await _questionService.GetQuestionsByContentAsync(content);
            return Ok(questions);
        }
    }
}

//using LiveFeedback.Core.DTOs;
//using LiveFeedback.Core.Entities;
//using LiveFeedback.Core.Interfaces.IServices;
//using LiveFeedback.API.PostModels;
//using Microsoft.AspNetCore.Mvc;
//using AutoMapper;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class QuestionController : ControllerBase
//    {
//        private readonly IQuestionService _questionService;
//        private readonly IMapper _mapper;

//        public QuestionController(IQuestionService questionService, IMapper mapper)
//        {
//            _questionService = questionService;
//            _mapper = mapper;
//        }

//        // הוספת שאלה
//        [HttpPost]
//        public async Task<ActionResult<QuestionDTO>> AddQuestion(QuestionPostModel questionPostModel)
//        {
//            var question = _mapper.Map<Question>(questionPostModel);
//            question.CreatedAt = DateTime.UtcNow;  // הגדרת זמן יצירה

//            await _questionService.AddQuestionAsync(question);

//            var questionDTO = _mapper.Map<QuestionDTO>(question);

//            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, questionDTO);
//        }

//        // קבלת שאלה לפי מזהה
//        [HttpGet("{id}")]
//        public async Task<ActionResult<QuestionDTO>> GetQuestion(int id)
//        {
//            var question = await _questionService.GetQuestionByIdAsync(id);
//            if (question == null) return NotFound();

//            var questionDTO = _mapper.Map<QuestionDTO>(question);

//            return Ok(questionDTO);
//        }

//        // קבלת כל השאלות
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions()
//        {
//            var questions = await _questionService.GetAllQuestionsAsync();
//            var questionDTOs = _mapper.Map<IEnumerable<QuestionDTO>>(questions);

//            return Ok(questionDTOs);
//        }

//        // עדכון שאלה
//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateQuestion(int id, QuestionPostModel questionPostModel)
//        {
//            var question = await _questionService.GetQuestionByIdAsync(id);
//            if (question == null) return NotFound();

//            _mapper.Map(questionPostModel, question);

//            await _questionService.UpdateQuestionAsync(question);

//            return NoContent();
//        }

//        // מחיקת שאלה
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteQuestion(int id)
//        {
//            await _questionService.DeleteQuestionAsync(id);
//            return NoContent();
//        }
//    }
//}
