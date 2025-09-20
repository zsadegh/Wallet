using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public record TransferCommand(Guid TargetWalletId,Guid CurrentWalletId, decimal Amount) : IRequest;
}
