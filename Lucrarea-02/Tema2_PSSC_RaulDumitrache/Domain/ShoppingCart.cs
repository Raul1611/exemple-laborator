using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class ShoppingCart
    {
        public interface IShoppingCart { }

        public record UnvalidatedShoppingCart(IReadOnlyCollection<Product> ProductList) : IShoppingCart;

        public record EmptyShoppingCart(IReadOnlyCollection<Product> ProductList) : IShoppingCart;

        public record ValidatedShoppingCart(IReadOnlyCollection<Product> ProductList) : IShoppingCart;

        public record PayedShoppingCart(IReadOnlyCollection<Product> ProductList, DateTime PayDate) : IShoppingCart;
    }
}
