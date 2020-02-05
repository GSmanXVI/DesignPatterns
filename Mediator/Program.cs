using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form();

            //User UI actions (fake)
            form.NameTextBox.Text = "Test";
            form.NameTextBox.TextBoxTextChanged();
            form.AddButton.ButtonClick();
        }
    }

    //Mediator
    class Form
    {
        public Button AddButton { get; set; }
        public TextBox NameTextBox { get; set; }
        public ListBox PeopleListBox { get; set; }

        public Form()
        {
            InitializeComponents();
            AddButton.Enabled = false;
        }

        private void InitializeComponents()
        {
            AddButton = new Button();
            NameTextBox = new TextBox();
            PeopleListBox = new ListBox();

            AddButton.Click += OnAddButtonClick;
            NameTextBox.TextChanged += OnNameTextBoxTextChanged;
        }

        public void OnAddButtonClick()
        {
            var name = NameTextBox.Text;
            PeopleListBox.Items.Add(name);
        }

        public void OnNameTextBoxTextChanged()
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
            }
        }
    }

    //Base Component
    abstract class Control
    {

    }

    //Component
    class Button : Control
    {
        public bool Enabled { get; set; }
        public event Action Click;

        public void ButtonClick()
        {
            if (Enabled)
            {
                Click?.Invoke();
            }
        }
    }

    //Component
    class TextBox : Control
    {
        public string Text { get; set; }
        public event Action TextChanged;

        public void TextBoxTextChanged()
        {
            TextChanged?.Invoke();
        }
    }

    //Component
    class ListBox : Control
    {
        public List<string> Items { get; set; }
    }
}
