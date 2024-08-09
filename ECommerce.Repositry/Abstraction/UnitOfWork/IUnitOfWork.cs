// Ignore Spelling: Repositry


namespace ECommerce.Repositry.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBugReportServices BugReportServices { get; }
        IProductServices ProductServices { get; }
        ICategoryServices CategoryServices { get; }
        ISubCategoryServices SubCategoryServices { get; }
        IDiscountServices IDiscountServices { get; }
        ISellerServices SellerServices { get; }
        IShopCartServices ShopCartServices { get; }
        ITransactionServices TransactionServices { get; }
    }
}
