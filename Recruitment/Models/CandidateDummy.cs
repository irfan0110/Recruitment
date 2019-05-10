using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Models
{
    public class CandidateDummy
    {
        string candidateId;
        string namaLengkap;
        string stateId;

        public CandidateDummy() {

        }

        public CandidateDummy(string candidateId, string namaLengkap, string stateId) {
            this.candidateId = candidateId;
            this.namaLengkap = namaLengkap;
            this.stateId = stateId;
        }

        public string CandidateId { get => candidateId; set => candidateId = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string StateId { get => stateId; set => stateId = value; }
    }
}