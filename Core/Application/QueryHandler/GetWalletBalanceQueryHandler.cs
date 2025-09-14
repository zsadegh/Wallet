using Application.Interface.Repository;
using Application.Querie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandler
{
    public class GetWalletBalanceQueryHandler : IRequestHandler<GetWalletBalanceQuery, decimal>
    {
        private readonly IWalletReadRepository _readRepository;

        public GetWalletBalanceQueryHandler(IWalletReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<decimal> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetBalanceAsync(request.WalletId);
        }
    }
}
