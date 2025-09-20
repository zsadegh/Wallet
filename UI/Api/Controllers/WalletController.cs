using Api.ViewModel;
using Application.Command;
using Application.Querie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] BaseWalletRequest request)
        {
            await _mediator.Send(new DepositCommand(request.id, request.amount));
            return Ok();
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] BaseWalletRequest request)
        {
            await _mediator.Send(new WithdrawCommand(request.id, request.amount));
            return Ok();
        }

        [HttpGet("balance/{id}")]
        public async Task<ActionResult<decimal>> GetBalance(Guid id)
        {
            var balance = await _mediator.Send(new GetWalletBalanceQuery(id));
            return Ok(balance);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> transfer([FromBody] TransferWalletRequest request)
        {
            await _mediator.Send(new TransferCommand(request.TargetWalletId,request.id, request.amount));
            return Ok();
        }
    }
}
