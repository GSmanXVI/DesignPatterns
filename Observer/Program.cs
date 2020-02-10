using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();

            var buyer1 = new Buyer { Name = "Gleb", Money = 9999 };
            var buyer2 = new Buyer { Name = "Sabik", Money = 8888 };
            var buyer3 = new Buyer { Name = "Firdovsy", Money = 10 };

            shop.NewItemInShop(new Product { Title = "IPhone", Price = 1999 });

            shop.Subscribe(buyer1);
            shop.Subscribe(buyer2);

            shop.NewItemInShop(new Product { Title = "Samsung", Price = 1599 });
        }
    }

    class Shop
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();
        private List<Product> products = new List<Product>();

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void SellProduct(Product product)
        {
            products.Remove(product);
        }

        public void NewItemInShop(Product product)
        {
            products.Add(product);
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(this, product);
            }
        }
    }

    interface ISubscriber
    {
        void Update(Shop shop, Product newProduct);
    }

    class Buyer : ISubscriber
    {
        public string Name { get; set; }
        public decimal Money { get; set; }

        public void Update(Shop shop, Product newProduct)
        {
            if (newProduct.Title == "Samsung")
            {
                shop.SellProduct(newProduct);
                Money -= newProduct.Price;
            }
        }
    }

    class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }














    //interface IPhoneBuyer
    //{
    //    void Buy(Shop shop);
    //}

    //class Customer : IPhoneBuyer
    //{
    //    public string Name { get; set; }
    //    public int Money { get; set; }

    //    public void Buy(Shop shop)
    //    {
    //        if (this.Money >= shop.NewPhone.Price)
    //        {
    //            this.Money -= shop.NewPhone.Price;
    //            shop.Money += shop.NewPhone.Price;
    //            Console.WriteLine($"{Name} bought {shop.NewPhone.Name}");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"{Name} can't buy {shop.NewPhone.Name} :(");
    //        }
    //    }
    //}

    //class Phone
    //{
    //    public string Name { get; set; }
    //    public int Price { get; set; }
    //}

    //class Shop
    //{
    //    public Phone NewPhone { get; set; } = null;
    //    public int Money { get; set; } = 100000;
    //    public List<IPhoneBuyer> Buyers { get; set; } = new List<IPhoneBuyer>();

    //    public void AddSubscription(IPhoneBuyer buyer)
    //    {
    //        Buyers.Add(buyer);
    //    }

    //    public void RemoveBuyer(IPhoneBuyer buyer)
    //    {
    //        Buyers.Remove(buyer);
    //    }

    //    public void OnNewPhoneArrived(Phone phone)
    //    {
    //        NewPhone = phone;
    //        foreach (var item in Buyers)
    //        {
    //            item.Buy(this);
    //        }
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var shop = new Shop();

    //        var customer1 = new Customer { Name = "Gleb", Money = 50000 };
    //        var customer2 = new Customer { Name = "Alex", Money = 500 };
    //        var customer3 = new Customer { Name = "Ivan", Money = 3000 };

    //        shop.AddSubscription(customer1);
    //        shop.AddSubscription(customer2);
    //        shop.AddSubscription(customer3);

    //        shop.OnNewPhoneArrived(new Phone { Name = "IPhone X", Price = 1000 });
    //    }
    //}
}
