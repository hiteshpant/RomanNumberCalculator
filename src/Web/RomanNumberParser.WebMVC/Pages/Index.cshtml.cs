
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

        [BindProperty]
        public int Number { get; set; }

        [BindProperty]
        public InputModel? InputModel { get; set; } = new InputModel();

        public string Result { get; set; } = "Give a Try";

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _Configuration = configuration;
            _logger = logger;
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
                //InputModel.Modes.Where()
                using (var client = new HttpClient())
                {
                    //Int32.TryParse(Request.Form["CalculationMode"].ToString(), out int selectedMode);

                    if (ModelState.IsValid)
                    {
                        var content = new StringContent(JsonSerializer.Serialize(InputModel), System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage apiResult = null;
                        if (InputModel.SelectedValue == (int)DataInputMode.Roman)
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
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }       
    }
}