
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RomanNumberParser.WebMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _Configuration;
        private readonly string _ApiUrl;
        private readonly IInputModeValidator _InputModeValidator;

        [BindProperty]
        public int Number { get; set; }

        [BindProperty]
        public InputModel? InputModel { get; set; } = new InputModel();

        public string Result { get; set; } = "Give a Try";

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IInputModeValidator inputModeValidator)
        {
            _Configuration = configuration;
            _logger = logger;
            _InputModeValidator = inputModeValidator;
            _ApiUrl = _Configuration.GetSection("APIAddress").Value;
        }

        /// <summary>
        /// Adds Roman Number in Roman Mode 
        /// else Just Add numbers, but in any of the mode both  number should have same format
        /// </summary>
        /// <returns></returns>
        public async Task OnPostCalculate()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Int32.TryParse(Request.Form["CalculationMode"].ToString(), out int selectedMode);

                    if (IsInputValidforMode(selectedMode, out string matchResult) && ModelState.IsValid)
                    {

                        var content = new StringContent(JsonSerializer.Serialize(InputModel), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage apiResult = null;
                        if (selectedMode == (int)DataInputMode.Roman)
                        {

                            apiResult = await client.PostAsync(_ApiUrl, content);
                        }
                        else
                        {
                            //All Numeric mode so, no need to call diffrent api for this
                            apiResult = await client.PostAsync(_ApiUrl+ "AddNumericValue", content);
                        }
                        apiResult.EnsureSuccessStatusCode();
                        Result = await apiResult.Content.ReadAsStringAsync();                      
                       
                    }
                    else
                    {
                        Result = matchResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        private bool IsInputValidforMode(int selectedMode, out string result)
        {
            bool isValid = true;
            if (selectedMode == (int)DataInputMode.Roman)
            {
                if (!_InputModeValidator.IsRomanInputValid(InputModel?.Input1, InputModel?.Input2, out result))
                {
                    Result = result;
                    isValid = false;
                }

                //Validate input for Roman Data
            }
            else
            {
                if (!_InputModeValidator.IsNumericInputValid(InputModel?.Input1, InputModel?.Input2, out result))
                {
                    Result = result;
                    isValid = false;
                }
            }

            return isValid;
        }       
    }
}