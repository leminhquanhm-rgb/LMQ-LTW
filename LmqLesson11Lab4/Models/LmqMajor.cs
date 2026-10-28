namespace LmqLesson11Lab4.Models
{
    public class LmqMajor
    {
        public LmqMajor()
        {
            Learners = new HashSet<LmqLearner>();
        }

        public int MajorID { get; set; }

        public string MajorName { get; set; }

        public virtual ICollection<LmqLearner> Learners { get; set; }
    }
}