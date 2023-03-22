using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDapper.TestClient
{
    public class ClientTestCasoDeUso
    {
        [Fact]
        public async Task ObtenerListaPacientes()
        {

            var clientRepositorioMock = new Mock<IClientRepository>();

            clientRepositorioMock.Setup(x => x.GetAllClientsAsync()).ReturnsAsync(new List<Client>());
            var clientCasoDeUso = new ClientUseCase(clientRepositorioMock.Object);
            var result = await clientCasoDeUso.GetListClients();
            Assert.NotNull(result);
            Assert.IsType<List<Client>>(result);

        }

        //[Fact]
        //public async Task AddClient()
        //{

        //    var clientRepositorioMock = new Mock<IClientRepository>();

        //    pacienteRepositorioMock.Setup(x => x.AgregarPaciente(It.IsAny<Paciente>())).ReturnsAsync(new Paciente());
        //    var pacienteCasoDeUso = new PacienteCasoDeUso(pacienteRepositorioMock.Object);
        //    var result = await pacienteCasoDeUso.AgregarPaciente(new Paciente());
        //    Assert.NotNull(result);
        //    Assert.IsType<Paciente>(result);
        //}

        //[Fact]
        //public async Task ObtenerPacientePorId()
        //{

        //    var pacienteRepositorioMock = new Mock<IPacienteRepositorio>();

        //    pacienteRepositorioMock.Setup(x => x.ObtenerPacientePorId(It.IsAny<int>())).ReturnsAsync(new Paciente());
        //    var pacienteCasoDeUso = new PacienteCasoDeUso(pacienteRepositorioMock.Object);
        //    var result = await pacienteCasoDeUso.ObtenerPacientePorId(1);
        //    Assert.NotNull(result);
        //    Assert.IsType<Paciente>(result);
        //}





    }
}
