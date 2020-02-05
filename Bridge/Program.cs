using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Storage<Contact> contactStorage = new ContactStorage(new XmlSaveLoader<List<Contact>>());
            //contactStorage.Add(new Contact { Name = "Gleb", Phone = "123123" });
            //contactStorage.Add(new Contact { Name = "Sabik", Phone = "987987" });
            //contactStorage.Save();

            Storage<ToDoItem> taskStorage = new ToDoItemStorage(new JsonSaveLoader<List<ToDoItem>>());
            taskStorage.Add(new ToDoItem { Title = "Feed my cat", Done = true });
            taskStorage.Add(new ToDoItem { Title = "Do my homework", Done = false });
            taskStorage.Save();
        }
    }

    [Serializable]
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    [Serializable]
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool Done { get; set; }
    }

    abstract class Storage<T> where T : class
    {
        protected ISaveLoader<List<T>> saveLoader;

        public Storage(ISaveLoader<List<T>> saveLoader)
        {
            this.saveLoader = saveLoader;
        }

        public abstract void Add(T item);
        public abstract void Save();
        public abstract void Load();
    }

    class ContactStorage : Storage<Contact>
    {
        public ContactStorage(ISaveLoader<List<Contact>> saveLoader) : base(saveLoader)
        {

        }

        private List<Contact> contacts = new List<Contact>();

        public override void Add(Contact item)
        {
            contacts.Add(item);
        }

        public override void Load()
        {
            contacts = saveLoader.Load("contacts");
        }

        public override void Save()
        {
            saveLoader.Save(contacts, "contacts");
        }
    }

    class ToDoItemStorage : Storage<ToDoItem>
    {
        public ToDoItemStorage(ISaveLoader<List<ToDoItem>> saveLoader) : base(saveLoader)
        {

        }

        private List<ToDoItem> toDoItems = new List<ToDoItem>();

        public override void Add(ToDoItem item)
        {
            toDoItems.Add(item);
        }

        public override void Load()
        {
            toDoItems = saveLoader.Load("items");
        }

        public override void Save()
        {
            saveLoader.Save(toDoItems, "items");
        }
    }



    interface ISaveLoader<T> where T : class
    {
        void Save(T data, string filename);
        T Load(string filename);
    }

    class JsonSaveLoader<T> : ISaveLoader<T> where T : class
    {
        public T Load(string filename)
        {
            filename += ".json";
            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<T>(json);
        }

        public void Save(T data, string filename)
        {
            filename += ".json";
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filename, json);
        }
    }

    class XmlSaveLoader<T> : ISaveLoader<T> where T : class
    {
        public T Load(string filename)
        {
            filename += ".xml";
            var serializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                var data = serializer.Deserialize(fileStream);
                return data as T;
            }
        }

        public void Save(T data, string filename)
        {
            filename += ".xml";
            var serializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(fileStream, data);
            }
        }
    }
}
