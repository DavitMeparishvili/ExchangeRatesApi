using Dapper;
using ExchangeRatesApi.Context;
using ExchangeRatesApi.Dto;
using ExchangeRatesApi.Entities;

namespace ExchangeRatesApi.Data
{
    public class ExchangeratesRepo : IExchangeratesRepo
    {
        private readonly DapperContext _context;
        public ExchangeratesRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangerates(Filter filter)
        {
            filter.Code = filter.Code.ToUpper();
            var query = $"SELECT * FROM ExchangeRates Where Date='{filter.Date}' AND Currency LIKE '%{filter.Code}'";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<ExchangeRate>(query);
                return companies.ToList();
            }
        }
    }
}
