////using Microsoft.EntityFrameworkCore;
////using Microsoft.EntityFrameworkCore.Migrations;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Reflection;
////using System.Text;
////using System.Threading.Tasks;
////using static LiveFeedback.Data.Repositories.Repository;

////namespace LiveFeedback.Data.Repositories
////{

////       public class Repository<T> : IRepository<T> where T : class 
////       {
////            protected readonly DbSet<T> _dbSet;
////            public Repository(DataContext context)
////            {
////                _dbSet = context.Set<T>();
////            }
////            public T GetById(int id)
////            {
////                return _dbSet.Find(id);
////            }
////            public T Add(T t)
////            {
////                _dbSet.Add(t);

////                return t;
////            }
////            public T Update(int id, T t)
////            {

////                var existingEntity = _dbSet.Find(id);
////                if (existingEntity == null || t == null)
////                {
////                    return null;
////                }
////                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
////                                          .Where(prop => prop.Name != "Id");

////                foreach (var property in properties)
////                {
////                    var updatedValue = property.GetValue(t);
////                    if (updatedValue != null)
////                        property.SetValue(existingEntity, updatedValue);
////                }
////                return t;
////            }
////            public bool Delete(int id)
////            {
////                if (_dbSet == null || _dbSet.Find(id) == null)
////                    return false;
////                try
////                {
////                    _dbSet.Remove(GetById(id));

////                    return true;
////                }
////                catch { return false; }
////            }
////        }

////}




//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LiveFeedback.Core.Interfaces.IRepositories;


//namespace LiveFeedback.Data.Repositories
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        protected readonly DataContext _context;
//        private readonly DbSet<T> _dbSet;

//        public Repository(DataContext context)
//        {
//            _context = context;
//            _dbSet = context.Set<T>();
//        }

//        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

//        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

//        public async Task AddAsync(T entity)
//        {
//            await _dbSet.AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(T entity)
//        {
//            _dbSet.Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await _dbSet.FindAsync(id);
//            if (entity != null)
//            {
//                _dbSet.Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

using LiveFeedback.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LiveFeedback.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    _dbSet.Update(entity); // 🔹 רק השדות ששונו יתעדכנו
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<T> UpdateAsync(int id, T updatedEntity)
        //{
        //    var existingEntity = await _dbSet.FindAsync(id);  // מחפש את ה-Entity הקיים
        //    if (existingEntity == null)
        //    {
        //        return null;  // אם לא נמצא, מחזירים null
        //    }

        //    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //                              .Where(prop => prop.Name != "Id");

        //    // עובר על כל התכונות ומעדכן אותן
        //    foreach (var property in properties)
        //    {
        //        var updatedValue = property.GetValue(updatedEntity);
        //        if (updatedValue != null)
        //        {
        //            property.SetValue(existingEntity, updatedValue);  // מעדכן את הערך של ה-Entity הקיים
        //        }
        //    }

        //    await _context.SaveChangesAsync();  // שומר את השינויים
        //    return existingEntity;  // מחזיר את ה-Entity המעודכן
        //}
        //public async Task<T> UpdateAsync(T updatedEntity)
        //{
        //    // מציאת ה-ID על ידי Reflection
        //    var idProperty = typeof(T).GetProperty("Id");
        //    if (idProperty == null)
        //    {
        //        throw new InvalidOperationException("Entity does not have an 'Id' property.");
        //    }

        //    var entityId = idProperty.GetValue(updatedEntity);
        //    var existingEntity = await _dbSet.FindAsync(entityId);
        //    if (existingEntity == null)
        //    {
        //        return null;
        //    }

        //    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //                               .Where(prop => prop.Name != "Id");  // לא נוגעים ב-ID

        //    foreach (var property in properties)
        //    {
        //        var updatedValue = property.GetValue(updatedEntity);
        //        if (updatedValue != null)
        //        {
        //            property.SetValue(existingEntity, updatedValue);
        //        }
        //    }

        //    await _context.SaveChangesAsync();
        //    return existingEntity;
        //}
        public async Task<T> UpdateAsync(int id, T t)
        {

            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null || t == null)
            {
                return null;
            }
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.Name != "Id");

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(t);
                if (updatedValue != null)
                    property.SetValue(existingEntity, updatedValue);
            }
            await _context.SaveChangesAsync();

            return t;
        }



        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

