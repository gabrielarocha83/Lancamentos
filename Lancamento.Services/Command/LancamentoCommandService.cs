using Lancamento.Repository.Interface;
using Lancamento.Domain;

namespace Lancamento.Services.Command
{
    public class LancamentoCommandService
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoCommandService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddLancamentoAsync(Domain.Lancamento lancamento)
        {
            // Validação de regras de negócio, se necessário
            await _repository.AddAsync(lancamento);
        }
               
    }

}
