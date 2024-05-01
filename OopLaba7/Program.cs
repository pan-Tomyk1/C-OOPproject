    using System;
    using System.Threading;

    namespace OopLaba7
    {
        internal class Program
        {
            static readonly MyList MyList = new MyList();

            private static void Main()
            {
                Program program = new Program();
                program.Greeting();
                program.AddingElements();
                bool toContinue;
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
                Console.WriteLine(
                    "5-Replace elements located in even positions with \"0\" (numbering starts from the list head)");
                Console.WriteLine(
                    "6-Get a new list of element values whose values are greater than the specified value");
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
                    try
                    {
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input. Please, enter a number");
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
                                          " min - 0, max " + (MyList.Size() - 1));
                        int indexOfElement = EnterNumber(MyList.Size(), 0);
                        Console.WriteLine(MyList.Get(indexOfElement));
                        return true;
                    }
                    case 3:
                        MyList.PrintList();
                        return true;
                    case 4:
                    {
                        Console.WriteLine("Enter the number for which you want" +
                                          " to find multiples in the list");
                        int number = EnterNumber(short.MaxValue, short.MinValue);
                        MyList.FindMultiples((short)number).PrintList();
                        return true;
                    }
                    case 5:
                    {
                        MyList.ReplaceEvenPositionElementsWithZero();
                        Console.WriteLine("Do you want to see the list");
                        if (MakeChoice())
                            MyList.PrintList();
                        return true;
                    }
                    case 6:
                    {
                        Console.WriteLine("Enter a value relative " +
                                          "to which to create a new list");
                        int number = EnterNumber(short.MaxValue, short.MinValue);
                        MyList.GetValuesGreaterThanThreshold((short)number).PrintList();
                        return true;
                    }
                    case 7:
                    {
                        MyList.DeleteElementsAtNonEvenPositions();
                        Console.WriteLine("Do you want to see the list");
                        if (MakeChoice())
                            MyList.PrintList();
                        return true;
                    }
                }

                return false;
            }

            private void AddingElements()
            {
                Console.WriteLine("Please enter items, in order to finish typing please enter any letter");
                Console.WriteLine("Maximum value - " + short.MaxValue + " minimum value - " + short.MinValue);
                bool checkNumber = true;
                short input;
                do
                {
                    try
                    {
                        input = short.Parse(Console.ReadLine());
                        MyList.Add(input);
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
                return choice=="1";
            }
        }
    }