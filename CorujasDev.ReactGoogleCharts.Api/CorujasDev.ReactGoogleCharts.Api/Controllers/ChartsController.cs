using CorujasDev.ReactGoogleCharts.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorujasDev.ReactGoogleCharts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        

        private readonly ILogger<ChartsController> _logger;

        public ChartsController(ILogger<ChartsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<GetChartUserRegisterbyMonthResponse> GetChartUserRegisterbyMonth()
        {
            var result = Enumerable.Range(1, 5).Select(index => new GetChartUserRegisterbyMonthResponse
            {
                Mes = DateTime.Now.AddMonths(index).ToString("MMMM"),
                Biker = Random.Shared.Next(100, 400),
                Empresa = Random.Shared.Next(10, 50),
            })
            .ToArray();

            foreach (var item in result)
                item.Total = item.Biker + item.Empresa;

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<GetCountPercentageCatgoriesCompanyResponse> GetCountPercentageCatgoriesCompany()
        {
            string[] Empresas = new[] { "Restaurante", "Recreação", "Bar" };

            var result = Empresas.Select(index => new GetCountPercentageCatgoriesCompanyResponse
            {
                Nome = index,
                Quantidade = Random.Shared.Next(0, 50)
            })
            .ToArray();

            var total = result.Sum(x => x.Quantidade);                                                                                                                                                                                                                                  

            foreach (var item in result)
                item.Porcentagem = (((double)item.Quantidade / total) * 100);

            return result;
        }
    }
}
