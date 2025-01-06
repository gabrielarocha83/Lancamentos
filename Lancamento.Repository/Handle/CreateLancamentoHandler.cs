using Lancamento.Repository.Command;
using Lancamento.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamento.Repository.Handle
{
    public class CreateLancamentoHandler
    {
        private readonly ILancamentoRepository _repository;

        public CreateLancamentoHandler(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(CreateLancamentoCommand command)
        {
            var lancamento = new Domain.Lancamento(command.Valor, command.Tipo, command.Data);
            await _repository.AddAsync(lancamento);
            return lancamento.Id;
        }
    }

}
