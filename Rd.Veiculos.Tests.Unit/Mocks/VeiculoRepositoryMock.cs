using Moq;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Api.Core.Repositories;

namespace Rd.Veiculos.Tests.Unit.Mocks
{
    internal class VeiculoRepositoryMock : Mock<IVeiculoRepository>
    {
        internal VeiculoRepositoryMock ObterPorIdComResultado()
        {
            Setup(v => v.ObterPorId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new VeiculoEntity()
                {
                    Id = Guid.NewGuid(),
                    Marca = "Fiat",
                    Modelo = "Uno",
                    AnoFabricacao = 2020,
                    AnoModelo = 2021,
                    QuantidadeLugares = 3,
                    Categoria = "Passeio",
                    Ativo = true,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                });

            return this;
        }

        internal VeiculoRepositoryMock ObterPorIdSemResultado()
        {
            Setup(v => v.ObterPorId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((VeiculoEntity)null);

            return this;
        }
    }
}
