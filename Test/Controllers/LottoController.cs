using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers;

[ApiController]
[Route("[controller]")]
public class LottoController : ControllerBase
{
    private readonly List<int> _lottoNumbers = new List<int>();

    public LottoController()
    {
        for (var i = 1; i <= 48; i++)
        {
            _lottoNumbers.Add(i);
        }
    }

    [HttpGet]
    public string GetLottoNumbers()
    {
        var random = new Random();
        var results = new List<int>();
        var usedIndexes = new List<int>();
        for (var i = 1; i <= 6; i++)
        {
            while (true)
            {
                var indexToPick = random.Next(_lottoNumbers.Count);
                if (usedIndexes.Contains(indexToPick)) continue;
                var number = _lottoNumbers.ElementAt(indexToPick);
                usedIndexes.Add(indexToPick);
                results.Add(number);
                break;
            }
        }
        return string.Join(", ", results.OrderBy(x => x));
    }
}