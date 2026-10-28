using System.ComponentModel.DataAnnotations.Schema;

namespace LmqLesson11Lab4.Models
{
    public class LmqCourse
    {
        public LmqCourse()
        {
            Enrollments = new HashSet<LmqEnrollment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<LmqEnrollment> Enrollments { get; set; }
    }
}