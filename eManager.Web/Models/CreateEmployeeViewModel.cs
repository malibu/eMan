using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public class CreateEmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        // public int Id { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
