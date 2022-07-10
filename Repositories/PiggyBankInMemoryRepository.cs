using piggy_bank;
using piggy_bank.Enums;
using piggy_bank.Interfaces;
using piggy_bank_v2.Dtos;

namespace piggy_bank_v2.Repositories
{
    public class PiggyBankInMemoryRepository : ICoinJar
    {
        List<ICoin> coinList;
        static List<string> coinsName = CoinMetaData.getCoinInformation().Keys.ToList();
        public decimal totalVolume = 0m;
        public PiggyBankInMemoryRepository()
        {
            coinList = new List<ICoin>();
        }

        void ICoinJar.AddCoin(ICoin coin)
        {
            totalVolume = totalVolume + coin.Volume;
            coinList.Add(coin);
        }

        decimal ICoinJar.GetTotalAmount()
        {
            decimal sum = 0;
            foreach (Coin c in coinList)
            {
                sum = sum + c.Amount;
            }
            return sum;
        }

        void ICoinJar.Reset()
        {
            coinList.Clear();
            totalVolume = 0;
        }
    }
}