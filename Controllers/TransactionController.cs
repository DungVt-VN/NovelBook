using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Transaction;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TransactionsController(ApplicationDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromBody] TransactionDto transactionDto)
        {
            var user = await _userManager.FindByIdAsync(transactionDto.AppUserId);
            if (user == null)
            {
                return NotFound();
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var transactionRecord = new Transaction
                    {
                        AppUserId = user.Id,
                        Amount = transactionDto.Amount,
                        Coins = transactionDto.Amount / 1000,
                        TransactionDate = DateTime.UtcNow
                    };

                    user.Balance += transactionRecord.Coins;

                    _context.Transactions.Add(transactionRecord);
                    _context.Users.Update(user);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return CreatedAtAction(nameof(GetTransaction), new { id = transactionRecord.TransactionId }, transactionRecord);
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }
    }

}