
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RomanNumberParser.WebMVC.Pages
{
    public class InputModel
    {
        [Required]
        [BindProperty]
        [MaxLength(9)]
        public string? Input1 { get; set; }

        [Required]
        [MaxLength(9)]
        [BindProperty]
        public string? Input2 { get; set; }

        [BindProperty]
        public int SelectedValue { get; set; }

        [BindProperty]
        public List<SelectListItem> Modes
        {
            get;
            set;
        }

        public InputModel()
        {
            Modes = GetSelectListItems();
        }

        private static List<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = DataInputMode.Roman.ToString()
            });

            selectList.Add(new SelectListItem
            {
                Value = "1",
                Text = DataInputMode.Numeric.ToString()
            });

            return selectList;
        }
    }
}