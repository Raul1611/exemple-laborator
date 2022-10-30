namespace Laborator3_PSSC_RaulDumitrache.Domain
{
    public record ValidatedShoppingCart(ProductCode productCode, Quantity quantity, Address address, Price price);
}
