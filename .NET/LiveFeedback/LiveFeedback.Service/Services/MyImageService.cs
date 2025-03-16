//using LiveFeedback.Core.Entities;

//using System.Collections.Generic;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;

//namespace LiveFeedback.Services.Services
//{
//    public class MyImageService : IMyImageService
//    {
//        private readonly IMyImageRepository _myImageRepository;

//        public MyImageService(IMyImageRepository myImageRepository)
//        {
//            _myImageRepository = myImageRepository;
//        }

//        public async Task<IEnumerable<MyImage>> GetAllImagesAsync() => await _myImageRepository.GetAllAsync();

//        public async Task<MyImage> GetImageByIdAsync(int id) => await _myImageRepository.GetByIdAsync(id);

//        public async Task AddImageAsync(MyImage image) => await _myImageRepository.AddAsync(image);

//        public async Task UpdateImageAsync(MyImage image) => await _myImageRepository.UpdateAsync(image);

//        public async Task DeleteImageAsync(int id) => await _myImageRepository.DeleteAsync(id);

//        public async Task<IEnumerable<MyImage>> GetImagesByUserIdAsync(int userId) => await _myImageRepository.GetImagesByUserIdAsync(userId);

//        public async Task<IEnumerable<MyImage>> GetImagesByQuestionIdAsync(int questionId) => await _myImageRepository.GetImagesByQuestionIdAsync(questionId);
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
    public class MyImageService : IMyImageService
    {
        private readonly IMyImageRepository _myImageRepository;
        private readonly IMapper _mapper;

        public MyImageService(IMyImageRepository myImageRepository, IMapper mapper)
        {
            _myImageRepository = myImageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MyImageDTO>> GetAllImagesAsync()
        {
            var images = await _myImageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MyImageDTO>>(images);
        }

        public async Task<MyImageDTO> GetImageByIdAsync(int id)
        {
            var image = await _myImageRepository.GetByIdAsync(id);
            return _mapper.Map<MyImageDTO>(image);
        }

        public async Task<MyImageDTO> AddImageAsync(MyImageDTO imageDto)
        {
            var image = _mapper.Map<MyImage>(imageDto);
            await _myImageRepository.AddAsync(image);
            return _mapper.Map<MyImageDTO>(image);
        }


        public async Task<MyImageDTO> UpdateImageAsync(int id, MyImageDTO imageDto)
        {
            // מציאת התמונה לפי ה-ID בלבד
            var image = await _myImageRepository.GetByIdAsync(id);
            if (image == null) return null;

            // ממפים את ה-DTO ל-Entity (MyImage), אבל לא משפיעים על ה-ID
            MyImage entity = _mapper.Map<MyImage>(imageDto);

            // עושים Save רק לאחר המיפוי, לא מעדכנים את ה-ID
            await _myImageRepository.UpdateAsync(id, entity);  // אל תעביר את ה-ID כאן

            return _mapper.Map<MyImageDTO>(entity);
        }


        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _myImageRepository.GetByIdAsync(id);
            if (image == null) return false;

            await _myImageRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<MyImageDTO>> GetImagesByUserIdAsync(int userId)
        {
            var images = await _myImageRepository.GetImagesByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<MyImageDTO>>(images);
        }

        public async Task<IEnumerable<MyImageDTO>> GetImagesByQuestionIdAsync(int questionId)
        {
            var images = await _myImageRepository.GetImagesByQuestionIdAsync(questionId);
            return _mapper.Map<IEnumerable<MyImageDTO>>(images);
        }
    }
}
