//using LiveFeedback.Core.Entities;

//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;

//namespace LiveFeedback.Services.Services
//{
//    public class QuestionService : IQuestionService
//    {
//        private readonly IQuestionRepository _questionRepository;

//        public QuestionService(IQuestionRepository questionRepository)
//        {
//            _questionRepository = questionRepository;
//        }

//        public async Task<IEnumerable<Question>> GetAllQuestionsAsync() => await _questionRepository.GetQuestionsWithDetailsAsync();

//        public async Task<Question> GetQuestionByIdAsync(int id) => await _questionRepository.GetByIdAsync(id);

//        public async Task AddQuestionAsync(Question question) => await _questionRepository.AddAsync(question);

//        public async Task UpdateQuestionAsync(Question question) => await _questionRepository.UpdateAsync(question);

//        public async Task DeleteQuestionAsync(int id) => await _questionRepository.DeleteAsync(id);

//        public async Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title) => await _questionRepository.GetQuestionsByTitleAsync(title);

//        public async Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content) => await _questionRepository.GetQuestionsByContentAsync(content);
//    }
//}
using AutoMapper;
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Services.Services
{
    

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public async Task<QuestionDTO> GetQuestionByIdAsync(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            return _mapper.Map<QuestionDTO>(question);
        }

        public async Task<QuestionDTO> AddQuestionAsync(QuestionDTO questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            await _questionRepository.AddAsync(question);
            return _mapper.Map<QuestionDTO>(question);
        }

      
        public async Task<QuestionDTO> UpdateQuestionAsync(int id, QuestionDTO questionDto)
        {
            // מציאת התמונה לפי ה-ID בלבד
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null) return null;

            // ממפים את ה-DTO ל-Entity (MyImage), אבל לא משפיעים על ה-ID
            Question entity = _mapper.Map<Question>(questionDto);

            // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
            await _questionRepository.UpdateAsync(id, entity);  // אל תעביר את ה-ID כאן

            return _mapper.Map<QuestionDTO>(entity);
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null) return false;

            await _questionRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByTitleAsync(string title)
        {
            var questions = await _questionRepository.GetQuestionsByTitleAsync(title);
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByContentAsync(string content)
        {
            var questions = await _questionRepository.GetQuestionsByContentAsync(content);
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }
    }
    //}

}
