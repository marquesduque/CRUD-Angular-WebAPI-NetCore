using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApiAspNetCore.Entities
{
    public class productEntity
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string legislation { get; set; }
        public string type { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string variableDates { get; set; }

    }
}
