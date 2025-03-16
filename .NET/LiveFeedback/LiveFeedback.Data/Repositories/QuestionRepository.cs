//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class QuestionRepository : Repository<Question>, IQuestionRepository
//    {
//        public QuestionRepository(DataContext context) : base(context) { }

//        // פונקציה מיוחדת לקבלת שאלות עם תמונות ופידבקים
//        public async Task<IEnumerable<Question>> GetQuestionsWithDetailsAsync()
//        {
//            return await _context.Questions
//                .Include(q => q.Images)  // טוען את התמונות הקשורות
//                .Include(q => q.Feedbacks)  // טוען את הפידבקים הקשורים
//                .ToListAsync();
//        }

//        // פונקציה לחיפוש שאלות לפי כותרת
//        public async Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title)
//        {
//            return await _context.Questions
//                .Where(q => q.Title.Contains(title))
//                .ToListAsync();
//        }

//        // פונקציה לחיפוש שאלות לפי תוכן
//        public async Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content)
//        {
//            return await _context.Questions
//                .Where(q => q.Content.Contains(content))
//                .ToListAsync();
//        }
//    }
//}
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveFeedback.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IMapper _mapper;

        public QuestionRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Question>> GetQuestionsWithDetailsAsync()
        {
            var questions = await _context.Questions
                .Include(q => q.Images)
                .Include(q => q.Feedbacks)
                .Include(q => q.User)
                .ToListAsync();

            return _mapper.Map<IEnumerable<Question>>(questions); // המרה אוטומטית
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Images)
                .Include(q => q.Feedbacks)
                .Include(q => q.User)
                .FirstOrDefaultAsync(q => q.Id == id);

            return _mapper.Map<Question>(question); // המרה אוטומטית
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTitleAsync(string title)
        {
            var questions = await _context.Questions
                .Where(q => q.Title.Contains(title))
                .ToListAsync();

            return _mapper.Map<IEnumerable<Question>>(questions); // המרה אוטומטית
        }

        public async Task<IEnumerable<Question>> GetQuestionsByContentAsync(string content)
        {
            var questions = await _context.Questions
                .Where(q => q.Content.Contains(content))
                .ToListAsync();

            return _mapper.Map<IEnumerable<Question>>(questions); // המרה אוטומטית
        }
    }
}
