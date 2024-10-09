using AutoMapper;
using ClientesApp.Application.Commands;
using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces.Applications;
using ClientesApp.Application.Interfaces.Messages;
using ClientesApp.Application.Models;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Services;
using MediatR;
using Newtonsoft.Json;

namespace ClientesApp.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMessagePublisher _messagePublisher;

        public ClienteAppService(IClienteDomainService clienteDomainService, IMapper mapper, IMediator mediator, IMessagePublisher messagePublisher)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
            _mediator = mediator;
            _messagePublisher = messagePublisher;
        }

        public async Task<ClienteResponseDto> AddAsync(ClienteRequestDto request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            cliente.Id = Guid.NewGuid();

            var result = await _clienteDomainService.AddAsync(cliente);

            #region Gravar log
            await _mediator.Send(new ClienteCommand
            {
                LogCliente = new LogClienteModel
                {
                    Id = Guid.NewGuid(),
                    DataOperacao = DateTime.Now,
                    TipoOperacao = TipoOperacao.Add,
                    ClienteId = cliente.Id,
                    DadosClientes = JsonConvert.SerializeObject(cliente)
                }
            });
            #endregion

            #region Gerar evento de mensageria
            await _messagePublisher.Send(new Events.ClienteCadastradoEvent 
            { 
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                DataCadastro = DateTime.Now,
                MensagemCadastro = $"Olá, {cliente.Nome}, sua conta foi criada com sucesso!"
            });
            #endregion

            return _mapper.Map<ClienteResponseDto>(result);
        }

        public async Task<ClienteResponseDto> UpdateAsync(Guid id, ClienteRequestDto request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            cliente.Id = id;

            var result = await _clienteDomainService.UpdateAsync(cliente);

            #region
            await _mediator.Send(new ClienteCommand
            {
                LogCliente = new LogClienteModel
                {
                    Id = Guid.NewGuid(),
                    DataOperacao = DateTime.Now,
                    TipoOperacao = TipoOperacao.Update,
                    ClienteId = cliente.Id,
                    DadosClientes = JsonConvert.SerializeObject(cliente)
                }
            });
            #endregion

            return _mapper.Map<ClienteResponseDto>(result);
        }

        public async Task<ClienteResponseDto> DeleteAsync(Guid id)
        {
            var result = await _clienteDomainService.DeleteAsync(id);

            #region
            await _mediator.Send(new ClienteCommand
            {
                LogCliente = new LogClienteModel
                {
                    Id = Guid.NewGuid(),
                    DataOperacao = DateTime.Now,
                    TipoOperacao = TipoOperacao.Delete,
                    ClienteId = result.Id,
                    DadosClientes = JsonConvert.SerializeObject(result)
                }
            });
            #endregion

            return _mapper.Map<ClienteResponseDto>(result);
        }

        public async Task<List<ClienteResponseDto>> GetManyAsync(string nome)
        {
            var result = await _clienteDomainService.GetManyAsync(nome);
            return _mapper.Map<List<ClienteResponseDto>>(result);
        }

        public async Task<ClienteResponseDto?> GetByIdAsync(Guid id)
        {
            var result = await _clienteDomainService.GetByIdAsync(id);
            return _mapper.Map<ClienteResponseDto>(result);
        }

        public void Dispose()
        {
            _clienteDomainService.Dispose();
        }
    }
}



