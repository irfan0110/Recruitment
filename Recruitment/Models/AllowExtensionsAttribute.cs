﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Recruitment.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {

        public string Extensions { get; set; } = "png,jpg,jpeg,docx,pdf";

        public override bool IsValid(object value)
        {

            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;


            List<string> allowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            if (file != null)
            {

                var fileName = file.FileName;


                isValid = allowedExtensions.Any(y => fileName.EndsWith(y));
            }


            return isValid;
        }
    }
}