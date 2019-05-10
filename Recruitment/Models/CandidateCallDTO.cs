using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Models
{
    public class CandidateCallDTO
    {
        string candidateId;
        string name;
        string position;
        string source;
        string phone;
        string email;
        string preSelectPIC;        
        string state;
        string notes;

        public string CandidateId { get => candidateId; set => candidateId = value; }
        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }
        public string Source { get => source; set => source = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string PreSelectPIC { get => preSelectPIC; set => preSelectPIC = value; }        
        public string State { get => state; set => state = value; }
        public string Notes { get => notes; set => notes = value; }        
    }
}