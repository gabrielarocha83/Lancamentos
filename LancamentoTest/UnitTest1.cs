using Xunit;
using Moq;
using Lancamento.Domain;
using Lancamento.Repository.Interface;
using Lancamento.Services.Command;
using System.Threading.Tasks;

namespace Lancamento.Tests
{
    public class LancamentoCommandServiceTests
    {
        [Fact]
        public async Task AddLancamentoAsync_Should_Call_AddAsync_With_Credito_Correct_Lancamento()
        {
            // Arrange
            var mockRepository = new Mock<Repository.Interface.ILancamentoRepository>();
            var service = new LancamentoCommandService(mockRepository.Object);

            var lancamento = new Domain.Lancamento(100.50, "Crédito", DateTime.Now);

            // Act
            await service.AddLancamentoAsync(lancamento);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.Is<Domain.Lancamento>(l =>
                l.Id == lancamento.Id &&
                l.Tipo == lancamento.Tipo &&
                l.Valor == lancamento.Valor
            )), Times.Once);
        }

        [Fact]
        public async Task AddLancamentoAsync_Should_Call_AddAsync_Debito_With_Correct_Lancamento()
        {
            // Arrange
            var mockRepository = new Mock<Repository.Interface.ILancamentoRepository>();
            var service = new LancamentoCommandService(mockRepository.Object);

            var lancamento = new Domain.Lancamento(10.50, "Débito", DateTime.Now);

            // Act
            await service.AddLancamentoAsync(lancamento);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.Is<Domain.Lancamento>(l =>
                l.Id == lancamento.Id &&
                l.Tipo == lancamento.Tipo &&
                l.Valor == lancamento.Valor
            )), Times.Once);
        }
    }
}
