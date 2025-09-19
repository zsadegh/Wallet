using Application.Command;
using Application.Interface.Repository;
using Domain.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand>
    {
        private readonly IWalletRepository _repository;

        public TransferCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _repository.GetByIdAsync(request.TargetWalletId);
            if (wallet==null) throw new Exception("Wallet not found");

            wallet.Transfer(wallet, new Money(request.Amount));
            await _repository.SaveAsync(wallet);
        }
    }
}
