using Lancamento.Repository.Interface;
using Lancamento.Domain;

namespace Lancamento.Services.Query
{
    public class LancamentoQueryService
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoQueryService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Response.LancamentoResponse>> GetAllLancamentosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Domain.Response.LancamentoResponse> GetLancamentoByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<decimal> GetSaldoDiarioAsync(string data)
        {
            return await _repository.GetSaldoDiarioAsync(data);
        }
    }

}
