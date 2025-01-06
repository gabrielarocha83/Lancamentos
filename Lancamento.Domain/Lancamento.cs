using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamento.Domain
{
    public class Lancamento
    {
        private double v1;
        private string v2;
        private DateTime now;

        public Guid Id { get; private set; }
        public double Valor { get; private set; }
        public string Tipo { get; private set; } // "Débito" ou "Crédito"
        public DateTime Data { get; private set; }
      
        public Lancamento(double valor, string tipo, DateTime data)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");

            if (tipo != "Débito" && tipo != "Crédito")
                throw new ArgumentException("O tipo deve ser 'Débito' ou 'Crédito'.");

            Id = Guid.NewGuid();
            Valor = valor;
            Tipo = tipo;
            Data = data;
        }

        
    }

}
