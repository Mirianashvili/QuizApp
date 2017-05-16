﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels
{
    public class CreateQuestionViewModel
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }

        //for answers fields
        public string[] Titles { get; set; }
        public int[] Corrects { get; set; }
    }
}
