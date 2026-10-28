namespace LmqLesson11Lab4.Models
{
    public class LmqEnrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int LearnerID { get; set; }

        public float Grade { get; set; }

        public virtual LmqLearner? Learner { get; set; }

        public virtual LmqCourse? Course { get; set; }
    }
}