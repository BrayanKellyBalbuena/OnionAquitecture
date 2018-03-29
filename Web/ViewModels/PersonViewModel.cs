using Data.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class PersonViewModel
    {   
      
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        [DisplayName("First Name")]
        [MaxLength(50, ErrorMessage = "Maximun Length is 50 characters")]
        [MinLength(2, ErrorMessage = "Minimun Length is 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [DisplayName("Last Name")]
        [MaxLength(100, ErrorMessage = "Maximun Length is 100 characters")]
        [MinLength(2, ErrorMessage = "Minimun Length is 2 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birthday Is Required")]
        [DisplayName("Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DisplayName("Gender")]
        public Gender Sexo { get; set; }
    }
}