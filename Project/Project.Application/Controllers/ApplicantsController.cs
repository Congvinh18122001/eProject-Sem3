﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Core;
using Project.Core.Objects;
using Project.Core.Models;

namespace Project.Application.Controllers
{
    public class ApplicantsController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();
        IApplicantResponsibility context = new ApplicantResponsibility();

        public ActionResult Create(int id)
        {
            ViewBag.vacancyId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            string email = f["Email"];
            Applicant CheckApplicant = context.GetApplicant(email);
            if (CheckApplicant == null)
            {
                Applicant applicant = new Applicant();
                applicant.Name = f["Name"];
                applicant.Phone = f["Phone"];
                applicant.Status = true;
                applicant.Experience = f["Experience"];
                applicant.BirthDay = Convert.ToDateTime(f["BirthDay"]);
                applicant.Address = f["Address"];
                applicant.Email = f["Email"];
                applicant.AcademicLevel = f["AcademicLevel"];
                applicant.Create_at = DateTime.Now;
                CheckApplicant = context.AddApplication(applicant);

            }
            VacancyApplicant vacancyApplicant = new VacancyApplicant();
            vacancyApplicant.ApplicantId = CheckApplicant.Id;
            vacancyApplicant.VacancyId = Int32.Parse(f["vacancyId"]);
            vacancyApplicant.InterviewTime = Convert.ToDateTime(f["InterviewTime"]);
            vacancyApplicant.Status = "doing";
            vacancyApplicant.Create_at = DateTime.Now;
            vacancyApplicant.InterviewId = 1;
            context.AddVacancyApplicant(vacancyApplicant);
            return RedirectToAction("Details","Vacancies",new { id = Int32.Parse(f["vacancyId"]) });
        }
      
    }
}