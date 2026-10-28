namespace LmqLesson11Lab4.Models
{
    public class LmqLearner
    {
        public LmqLearner()
        {
            Enrollments = new HashSet<LmqEnrollment>();
        }

        public int LearnerID { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int MajorID { get; set; }

        public virtual LmqMajor? Major { get; set; }

        public virtual ICollection<LmqEnrollment> Enrollments { get; set; }
    }
}