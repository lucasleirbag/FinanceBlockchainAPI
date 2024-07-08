using FinanceBlockchain.API.Controllers;
using FinanceBlockchain.Application.UseCases.MineBlock;
using FinanceBlockchain.Application.UseCases.ValidateBlockchain;
using FinanceBlockchain.Application.Interfaces;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Tests.ControllersTests
{
    public class BlockchainControllerTests
    {
        private readonly Mock<IBlockchainService> _blockchainServiceMock;
        private readonly BlockchainController _controller;

        public BlockchainControllerTests()
        {
            _blockchainServiceMock = new Mock<IBlockchainService>();
            var mineBlockHandler = new MineBlockHandler(_blockchainServiceMock.Object);
            var validateBlockchainHandler = new ValidateBlockchainHandler(_blockchainServiceMock.Object);

            _controller = new BlockchainController(mineBlockHandler, validateBlockchainHandler);
        }

        [Fact]
        public void Mine_DeveRetornarOkResultParaBloqueioValido()
        {
            var request = new MineBlockRequest
            {
                HashBlocoAnterior = "previous_hash",
                ListaTransacoes = new List<Transaction>(),
                Nonce = 0
            };

            _blockchainServiceMock.Setup(x => x.MineBlock(request)).Returns(new MineBlockResponse { Success = true });

            var result = _controller.Mine(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Mine_DeveRetornarBadRequestParaBloqueioInvalido()
        {
            var request = new MineBlockRequest
            {
                HashBlocoAnterior = "previous_hash",
                ListaTransacoes = new List<Transaction>(),
                Nonce = 0
            };

            _blockchainServiceMock.Setup(x => x.MineBlock(request)).Returns(new MineBlockResponse { Success = false });

            var result = _controller.Mine(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Validate_DeveRetornarOkResultParaBlockchainValida()
        {
            _blockchainServiceMock.Setup(x => x.ValidateBlockchain()).Returns(new ValidateBlockchainResponse { Success = true });

            var result = _controller.Validate();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Validate_DeveRetornarBadRequestParaBlockchainInvalida()
        {
            _blockchainServiceMock.Setup(x => x.ValidateBlockchain()).Returns(new ValidateBlockchainResponse { Success = false });

            var result = _controller.Validate();

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
