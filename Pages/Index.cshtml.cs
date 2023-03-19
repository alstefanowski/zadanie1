using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }
        //[BindProperty(SupportsGet = true)]
        public string Name;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public IActionResult OnPost()
        {
            if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 != 0 && FizzBuzz.Number > 0)
                TempData[Constants.Fizz] = "Fizz";
            if (FizzBuzz.Number % 5 == 0 && FizzBuzz.Number % 3 != 0 && FizzBuzz.Number > 0)
                TempData[Constants.Buzz] = "Buzz";
            if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 == 0 && FizzBuzz.Number > 0)
                TempData[Constants.FizzBuzz] = "FizzBuzz";
            if(FizzBuzz.Number % 3 != 0 && FizzBuzz.Number % 5 != 0 && FizzBuzz.Number > 0)
                TempData[Constants.Other] = Convert.ToInt32(FizzBuzz.Number) + " nie spełnia kryteriów FizzBuzz w pozostałych przypadkach";
            return Page();
        }
    }
}