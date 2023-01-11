using ExchangeRatesApi.Dto;
using ExchangeRatesApi.Entities;

namespace ExchangeRatesApi.Data
{
    public interface IExchangeratesRepo
    {
        public Task<IEnumerable<ExchangeRate>> GetExchangerates(Filter filter);
    }
}
