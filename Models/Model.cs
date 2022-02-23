
//Need to activate this to use required
using System.ComponentModel.DataAnnotations;


namespace labb2.Models
{
        public class Model
        {
        //properties

        //required makes it so the fields must be filled
        //In the page 3 form
        //decides what name it should show
        //----------Kurskod---------------------------------------------------
        [Display(Name = "Film namn:")]
        //we cam decided here what the error message should be
        [Required(ErrorMessage = "Ange ett namn på en film")]
        public string? Name { get; set; }
        //----------Kursnamn--------------------------------------------------
        [Display(Name = "Changer:")]
        [Required(ErrorMessage = "Ange en film changer")]
        public string? Genre { get; set; }
        //----------Kurs URL--------------------------------------------------
        [Display(Name = "Årtal:")]
        [Required(ErrorMessage = "Ange när filmen släpptes")]
        //Max lenght decides how many letters can be filled
        [MaxLength(4)]
        public string? Year { get; set; }
        //----------Kurs progression------------------------------------------
        [Display(Name = "Betyg 1-10:")]
        [Required(ErrorMessage = "Ge filmen ett betyg mellan 1-10")]
        public string? Rating { get; set; }
        //--------------------------------------------------------------------
    }
}

