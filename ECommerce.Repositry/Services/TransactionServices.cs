using ECommerce.Core.Entities.Application;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    internal class TransactionServices(IManagerRepository managerRepository, IUserServices userServices) : ITransactionServices
    {
        public async Task<bool> AddTransaction(TransactionToAddModel model)
        {
            var res = await managerRepository.TransactionRepository.AddTransaction(await model.ToModel(managerRepository));
            return res;
        }

        public async Task<bool> AssignDeliveryManToTransaction(string deliveryId, string transactionId)
        {
            var res = await managerRepository.TransactionRepository.AssignDeliveryManToTransaction(deliveryId, transactionId);
            return res;
        }

        public async Task<bool> AssignDeliveryManToTransactions(string deliveryId, params string[] transactionsIds)
        {
            var res = await managerRepository.TransactionRepository.AssignDeliveryManToTransactions(deliveryId, transactionsIds);
            return res;
        }

        public async Task<TransactionResponse> CancelTransaction(string transactionId)
        {
            var transaction = await managerRepository.TransactionRepository.CancelTransaction(transactionId);
            return new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            };
        }

        public async Task<TransactionResponse> ConfirmTransactionDelivered(string transactionId)
        {
            var transaction = await managerRepository.TransactionRepository.ConfirmTransactionDelivered(transactionId);
            return new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            };
        }

        public async Task<TransactionResponse> ConfirmTransactionGoToDelivery(string transactionId)
        {
            var transaction = await managerRepository.TransactionRepository.ConfirmTransactionGoToDelivery(transactionId);
            return new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            };
        }

        public async Task<IQueryable<TransactionResponse>> GetAllCompletedTransactionForConsumer(string consumerId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllCompletedTransactionForConsumer(consumerId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<IQueryable<TransactionResponse>> GetAllCompletedTransactionForDelivery(string DeliveryId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllCompletedTransactionForDelivery(DeliveryId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<List<ProductResponse>> GetAllProductsInTransaction(string transactionId)
        {
            var products = await managerRepository.TransactionRepository.GetAllProductsInTransaction(transactionId);
            return products.Select(product => new ProductResponse
            {
                ProductPrice = product.RealPrice,
                ProductDescription = product.Description,
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(product.CategoryId).Result.Name,
                SellerName = managerRepository.SellerRepository.GetSellerById(product.SellerId).Result.Name,
                SubCategoryName = string.IsNullOrEmpty(product.SubCategoryId) ?
                string.Empty :
                managerRepository.SubCategoryRepository.GetSubCategoryBuyId(product.SubCategoryId).Result.Name,
                ProductQuantity = product.Quantity,
                CategoryId = product.CategoryId,
                ProductId = product.Id,
                ProductName = product.Name,
                SubCategoryId = product.SubCategoryId,
                SellerId = product.SellerId,
                DiscountPrecentage = product.Discount is not null ? product.Discount.DiscountPercentage : 0,
                FirstDateForDiscount = product.Discount is not null ? product.Discount.FirstDate : null,
                FinalDateForDiscount = product.Discount is not null ? product.Discount.FinalDate : null
            }).ToList();
        }

        public async Task<IQueryable<TransactionResponse>> GetAllTransactionForConsumer(string consumerId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllTransactionForConsumer(consumerId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<IQueryable<TransactionResponse>> GetAllTransactionForDelivery(string deliveryId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllTransactionForConsumer(deliveryId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<IQueryable<TransactionResponse>> GetAllTransactions(string? hour, string? day, string? month, string? year)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllTransactions(hour, day, month, year);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<IQueryable<TransactionResponse>> GetAllUnderProgressTransactionForConsumer(string consumerId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllUnderProgressTransactionForConsumer(consumerId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<IQueryable<TransactionResponse>> GetAllUnderProgressTransactionForDelivery(string deliveryId)
        {
            var transactions = await managerRepository.TransactionRepository.GetAllUnderProgressTransactionForDelivery(deliveryId);
            return transactions.Select(transaction => new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            });
        }

        public async Task<TransactionResponse> GetTransactionById(string transactionId)
        {
            var transaction = await managerRepository.TransactionRepository.GetTransactionById(transactionId);
            return new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            };
        }

        public async Task<TransactionResponse> SetExpectedReceiveDate(string transactionId, DateTime date)
        {
            var transaction = await managerRepository.TransactionRepository.SetExpectedReceiveDate(transactionId, date);
            return new TransactionResponse
            {
                DelivaryId = transaction.DelivaryId,
                ConsumerId = transaction.ConsumerId,
                Status = transaction.Status.ToString(),
                StreetName = transaction.Location.StreetName,
                CityName = transaction.Location.CityName,
                CountryName = transaction.Location.CountryName,
                ZipCode = transaction.Location.ZipCode,
                PriceAfterDiscount = transaction.PriceAfterDiscount,
                DiscountId = transaction.DiscountId,
                ConsumerName = userServices.GetConsumerById(transaction.ConsumerId).Result.Name,
                DelivaryName = string.IsNullOrEmpty(transaction.DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(transaction.DelivaryId).Result.Name,
                Id = transaction.Id,
                ExpectedReceiveDate = transaction.ExpectedReceiveDate,
                TotalPrice = transaction.TotalPrice,
                Items = transaction.Items,
            };
        }
    }
}
