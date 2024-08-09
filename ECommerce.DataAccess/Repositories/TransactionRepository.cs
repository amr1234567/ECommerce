using ECommerce.Core.Entities.Application;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories
{
    internal class TransactionRepository(ECommerceContext context) : ITransactionRepository
    {

        public async Task<bool> AddTransaction(Transaction model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.Transactions.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Transaction> CancelTransaction(string transactionId)
        {
            var transaction = await GetTransactionById(transactionId);
            transaction.Status = TransactionStatus.Canceled;
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> ConfirmTransactionDelivered(string transactionId)
        {
            var transaction = await GetTransactionById(transactionId);
            transaction.Status = TransactionStatus.Delivered;
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> ConfirmTransactionGoToDelivery(string transactionId)
        {
            var transaction = await GetTransactionById(transactionId);
            transaction.Status = TransactionStatus.InWayToConsumer;
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public Task<IQueryable<Transaction>> GetAllCompletedTransactionForConsumer(string consumerId)
        {
            return Task.FromResult(context.Transactions
                .Where(t => t.ConsumerId.Equals(consumerId))
                .Where(t => t.Status.Equals(TransactionStatus.Canceled) || t.Status.Equals(TransactionStatus.Delivered)));
        }

        public Task<IQueryable<Transaction>> GetAllCompletedTransactionForDelivery(string DeliveryId)
        {
            return Task.FromResult(context.Transactions
                .Where(t => t.DelivaryId.Equals(DeliveryId))
                .Where(t => t.Status.Equals(TransactionStatus.Delivered)));
        }

        public async Task<List<Product>> GetAllProductsInTransaction(string transactionId)
        {
            var transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id.Equals(transactionId))
                ?? throw new NotFoundException($"Transaction with id {transactionId}");
            var products = new List<Product>();
            foreach (var item in transaction.Items)
            {
                var product = await context.Products.FirstOrDefaultAsync(p => p.Id.Equals(item.ProductID))
                    ?? throw new NotFoundException($"Product with id {item.ProductID}");
                products.Add(product);
            }
            return products;
        }

        public Task<IQueryable<Transaction>> GetAllTransactionForConsumer(string consumerId)
        {
            return Task.FromResult(context.Transactions.Where(t => t.ConsumerId.Equals(consumerId)));
        }

        public Task<IQueryable<Transaction>> GetAllTransactionForDelivery(string deliveryID)
        {
            return Task.FromResult(context.Transactions.Where(t => t.DelivaryId.Equals(deliveryID)));
        }

        public Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForConsumer(string consumerId)
        {
            return Task.FromResult(context.Transactions.Where(t => t.ConsumerId.Equals(consumerId))
                .Where(t => t.Status.Equals(TransactionStatus.UnderProcess)));
        }

        public Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForDelivery(string deliveryId)
        {
            return Task.FromResult(context.Transactions.Where(t => t.DelivaryId.Equals(deliveryId))
                .Where(t => t.Status.Equals(TransactionStatus.UnderProcess)));
        }

        public async Task<Transaction> GetTransactionById(string transactionId)
        {
            var transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id.Equals(transactionId))
                ?? throw new NotFoundException($"Transaction with id {transactionId}");
            return transaction;
        }
    }
}
