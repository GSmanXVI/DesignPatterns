using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Repositiry
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork();
            unitOfWork.People.Create(new Person 
            { 
                Id = "1",
                FullName = "Gleb Skripnikov",
                Age = 26
            });
            unitOfWork.People.Create(new Person
            {
                Id = "2",
                FullName = "Firdovsy Babatov",
                Age = 40
            });

            unitOfWork.Cards.Create(new Card
            {
                OwnerId = "1",
                Number = "1111222233334444",
                Pin = 1234,
                Balance = 100000
            });

            unitOfWork.Save();
        }
    }

    class Person
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    class Card
    {
        public string OwnerId { get; set; }
        public string Number { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }
    }

    //CRUD (Create, Read, Update, Delete)
    interface IRepositiry<T> where T : class
    {
        //Read
        T Get(string id);
        IEnumerable<T> GetAll();

        //Create
        void Create(T item);

        //Update
        void Update(string id, T item);

        //Delete
        void Delele(string id);
    }

    abstract class Repositiry<T> : IRepositiry<T> where T : class
    {
        static protected Dictionary<string, T> storage = new Dictionary<string, T>();

        virtual public T Get(string id)
        {
            storage.TryGetValue(id, out T item);
            return item;
        }

        virtual public IEnumerable<T> GetAll()
        {
            return storage.Select(x => x.Value);
        }

        abstract public void Create(T item);

        virtual public void Update(string id, T item)
        {
            storage[id] = item;
        }

        virtual public void Delele(string id)
        {
            storage.Remove(id);
        }
    }

    class PersonRepositiory : Repositiry<Person>
    {
        override public void Create(Person item)
        {
            storage.Add(item.Id, item);
        }
    }

    class CardRepositiory : Repositiry<Card>
    {
        override public void Create(Card item)
        {
            storage.Add(item.Number, item);
        }
    }

    class UnitOfWork
    {
        public PersonRepositiory People { get; set; } = new PersonRepositiory();
        public CardRepositiory Cards { get; set; } = new CardRepositiory();

        public void Save()
        {
            var peopleJson = JsonSerializer.Serialize(People.GetAll());
            var cardsJson = JsonSerializer.Serialize(Cards.GetAll());

            File.WriteAllText("people.json", peopleJson);
            File.WriteAllText("cards.json", cardsJson);
        }
    }
}
