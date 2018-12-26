using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var listOfPictures = value as List<Picture>;
            //if (listOfPictures == null)
            //{
            //    return false;
            //}

            if (listOfPictures.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}