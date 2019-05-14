using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Models
{
    public class FormEmailViewModel
    {
        CANDIDATE candidate;
        string emailContent;
        string emailSubject;

        public CANDIDATE Candidate { get => candidate; set => candidate = value; }
        public string EmailContent { get => emailContent; set => emailContent = value; }
        public string EmailSubject { get => emailSubject; set => emailSubject = value; }
    }
}