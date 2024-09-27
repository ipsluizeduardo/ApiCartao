using Domain.DTO.Inputs;
using Domain.DTO.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.DTO;

namespace Domain.Handlers
{
    public class GerarCartaoVirtualHandler
    {
        private readonly ICartaoVirtualRepository _repository;

        public GerarCartaoVirtualHandler(ICartaoVirtualRepository repository)
        {
            _repository = repository;
        }

        public IDTOResult Handle(GerarCartaoVirtualDTO dto) {
            //Validar DTO
            dto.Validar();

            if (dto.Invalid)
                return new DTOResult(false, "Email Inválido", dto.Notifications);


            //Gerar número de cartão aleatório
            var numeroCartao = string.Empty;
            for( int i = 0; i< 4; i++)
            {
                var random = new Random();
                var blocoCartao = $"{random.Next(1000, 9999)}";
                numeroCartao = $"{numeroCartao + blocoCartao}";
            }

            //Criar entidade e salvar no banco
            var cartaoVirtual = new CartaoVirtual(dto.Email, numeroCartao, DateTime.Now);
            try 
            {
                _repository.AdicionarCartaoVirtual(cartaoVirtual);
            }
            catch (Exception e )
            {
                return new DTOResult(false, "Erro ao salvar os dados", e.Message);
            }

            //Criar dto result e retornar 
             return new DTOResult(true, "Requisição Realizada com Sucesso", new { dto.Email, numeroCartao });
        }
    }
}