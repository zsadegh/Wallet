using Application.Command;
using Application.Interface.Repository;
using Domain.Common;
using Domain.Entity;
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
            var targetWallet = await _repository.GetByIdAsync(request.TargetWalletId);
            var currentWallet = await _repository.GetByIdAsync(request.CurrentWalletId);
            if (targetWallet == null || currentWallet==null) throw new Exception("Wallet not found");

            currentWallet.Transfer(targetWallet, new Money(request.Amount));
            await _repository.SaveTransactionAsync(new Transaction(Guid.NewGuid(), currentWallet.Balance, TransactionType.Transfer));
        }
    }
}
