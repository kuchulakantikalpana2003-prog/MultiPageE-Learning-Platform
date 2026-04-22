using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Repositories.Interfaces;

namespace MultiPage_ELearning_Platform1.Repositories.Implementations
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null) return false;

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Lesson>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(int id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}