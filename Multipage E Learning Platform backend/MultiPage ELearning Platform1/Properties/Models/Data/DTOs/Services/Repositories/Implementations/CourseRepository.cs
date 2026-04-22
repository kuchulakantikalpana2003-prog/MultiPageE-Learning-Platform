using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Repositories.Interfaces;

namespace MultiPage_ELearning_Platform1.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Lessons)
                .Include(c => c.Quizzes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Lessons)
                .Include(c => c.Quizzes)
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}