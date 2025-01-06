using Lancamento.Repository.Interface;
using Lancamento.Domain;

namespace Lancamento.Repository.Handle
{
    public class GetLancamentosHandler
    {
        private readonly ILancamentoRepository _repository;

        public GetLancamentosHandler(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Response.LancamentoResponse>> HandleAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

}
