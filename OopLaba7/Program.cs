    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace OopLaba7
    {
        internal class Program
        {
            static MyList myList = new MyList();
            
            static void Main(string[] args)
            {
                 Program program = new Program();
                 program.Greeting();
                 program.AddingElements();
                 bool toContinue = false;
                    do
                    {
                        Thread.Sleep(2000);
                        program.PrintMethods();
                        toContinue = program.CallingMethods(program.SelectMethod());
                    } while (toContinue);
            }
        private void Greeting()
        {
            Console.WriteLine("---BUILDING AND USING DATA STRUCTURES---");
            Console.WriteLine("Please add items to the list");
        }
    private void PrintMethods()
    {
        Console.WriteLine("1-Add Items to List");
        Console.WriteLine("2-Get item from list");
        Console.WriteLine("3-Print List");
        Console.WriteLine("4-Find element multiple of specified value");
        Console.WriteLine("5-Replace elements located in even positions with \"0\" (numbering starts from the list head)");
        Console.WriteLine("6-Get a new list of element values whose values are greater than the specified value");
        Console.WriteLine("7-Delete items located in odd positions (numbering starts from the list head)");
        Console.WriteLine("8-Finish the program");
    }
    private int SelectMethod()
    {
        Console.WriteLine("Please, select a method, press 1-8");
        return EnterNumber(8, 1);
    }
    private int EnterNumber(int max, int min)
    {
        bool checkNumber = false;
        int number = 0;
        while (!checkNumber)
        {
            try {number = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception) { 
                Console.WriteLine("Invalid input. Please, enter a number");
                checkNumber = false;
                continue;
            }
            checkNumber = Validation.ValidateNumber(number, max, min);
            if (!checkNumber)
            {
                Console.WriteLine("Invalid input");
            }
        }
        return number;
    }
    private bool CallingMethods(int index)
    {
        switch (index)
        {
            case 1:
                AddingElements();
                return true;
            case 2:
                {
                    Console.WriteLine("Enter the index of the item " +
                        "you want to retrieve from the list" +
                        " min - 0, max " + (myList.count()-1));
                    int indexOfElement = EnterNumber(myList.count(), 0);
                    Console.WriteLine(myList.GetElement(indexOfElement));
                    return true;
                }
            case 3:
                PrintList(myList.returnArrayList());
                return true;
            case 4:
                {
                    Console.WriteLine("Enter the number for which you want" +
                        " to find multiples in the list");
                    int number = EnterNumber(short.MaxValue, short.MinValue);
                    PrintList(myList.FindMultiples((short)number));
                    return true;
                }
            case 5:
                {
                    myList.ReplaceEvenPositionElementsWithZero();
                    Console.WriteLine("Do you want to see the list");
                    if (MakeChoice())
                        PrintList(myList.returnArrayList());
                    return true;
                }
            case 6:
                {
                    Console.WriteLine("Enter a value relative " +
                        "to which to create a new list");
                    int number = EnterNumber(short.MaxValue, short.MinValue);
                    PrintList(myList.GetValuesGreaterThanThreshold((short)number));
                    return true;
                }
            case 7:
                {
                    myList.DeleteElementsAtNonEvenPositions();
                    Console.WriteLine("Do you want to see the list");
                    if (MakeChoice())
                        PrintList(myList.returnArrayList());
                    return true;
                }
            default:
                break;
        }
        return false;
    }
    private void AddingElements()
    {
        Console.WriteLine("Please enter items, in order to finish typing please enter any letter");
        Console.WriteLine("Maximum value - " + short.MaxValue + " minimum value - " + short.MinValue);
        bool checkNumber = true;
        short input = 0;
        do
        {
            try
            {
                input = short.Parse(Console.ReadLine());
                myList.AddElement(input);
            }
            catch (Exception)
            {
                checkNumber = false;
                Console.WriteLine("Input stopped");
            }
        } while (checkNumber);
    }
    private bool MakeChoice()
    {
        Console.WriteLine("If your answer is yes, press 1," +
            " otherwise press any key");
        string choice = Console.ReadLine();
        return choice.Equals("1");
    }
    private void PrintList(List<short> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }
        }
    }