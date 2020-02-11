using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DataReader dataReader = new TxtDataReader();
            var total = dataReader.GetProductsTotalPrice("products.txt");
            Console.WriteLine(total);
        }
    }

    //txt & csv

    class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }


    abstract class DataReader
    {
        abstract public IEnumerable<Product> ReadProductsFromFile(string filename);

        virtual public decimal GetProductsTotalPrice(string filename)
        {
            var products = ReadProductsFromFile(filename);
            return products.Sum(x => x.Price);
        }
    }

    class TxtDataReader : DataReader
    {
        public override IEnumerable<Product> ReadProductsFromFile(string filename)
        {
            List<Product> products = new List<Product>();

            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product
                {
                    Title = items[0],
                    Price = decimal.Parse(items[1])
                });
            }

            return products;
        }
    }

    class CsvDataReader : DataReader
    {
        public override IEnumerable<Product> ReadProductsFromFile(string filename)
        {
            List<Product> products = new List<Product>();

            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var items = line.Split(',');
                products.Add(new Product
                {
                    Title = items[0],
                    Price = decimal.Parse(items[1])
                });
            }

            return products;
        }
    }
}
