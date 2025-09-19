using Application.Command;
using Application.Interface.Repository;
using Domain.ValueObjec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandler
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand>
    {
        private readonly IWalletRepository _repository;

        public WithdrawCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _repository.GetByIdAsync(request.WalletId);
            if (wallet == null) throw new Exception("Wallet not found");

            wallet.Withdraw(new Money(request.Amount));
            await _repository.SaveAsync(wallet);
        }
    }
}
