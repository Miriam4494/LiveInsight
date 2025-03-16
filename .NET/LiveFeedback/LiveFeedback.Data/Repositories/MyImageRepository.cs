//using LiveFeedback.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class MyImageRepository : Repository<MyImage>, IMyImageRepository
//    {
//        public MyImageRepository(DataContext context) : base(context) { }

//        // פונקציה מיוחדת לקבלת תמונות לפי UserId
//        public async Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId)
//        {
//            return await _context.MyImages
//                .Where(i => i.UserId == userId)
//                .ToListAsync();
//        }

//        // פונקציה מיוחדת לקבלת תמונות לפי QuestionId
//        public async Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId)
//        {
//            return await _context.MyImages
//                .Where(i => i.QuestionId == questionId)
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
    public class MyImageRepository : Repository<MyImage>, IMyImageRepository
    {
        public MyImageRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId)
        {
            return await _context.MyImages
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId)
        {
            return await _context.MyImages
                .Where(i => i.QuestionId == questionId)
                .ToListAsync();
        }
    }
}


