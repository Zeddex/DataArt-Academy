using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Homework9.Models
{
    public class PollModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Question is required")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Answer  is required")]
        public List<string> Answer { get; set; }

        public PollStatus Status { get; set; }

        public Dictionary<int, int> Votes { get; set; }     //<answerID, votes amount>
    }
}
