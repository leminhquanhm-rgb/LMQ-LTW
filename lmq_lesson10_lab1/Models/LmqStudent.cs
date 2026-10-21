using System.Reflection;

namespace lmq_lesson10_lab1.Models
{
    public class LmqStudent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public LmqBranch? Branch { get; set; }

        public LmqGender? Gender { get; set; }

        public bool IsRegular { get; set; }

        public string? Address { get; set; }

        public DateTime DateOfBorth { get; set; }
    }
}
