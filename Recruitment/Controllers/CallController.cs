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
        List<CandidateCallDTO> candidates;
        //List<CandidateCallDTO> calledCandidates;
        // GET: Call
        [Route("")]
        public ActionResult Index(string filterPosition, string searchString, int? page)
        {
            InitializeCandidates();
            
            //SEARCHING
            if (!String.IsNullOrEmpty(searchString)) {
                candidates = candidates.Where(c => c.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
                page = 1;
            }

            if (!String.IsNullOrEmpty(filterPosition)) {
                candidates = candidates.Where(c => c.Position.ToUpper().Equals(filterPosition.ToUpper())).ToList();
                //TODO SEARCH ON ALL FIELDS
                page = 1;
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

        [Route("called")]
        public ActionResult IndexCalled(string filterPosition, string searchString, int? page) {
            InitializeCalledCandidates();

            //SEARCHING
            if (!String.IsNullOrEmpty(searchString)) {
                candidates = candidates.Where(c => c.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
                page = 1;
            }

            if (!String.IsNullOrEmpty(filterPosition)) {
                candidates = candidates.Where(c => c.Position.ToUpper().Equals(filterPosition.ToUpper())).ToList();
                //TODO SEARCH ON ALL FIELDS
                page = 1;
            }

            //PAGING
            //Require nuGet package PagedList.mvc
            if (page == null) {
                page = 1;
            }
            int pageSize = 5; //The amount of row displayed each page
            int pageNumber = (page ?? 1);

            return View("ListCalled", candidates.ToPagedList(pageNumber, pageSize));
        }

        void InitializeCandidates() {
            using(RecruitmentEntities db = new RecruitmentEntities()) {
               candidates = (from c in db.CANDIDATEs
                              join s in db.SOURCEs on c.SOURCE_ID equals s.SOURCE_ID into table1
                              from s in table1.DefaultIfEmpty()
                                join u in db.USERs on c.USER_CREATE equals u.USERNAME into table2
                                from u in table2.DefaultIfEmpty()
                                    join st in db.STATEs on c.STATE_ID equals st.STATE_ID into table3
                                    from st in table3.DefaultIfEmpty()
                                    where c.STATE_ID == "ST001"
                                    select new CandidateCallDTO { 
                                        CandidateId = c.CANDIDATE_ID,
                                        Name = c.NAMA_LENGKAP,
                                        Position = c.JUDUL_POSISI,
                                        Source = s.SOURCE_NAME,
                                        Phone = c.NOHP,
                                        Email = c.EMAIL,
                                        PreSelectPIC = u.FULLNAME,
                                        State = st.STATE_NAME,
                                        Notes = c.CATATAN
                                    }).ToList();

                List<SelectListItem> filterPositions = db.POSITIONs.Select(p => new SelectListItem {
                    Text = p.POSITION_NAME,
                    Value = p.POSITION_NAME                
                }).ToList();
                filterPositions.Insert(0, (new SelectListItem { Text = "", Value = "" }));

                TempData["filterPositions"] = filterPositions;
            }
        }

        void InitializeCalledCandidates() {
            using (RecruitmentEntities db = new RecruitmentEntities()) {
                candidates = (from c in db.CANDIDATEs
                              join s in db.SOURCEs on c.SOURCE_ID equals s.SOURCE_ID into table1
                              from s in table1.DefaultIfEmpty()
                              join u in db.USERs on c.USER_CREATE equals u.USERNAME into table2
                              from u in table2.DefaultIfEmpty()
                              join st in db.STATEs on c.STATE_ID equals st.STATE_ID into table3
                              from st in table3.DefaultIfEmpty()
                              where c.STATE_ID == "ST002"
                              select new CandidateCallDTO {
                                  CandidateId = c.CANDIDATE_ID,
                                  Name = c.NAMA_LENGKAP,
                                  Position = c.JUDUL_POSISI,
                                  Source = s.SOURCE_NAME,
                                  Phone = c.NOHP,
                                  Email = c.EMAIL,
                                  PreSelectPIC = u.FULLNAME,
                                  State = st.STATE_NAME,
                                  Notes = c.CATATAN
                              }).ToList();

                List<SelectListItem> filterPositions = db.POSITIONs.Select(p => new SelectListItem {
                    Text = p.POSITION_NAME,
                    Value = p.POSITION_NAME
                }).ToList();
                filterPositions.Insert(0, (new SelectListItem { Text = "", Value = "" }));

                TempData["filterPositions"] = filterPositions;
            }
        }

        #region UNUSED

        //SORTING
        //string sortOrder = (string)TempData.Peek("SortOrder");

        //if(sortOrder == "id_desc") {
        //    candidates = candidates.OrderByDescending(c => c.CANDIDATE_ID).ToList();
        //}
        //else if(sortOrder == "name_asc") {
        //    candidates = candidates.OrderBy(c => c.NAMA_LENGKAP).ToList();
        //}
        //else if(sortOrder == "name_desc") {
        //    candidates = candidates.OrderByDescending(c => c.NAMA_LENGKAP).ToList();
        //}
        //else { //Default sort is id_asc
        //    candidates = candidates.OrderBy(c => c.CANDIDATE_ID).ToList();
        //}

        //[ActionName("SortByID")]
        //public ActionResult SortById() {
        //    string sortOrder = (string)TempData.Peek("SortOrder");
        //    if (sortOrder == "id_asc" || String.IsNullOrEmpty(sortOrder)) {
        //        TempData["SortOrder"] = "id_desc";
        //    }
        //    else {
        //        TempData["SortOrder"] = "id_asc";
        //    }

        //    return Redirect("~/call");
        //}

        //[ActionName("SortByName")]
        //public ActionResult SortByName() {
        //    string sortOrder = (string)TempData.Peek("SortOrder");
        //    if (sortOrder == "name_asc") {
        //        TempData["SortOrder"] = "name_desc";
        //    }
        //    else {
        //        TempData["SortOrder"] = "name_asc";
        //    }

        //    return Redirect("~/call");
        //}


        #endregion
    }
}