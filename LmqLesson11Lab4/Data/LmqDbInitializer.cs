using LmqLesson11Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace LmqLesson11Lab4.Data
{
    public class LmqDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LmqSchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<LmqSchoolContext>>()))
            {
                // Tạo database nếu chưa tồn tại
                context.Database.EnsureCreated();

                // Nếu đã có dữ liệu chuyên ngành thì không thêm lại
                if (context.Majors.Any())
                {
                    return;
                }

                // 1. Thêm dữ liệu Major
                var majors = new LmqMajor[]
                {
                    new LmqMajor { MajorName = "IT" },
                    new LmqMajor { MajorName = "Economics" },
                    new LmqMajor { MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }

                context.SaveChanges();

                // 2. Thêm dữ liệu Learner
                var learners = new LmqLearner[]
                {
                    new LmqLearner
                    {
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"),
                        MajorID = 1
                    },
                    new LmqLearner
                    {
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"),
                        MajorID = 2
                    }
                };

                foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }

                context.SaveChanges();

                // 3. Thêm dữ liệu Course
                var courses = new LmqCourse[]
                {
                    new LmqCourse { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new LmqCourse { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new LmqCourse { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };

                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }

                context.SaveChanges();

                // 4. Thêm dữ liệu Enrollment
                var enrollments = new LmqEnrollment[]
                {
                    new LmqEnrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new LmqEnrollment { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new LmqEnrollment { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new LmqEnrollment { LearnerID = 2, CourseID = 4041, Grade = 7f }
                };

                foreach (var enrollment in enrollments)
                {
                    context.Enrollments.Add(enrollment);
                }

                context.SaveChanges();
            }
        }
    }
}