using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querie
{
    public record GetWalletBalanceQuery(Guid WalletId) : IRequest<decimal>;
}
