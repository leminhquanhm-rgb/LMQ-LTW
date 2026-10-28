using System;
using System.Collections.Generic;

namespace LmqLesson11Lab4_DBFirst.Models;

public partial class Major
{
    public int MajorId { get; set; }

    public string MajorName { get; set; } = null!;

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
