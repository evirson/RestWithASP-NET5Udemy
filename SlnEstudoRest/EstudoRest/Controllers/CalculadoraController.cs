using Microsoft.AspNetCore.Mvc;

namespace EstudoRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public  IActionResult Get(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(soma.ToString());
            }

            return BadRequest("Entrada Inválida");
        
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
                        
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double numero;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out numero);

            return isNumber;
        }
    }
}