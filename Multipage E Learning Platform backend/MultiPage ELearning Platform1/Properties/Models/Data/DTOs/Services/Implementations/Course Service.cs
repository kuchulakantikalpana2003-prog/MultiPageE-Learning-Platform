using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.DTOs.CourseDTOs;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using System.Linq;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET ALL
        // =========================
        public async Task<List<CourseDto>> GetAllAsync()
        {
            return await _context.Courses
                .AsNoTracking()
                .Select(c => new CourseDto
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedBy = c.CreatedBy
                })
                .ToListAsync();
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return null;

            return new CourseDto
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                CreatedBy = course.CreatedBy
            };
        }

        // =========================
        // CREATE
        // =========================
        public async Task<CourseDto> CreateAsync(CourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedBy = dto.CreatedBy
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            // return with generated ID
            dto.CourseId = course.CourseId;

            return dto;
        }

        // =========================
        // UPDATE
        // =========================
        public async Task<bool> UpdateAsync(int id, CourseDto dto)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return false;

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.CreatedBy = dto.CreatedBy;

            await _context.SaveChangesAsync();
            return true;
        }

        // =========================
        // DELETE
        // =========================
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}