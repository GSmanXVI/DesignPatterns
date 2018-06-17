using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //abstract class Command
    //{
    //    public abstract void Execute();
    //    public abstract void UnExecute();
    //}

    //class CalculatorCommand : Command
    //{
    //    public char Operation { get; set; }
    //    public int Operand { get; set; }
    //    Calculator calculator;

    //    public CalculatorCommand(Calculator calculator, char operation, int operand)
    //    {
    //        this.calculator = calculator;
    //        Operation = operation;
    //        Operand = operand;
    //    }

    //    public override void Execute()
    //    {
    //        calculator.Operation(Operation, Operand);
    //    }

    //    public override void UnExecute()
    //    {
    //        calculator.Operation(Undo(Operation), Operand);
    //    }

    //    private char Undo(char Operation)
    //    {
    //        char undo;
    //        switch (Operation)
    //        {
    //            case '+': undo = '-'; break;
    //            case '-': undo = '+'; break;
    //            case '*': undo = '/'; break;
    //            case '/': undo = '*'; break;
    //            default: undo = ' '; break;
    //        }
    //        return undo;
    //    }
    //}

    //class Calculator
    //{
    //    private int curr = 0;

    //    public void Operation(char operation, int operand)
    //    {
    //        switch (operation)
    //        {
    //            case '+': curr += operand; break;
    //            case '-': curr -= operand; break;
    //            case '*': curr *= operand; break;
    //            case '/': curr /= operand; break;
    //        }
    //        Console.WriteLine("Current value = {0,3} (following {1} {2})",
    //            curr, operation, operand);
    //    }
    //}

    //class User
    //{
    //    // Initializers
    //    private Calculator calculator = new Calculator();
    //    private List<Command> commands = new List<Command>();

    //    private int current = 0; //номер последней выполненной команды

    //    public void Redo(int levels)
    //    {
    //        Console.WriteLine("\n---- Redo {0} levels ", levels);

    //        // Делаем возврат операций
    //        for (int i = 0; i < levels; i++)
    //            if (current < commands.Count - 1)
    //                commands[current++].Execute();
    //    }

    //    public void Undo(int levels)
    //    {
    //        Console.WriteLine("\n---- Undo {0} levels ", levels);

    //        // Делаем отмену операций
    //        for (int i = 0; i < levels; i++)
    //            if (current > 0)
    //                commands[--current].UnExecute();
    //    }

    //    public void Compute(char @operator, int operand)
    //    {

    //        // Создаем команду операции и выполняем её
    //        Command command = new CalculatorCommand(calculator, @operator, operand);
    //        command.Execute();

    //        // Добавляем операцию к списку отмены
    //        commands.Add(command);
    //        current++;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Создаем инициатора выполнения команды
    //        User user = new User();

    //        // Пусть он что-нибудь сделает.
    //        user.Compute('+', 100);
    //        user.Compute('-', 50);
    //        user.Compute('*', 10);
    //        user.Compute('/', 2);

    //        // Отменяем 4 команды
    //        user.Undo(2);

    //        user.Compute('+', 1);

    //        // Вернём 3 отменённые команды.
    //        user.Redo(1);

    //        // Ждем ввода пользователя и завершаемся.
    //        Console.Read();
    //    }
    //}
}
