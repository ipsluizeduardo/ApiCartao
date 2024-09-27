using Domain.DTO.Inputs;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Repositories;

namespace Tests.HandlerTests
{
    [TestClass]
    public class GerarCartaoVirtualHandlerTests
    {
        [TestMethod]
        public void DeveRetornarEmailInvalido()
        {
            var command = new GerarCartaoVirtualDTO
            {
                Email = "jhonatafernandes.com"
            };

            var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = gerarCartaoHandler.Handle(command);

            Assert.AreEqual("Email Inv�lido", result.Message);
        }

        [TestMethod]
        public void DeveRetornarSucesso()
        {
            var command = new GerarCartaoVirtualDTO();
            command.Email = "jhonatafernandes@gmail.com";

            var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = gerarCartaoHandler.Handle(command);

            Assert.AreEqual(true, result.Success);
        }
    }
}