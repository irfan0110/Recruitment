using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recruitment.Models;
using PagedList;

namespace Recruitment.Controllers
{
    [RoutePrefix("call")]
    public class CallController : Controller
    {
        List<CANDIDATE> candidates;
        // GET: Call
        [Route("")]
        public ActionResult Index(string searchField, string searchString, int? page)
        {
            InitializeCandidates();
            //SEARCHING
            if (!String.IsNullOrEmpty(searchString)) {
                if(searchField == "name") {
                    candidates = candidates.Where(c => c.NAMA_LENGKAP.Contains(searchString)).ToList();
                }
                else if (searchField == "appliedPosition") {
                    candidates = candidates.Where(c => c.JUDUL_POSISI.Contains(searchString)).ToList();
                }
                else if (searchField == "source") {
                    candidates = candidates.Where(c => c.SOURCE_ID.Contains(searchString)).ToList();
                }
                else if (searchField == "phoneNumber") {
                    candidates = candidates.Where(c => c.NOHP.Contains(searchString)).ToList();
                }
                else if (searchField == "email") {
                    candidates = candidates.Where(c => c.EMAIL.Contains(searchString)).ToList();
                }
                else if (searchField == "praSelectionPIC") {
                    candidates = candidates.Where(c => c.USER_CREATE.Contains(searchString)).ToList();
                }
                else if (searchField == "praSelectionNotes") {
                    candidates = candidates.Where(c => c.CATATAN.Contains(searchString)).ToList();
                }

                page = 1;
            }

            //SORTING
            string sortOrder = (string)TempData.Peek("SortOrder");

            if(sortOrder == "id_desc") {
                candidates = candidates.OrderByDescending(c => c.CANDIDATE_ID).ToList();
            }
            else if(sortOrder == "name_asc") {
                candidates = candidates.OrderBy(c => c.NAMA_LENGKAP).ToList();
            }
            else if(sortOrder == "name_desc") {
                candidates = candidates.OrderByDescending(c => c.NAMA_LENGKAP).ToList();
            }
            else { //Default sort is id_asc
                candidates = candidates.OrderBy(c => c.CANDIDATE_ID).ToList();
            }

            //PAGING
            //Require nuGet package PagedList.mvc
            if (page == null) {
                page = 1;
            }
            int pageSize = 5; //The amount of row displayed each page
            int pageNumber = (page ?? 1);

            return View("ListCall", candidates.ToPagedList(pageNumber,pageSize));
        }

        [ActionName("SortByID")]
        public ActionResult SortById() {
            string sortOrder = (string)TempData.Peek("SortOrder");
            if(sortOrder == "id_asc" || String.IsNullOrEmpty(sortOrder)) {
                TempData["SortOrder"] = "id_desc";
            }
            else {
                TempData["SortOrder"] = "id_asc";
            }

            return Redirect("~/call");
        }

        [ActionName("SortByName")]
        public ActionResult SortByName() {
            string sortOrder = (string)TempData.Peek("SortOrder");
            if (sortOrder == "name_asc") {
                TempData["SortOrder"] = "name_desc";
            }
            else {
                TempData["SortOrder"] = "name_asc";
            }

            return Redirect("~/call");
        }

        void InitializeCandidates() {
            using(RecruitmentEntities db = new RecruitmentEntities()) {
                candidates = db.CANDIDATEs.Where(c => c.STATE_ID == "ST001").ToList();
            }
        }

        //void InitializeCandidateDummy() {
        //    candidate = new List<CandidateDummy>() {
        //        new CandidateDummy("CA_001", "Jon Champion","ST020"),
        //        new CandidateDummy("CA_002", "Jqn Qhampion","ST020"),
        //        new CandidateDummy("CA_003", "Jen Whampion","ST020"),
        //        new CandidateDummy("CA_004", "Jrn Ehampion","ST020"),
        //        new CandidateDummy("CA_005", "Jun Rhampion","ST020"),
        //        new CandidateDummy("CA_006", "Jin Thampion","ST020"),
        //        new CandidateDummy("CA_007", "Jhn Yhampion","ST020"),
        //        new CandidateDummy("CA_008", "Jjn Uhampion","ST020"),
        //        new CandidateDummy("CA_009", "Jkn Ihampion","ST020")
        //    };
        //}
    }
}