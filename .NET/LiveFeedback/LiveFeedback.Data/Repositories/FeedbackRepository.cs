//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
//    {
//        public FeedbackRepository(DataContext context) : base(context) { }

//        public async Task<IEnumerable<Feedback>> GetFeedbacksWithQuestionsAsync()
//        {
//            return await _context.Feedbacks
//                .Include(f => f.QuestionId)
//                .ToListAsync();
//        }
//    }
//}
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveFeedback.Data.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Feedback>> GetFeedbacksWithQuestionsAsync()
        {
            return await _context.Feedbacks
                .Include(q => q.Question)
                .ToListAsync();
        }
    }
}

