﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.DTOs.Course
{
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}
