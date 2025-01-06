using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamento.Domain.Response
{
    public class LancamentoResponse
    {
        public decimal Valor { get; private set; }
        public string Tipo { get; private set; } // "Débito" ou "Crédito"
        public DateTime Data { get; private set; }
    }
}
