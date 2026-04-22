using System.Linq;
using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.DTOs.LessonDTOs;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Services.Interfaces;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;

        public LessonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<LessonResponseDto?> GetByIdAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson == null)
                return null;

            return new LessonResponseDto
            {
                LessonId = lesson.LessonId,
                Title = lesson.Title,
                Content = lesson.Content,
                CourseId = lesson.CourseId,
                OrderIndex = lesson.OrderIndex
            };
        }

        public async Task<LessonResponseDto> CreateAsync(CreateLessonDto dto)
        {
            var lesson = new Lesson
            {
                Title = dto.Title,
                Content = dto.Content,
                CourseId = dto.CourseId,
                OrderIndex = dto.OrderIndex
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return new LessonResponseDto
            {
                LessonId = lesson.LessonId,
                Title = lesson.Title,
                Content = lesson.Content,
                CourseId = lesson.CourseId,
                OrderIndex = lesson.OrderIndex
            };
        }

        public async Task<List<LessonResponseDto>> GetByCourseAsync(int courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .Select(l => new LessonResponseDto
                {
                    LessonId = l.LessonId,
                    Title = l.Title,
                    Content = l.Content,
                    CourseId = l.CourseId,
                    OrderIndex = l.OrderIndex
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, UpdateLessonDto dto)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null) return false;

            lesson.Title = dto.Title;
            lesson.Content = dto.Content;
            lesson.OrderIndex = dto.OrderIndex;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null) return false;

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
