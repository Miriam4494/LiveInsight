﻿//using LiveFeedback.Core.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;



//namespace LiveFeedback.Services.Services
//{
//    public class FeedbackService : IFeedbackService
//    {
//        private readonly IFeedbackRepository _feedbackRepository;

//        public FeedbackService(IFeedbackRepository feedbackRepository)
//        {
//            _feedbackRepository = feedbackRepository;
//        }

//        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync() => await _feedbackRepository.GetFeedbacksWithQuestionsAsync();

//        public async Task<Feedback> GetFeedbackByIdAsync(int id) => await _feedbackRepository.GetByIdAsync(id);

//        public async Task AddFeedbackAsync(Feedback feedback) => await _feedbackRepository.AddAsync(feedback);

//        public async Task UpdateFeedbackAsync(Feedback feedback) => await _feedbackRepository.UpdateAsync(feedback);

//        public async Task DeleteFeedbackAsync(int id) => await _feedbackRepository.DeleteAsync(id);
//    }
//}
using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
        }

        public async Task<FeedbackDTO> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            return _mapper.Map<FeedbackDTO>(feedback);
        }

        public async Task<FeedbackDTO> AddFeedbackAsync(FeedbackDTO feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            await _feedbackRepository.AddAsync(feedback);
            return _mapper.Map<FeedbackDTO>(feedback);
        }

        //public async Task<FeedbackDTO> UpdateFeedbackAsync(int id, FeedbackDTO feedbackDto)
        //{
        //    var feedback = await _feedbackRepository.GetByIdAsync(id);
        //    if (feedback == null) return null;

        //    _mapper.Map(feedbackDto, feedback);
        //    await _feedbackRepository.UpdateAsync(id, feedback);
        //    return _mapper.Map<FeedbackDTO>(feedback);
        //}
        public async Task<FeedbackDTO> UpdateFeedbackAsync(int id, FeedbackDTO feedbackDto)
        {
            // מציאת ה-feedback לפי ה-ID בלבד
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) return null;

            // ממפים את ה-DTO ל-Entity, אבל לא משפיעים על ה-ID
            Feedback  f= _mapper.Map<Feedback>(feedbackDto);

            // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
            await _feedbackRepository.UpdateAsync(id,f);  // אל תעביר את ה-ID כאן

            return _mapper.Map<FeedbackDTO>(f);
        }



        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) return false;

            await _feedbackRepository.DeleteAsync(id);
            return true;
        }
    }
}
