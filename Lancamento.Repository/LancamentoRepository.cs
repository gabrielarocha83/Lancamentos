using Lancamento.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using Lancamento.Domain;
using Dapper;
using System.Globalization;

namespace Lancamento.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IDbConnection _dbConnection;

        public LancamentoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddAsync(Domain.Lancamento lancamento)
        {
            const string sql = @"
            INSERT INTO Lancamentos (Id, Valor, Tipo, Data) 
            VALUES (@Id, @Valor, @Tipo, @Data)";

            await _dbConnection.ExecuteAsync(sql, new
            {
                lancamento.Id,
                lancamento.Valor,
                lancamento.Tipo,
                lancamento.Data
            });
        }

        public async Task<IEnumerable<Domain.Response.LancamentoResponse>> GetAllAsync()
        {
            const string sql = "SELECT Valor, Tipo, Data  FROM Lancamentos";
            return await _dbConnection.QueryAsync<Domain.Response.LancamentoResponse>(sql);
        }

        public async Task<Domain.Response.LancamentoResponse> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT Valor, Tipo, Data  FROM Lancamentos WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Domain.Response.LancamentoResponse>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Domain.Lancamento lancamento)
        {
            const string sql = @"
            UPDATE Lancamentos 
            SET Valor = @Valor, Tipo = @Tipo, Data = @Data 
            WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, new
            {
                lancamento.Id,
                lancamento.Valor,
                lancamento.Tipo,
                lancamento.Data
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM Lancamentos WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<decimal> GetSaldoDiarioAsync(string data)
        {

            DateTime dataOriginal = DateTime.ParseExact(data, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string dataFormatada = dataOriginal.ToString("dd-MM-yyyy");

            const string sql = @"
        SELECT 
            SUM(CASE WHEN Tipo = 'Crédito' THEN Valor ELSE -Valor END) AS Saldo
        FROM 
            Lancamentos
        WHERE 
            CONVERT(date, Data,103) = CONVERT(date, @Data,103)";

            var saldo = await _dbConnection.ExecuteScalarAsync<decimal>(sql, new { Data = dataFormatada });
            return saldo;
        }

    }
}
