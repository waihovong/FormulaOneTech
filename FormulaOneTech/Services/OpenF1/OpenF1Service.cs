using FormulaOneTech.Services.Ergast;

namespace FormulaOneTech.Services.OpenF1
{
    public class OpenF1Service : IOpenF1Service
    {
        private readonly HttpClient _httpClient;

        public OpenF1Service (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
