namespace Tema4_PSSC_RaulDumitrache.Domain
{
    public record ValidatedShoppingCart(ProductCode productCode, Quantity quantity, Address address, Price price);
}
