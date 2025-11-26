using CevaMilkrun.Domain.Entities;
using CevaMilkrun.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CevaMilkrun.Application.Features.Milkrun
{
    // 1. O Pedido (Input)
    public class GetMilkrunDataQuery : IRequest<string>
    {
        public string PhoneNumber { get; set; } = string.Empty;
    }
    public class GetMilkrunDataHandler : IRequestHandler<GetMilkrunDataQuery, string>
    {
        private readonly IMilkrunExternalService _externalService;
        private readonly ISearchHistoryRepository _historyRepository;

        public GetMilkrunDataHandler(
            IMilkrunExternalService externalService,
            ISearchHistoryRepository historyRepository)
        {
            _externalService = externalService;
            _historyRepository = historyRepository;
        }

        public async Task<string> Handle(GetMilkrunDataQuery request, CancellationToken cancellationToken)
        {
            // A. Busca na API Externa
            var jsonResult = await _externalService.GetRawJsonAsync(request.PhoneNumber);

            // B. Salva no SQL para auditoria/histórico
            if (!string.IsNullOrEmpty(jsonResult))
            {
                var history = new SearchHistory(request.PhoneNumber, jsonResult, true, null);

                await _historyRepository.AddAsync(history);
                await _historyRepository.SaveChangesAsync();
            }

            return jsonResult;
        }
    }
}