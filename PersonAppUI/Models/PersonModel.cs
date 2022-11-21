using System.ComponentModel.DataAnnotations;
using PersonAppLibrary.Models;
using PersonAppLibrary.Types;
using PersonAppUI.Helpers;

namespace PersonAppUI.Models
{
    public class PersonModel
    {
        private string? personNumber = null;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid first name length")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid last name length")]
        public string? LastName { get; set; }

        [RequiredIf("NoPersonNumber", false, ErrorMessage = "Person number required")]
        [RegularExpression(@"[0-9]{2}[0,1,5,6][0-9]{7}", ErrorMessage = "Wrong format of person number.")]
        public string? PersonNumber
        {
            get { return personNumber; }
            set
            {
                personNumber = value;
                if (this.personNumber != null)
                {
                    UpdateBirthDay(this.personNumber);
                }
            }
        }
        [Required]
        public bool NoPersonNumber { get; set; } = false;

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong date Format.")]
        public DateTime BirthDay { get; set; } = DateTime.Now;

        [Required]
        public Sex? Sex { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Wrong format of email address.")]
        public string? Email { get; set; }

        [Required]
        public Nationality? Nationality { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to give GDPR concent to continue")]
        public bool Gdpr { get; set; }

        /// <summary>
        /// Update birthday based on person number.
        /// </summary>
        /// <param name="personNumber"></param>
        private void UpdateBirthDay(string personNumber)
        {
            if (personNumber is not null && personNumber?.Length == 10)
            {
                int year = GetYearOfBirth(personNumber);
                int month = GetMonthOfBirth(personNumber);
                int day = int.Parse(personNumber.Substring(4, 2));
                this.BirthDay = new DateTime(year, month, day);
            }
        }

        /// <summary>
        /// Update year of birth based on person number.
        /// </summary>
        /// <param name="personNumber"></param>
        /// <returns></returns>
        private int GetYearOfBirth(string personNumber)
        {
            int output;
            int curYear = DateTime.Now.Year;
            int yearFromPN = int.Parse(personNumber.Substring(0, 2));
            int diff = curYear - yearFromPN;
            if (diff >= 2000)
            {
                output = yearFromPN + 2000;
            }
            else
            {
                output = yearFromPN + 1900;
            }
            return output;
        }

        /// <summary>
        /// Update month of birth based on person number.
        /// </summary>
        /// <param name="personNumber"></param>
        /// <returns></returns>
        private int GetMonthOfBirth(string personNumber)
        {
            string correctedFirstDigit;
            string monthFromPN = personNumber.Substring(2, 2);
            string firstDigitFromMonth = monthFromPN.Substring(0, 1);
            switch (firstDigitFromMonth)
            {
                case "1":
                    correctedFirstDigit = "1";
                    break;
                case "5":
                    correctedFirstDigit = "0";
                    break;
                case "6":
                    correctedFirstDigit = "1";
                    break;
                default:
                    correctedFirstDigit = "0";
                    break;
            }
            string correctedMonth = correctedFirstDigit + monthFromPN.Substring(1, 1);
            int output = int.Parse(correctedMonth);
            return output;
        }
    }
}
