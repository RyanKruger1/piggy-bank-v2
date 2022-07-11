using Microsoft.AspNetCore.Mvc;
using piggy_bank;
using piggy_bank.Enums;
using piggy_bank.Interfaces;
using piggy_bank_v2.Dtos;

namespace piggy_bank_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiggyBankController : ControllerBase
    {
        private readonly ICoinJar repo;
        static List<string> coinsName = CoinMetaData.getCoinInformation().Keys.ToList();
        public PiggyBankController(ICoinJar coinRepo)
        {
            this.repo = coinRepo;
        }

        [HttpGet("/get-total-amount")]
        public PiggyBankDto getValue()
        {
            PiggyBankDto formattedBank = new PiggyBankDto()
            {
                currentBalanceDollars = repo.GetTotalAmount()
            };

            return formattedBank;
        }

        [HttpGet("/get-accepted-coin-types")]
        public IEnumerable<CoinDto> getCoinTypes()
        {
            int counter = 0;
            List<CoinDto> formattedCoins = new List<CoinDto>();

            foreach (string name in coinsName)
            {
                CoinDto formatedCoin = new CoinDto()
                {
                    coinId = counter,
                    coinName = name
                };
                counter++;
                formattedCoins.Add(formatedCoin);
            }

            return formattedCoins;
        }

        [HttpPost("/add-coins")]
        public ActionResult<PiggyBankDto> addCoin(int coinId, int amount)
        {
            try
            {
                for (int i = 0; i < amount; i++)
                {
                    Coin c = new Coin(coinsName[coinId]);
                    repo.AddCoin(c);
                }
                return CreatedAtAction(nameof(getValue), new PiggyBankDto
                {
                    currentBalanceDollars = repo.GetTotalAmount()
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(new ErrorMessageDto{
                    errorMessage = "coinId: " + coinId +" does not exist."
                });
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound(new ErrorMessageDto{
                    errorMessage = "coinId: " + coinId +" does not exist."
                });
            }
        }

        [HttpDelete("/reset")]
        public ActionResult removeCoins()
        {
            repo.Reset();
            return NoContent();
        }
    }
}