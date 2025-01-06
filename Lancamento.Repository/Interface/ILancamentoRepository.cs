using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lancamento.Domain;

namespace Lancamento.Repository.Interface
{
    public interface ILancamentoRepository
    {
        Task AddAsync(Domain.Lancamento lancamento);
        Task<IEnumerable<Domain.Response.LancamentoResponse>> GetAllAsync();
        Task<Domain.Response.LancamentoResponse> GetByIdAsync(Guid id);
        Task UpdateAsync(Domain.Lancamento lancamento);
        Task DeleteAsync(Guid id);
        Task<decimal> GetSaldoDiarioAsync(string data);
    }

}
