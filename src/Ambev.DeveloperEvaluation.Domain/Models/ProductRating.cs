using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models
{
    /// <summary>
    /// Represents the rating of a product as an entity.
    /// </summary>
    public class ProductRating : BaseEntity
    {
        /// <summary>
        /// The ID of the product this rating belongs to.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// The average rate of the product (0 to 5).
        /// </summary>
        public double Rate { get; private set; }

        /// <summary>
        /// The total number of reviews for the product.
        /// </summary>
        public int Count { get; private set; }

        private ProductRating() { }

        public ProductRating(Guid productId, double rate, int count)
        {
            Validate(rate, count);

            ProductId = productId;
            Rate = rate;
            Count = count;
        }

        public void Update(double rate, int count)
        {
            Validate(rate, count);

            Rate = rate;
            Count = count;
        }

        private static void Validate(double rate, int count)
        {
            if (rate < 0 || rate > 5)
                throw new ArgumentException("Rate must be between 0 and 5.");

            if (count < 0)
                throw new ArgumentException("Count must be zero or greater.");
        }
    }
}
