using Lancamento.Repository.Interface;
using Lancamento.Repository.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamento.Repository.Handle
{
    public class GetSaldoDiarioHandler
    {
        private readonly ILancamentoRepository _repository;

        public GetSaldoDiarioHandler(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> HandleAsync(GetSaldoDiarioQuery query)
        {
            return await _repository.GetSaldoDiarioAsync(query.Data.ToString());
        }
    }

}
