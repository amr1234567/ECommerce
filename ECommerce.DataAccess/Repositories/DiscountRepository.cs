﻿using ECommerce.Core.Entities.Application;
using ECommerce.Core.Exceptions;
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
    internal class DiscountRepository(ECommerceContext context) : IDiscountRepository
    {
        public async Task<Discount> DeleteDiscountFromDb(string discountId)
        {
            var discount = await GetDiscountById(discountId);
            var code = GenerateDiscountCode();
            var discountWithSameCode = await GetDiscountByCode(code);
            while (discountWithSameCode != null)
            {
                code = GenerateDiscountCode();
                discountWithSameCode = await GetDiscountByCode(code);
            }
            context.Discounts.Remove(discount);
            await context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> GenerateNewDiscount(Discount model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.Discounts.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Discount> MarkDiscountAsUsed(string discountId)
        {
            var discount = await GetDiscountById(discountId);
            if (discount.IsUsed)
            {
                throw new DiscountUsedException(discount.Code);
            }
            discount.IsUsed = true;
            await context.SaveChangesAsync();
            return discount;
        }

        public async Task<Discount> GetDiscountById(string discountId)
        {
            ArgumentNullException.ThrowIfNull(discountId);
            var discount = await context.Discounts.FirstOrDefaultAsync(d => d.Id == discountId)
                ?? throw new NotFoundException($"Discount with id {discountId}");
            return discount;
        }

        public async Task<Discount> GetDiscountByCode(string code)
        {
            return await context.Discounts.FirstOrDefaultAsync(d => d.Code.Equals(code))
                ?? throw new NotFoundException($"discount with code {code}");
        }
        private string GenerateDiscountCode()
        {
            var chars = "qwertyuiopasdfghjklzxcvbnm1234567890";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }
    }
}
