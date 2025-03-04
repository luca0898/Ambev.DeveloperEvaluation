using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class ProductRating : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public double Rate { get; private set; }
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
