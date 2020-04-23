using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippets.DesignPatterns.SpecificationPattern
{
    public class SpecificationPattern
    {
        public static void Run()
        {
            // https://www.cnblogs.com/Leo_wl/p/4507153.html
            var nums = Enumerable.Range(-5, 11);
            Console.WriteLine($"Array:{string.Join(",", nums.ToArray())}");
            ISpecification<int> evenSpec = new EvenSpecification();
            var compositeSpecification = GetCompositeSpecification(evenSpec);

            foreach (var item in nums.Where(x => compositeSpecification.IsSatisfiedBy(x)))
            {
                // 输出既是正数又是偶数的数
                Console.WriteLine(item);
            }
        }
        private static ISpecification<int> GetCompositeSpecification(ISpecification<int> spec)
        {
            ISpecification<int> plusSpec = new PlusSpecification();
            return spec.And(plusSpec);
        }
    }
    public interface IProductRespository
    {
        Product GetBySpecification(ISpecification<Product> spec);
        IEnumerable<Product> FindBySpecification(ISpecification<Product> spec);
    }

    public class IdEqualSpecification : CompositeSpecification<Product>
    {
        private readonly Guid _id;
        public IdEqualSpecification(Guid id)
        {
            _id = id;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Id.Equals(_id);
        }
    }

    public class NameEqualSpecification : CompositeSpecification<Product>
    {
        private readonly string _name;

        public NameEqualSpecification(string name)
        {
            _name = name;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Name.Equals(_name);
        }
    }

    public class NewProductsSpecification : CompositeSpecification<Product>
    {
        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.IsNew == true;
        }
    }
    // 具体规约，偶数规约
    public class EvenSpecification : CompositeSpecification<int>
    {
        public override bool IsSatisfiedBy(int candidate)
        {
            return candidate % 2 == 0;
        }
    }

    // 具体的规约，正数规约
    public class PlusSpecification : CompositeSpecification<int>
    {
        public override bool IsSatisfiedBy(int candidate)
        {
            return candidate > 0;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
    }
}
