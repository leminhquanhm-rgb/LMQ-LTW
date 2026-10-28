
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LmqLesson11Lab4_DBFirst.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstMidName { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public int MajorId { get; set; }

    [ValidateNever]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ValidateNever]
    public virtual Major Major { get; set; } = null!;
}
