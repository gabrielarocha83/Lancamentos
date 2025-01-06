using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamento.Repository.Command
{
    public class CreateLancamentoCommand
    {
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
    }

}
