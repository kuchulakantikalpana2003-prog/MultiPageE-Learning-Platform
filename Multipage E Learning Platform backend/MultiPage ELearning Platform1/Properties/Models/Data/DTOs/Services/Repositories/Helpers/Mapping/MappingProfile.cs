using AutoMapper;
using MultiPage_ELearning_Platform1.DTOs;
using MultiPage_ELearning_Platform1.DTOs.CourseDTOs;
using MultiPage_ELearning_Platform1.DTOs.LessonDTOs;
using MultiPage_ELearning_Platform1.DTOs.QuestionDTOs;
using MultiPage_ELearning_Platform1.DTOs.QuizDTOs;
using MultiPage_ELearning_Platform1.DTOs.ResultDTOs;
using MultiPage_ELearning_Platform1.DTOs.UserDTOs;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Properties.Models.Data.DTOs;

namespace MultiPage_ELearning_Platform1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // =========================
            // USER
            // =========================
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // =========================
            // COURSE
            // =========================
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            // =========================
            // LESSON
            // =========================
            CreateMap<Lesson, LessonResponseDto>();
            CreateMap<CreateLessonDto, Lesson>();
            CreateMap<UpdateLessonDto, Lesson>();

            // =========================
            // QUIZ
            // =========================
            CreateMap<Quiz, QuizResponseDto>();
            CreateMap<CreateQuizDto, Quiz>();

            // =========================
            // QUESTION
            // =========================
            CreateMap<Question, QuestionResponseDto>();
            CreateMap<CreateQuestionDto, Question>();

            // =========================
            // RESULT
            // =========================
            CreateMap<Result, ResultResponseDto>();
        }
    }
}