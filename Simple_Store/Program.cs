using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discount_Store;

namespace Simple_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Username: "); string userName = Console.ReadLine();
            Console.Write("Enter Password: "); string userPass = Console.ReadLine();
            if (userName == "JovTim" && userPass == "jovan123")
            {
                Dictionary<string, int> store = new Dictionary<string, int>()
                {
                    {"Pencil", 20 },
                    {"Ballpen", 25 },
                    {"Eraser", 15 },
                    {"Yellow Pad", 40 },
                    { "Notebook", 30}
                };

                Dictionary<string, int> userCart = new Dictionary<string, int>() { };

                while (true)
                {
                    Console.WriteLine("------SCHOOL STORE------");
                    foreach (KeyValuePair<string, int> item in store)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }

                    Console.WriteLine("\n\n------MY CART-------");
                    foreach (KeyValuePair<string, int> cartItem in userCart)
                    {
                        Console.WriteLine($"{cartItem.Key} - {cartItem.Value}");
                    }

                    Console.Write("\n\nEnter Item[Press Enter to stop]: "); string userChoose = Console.ReadLine();
                    Console.Clear(); // Clear Console Screen
                    if (userChoose == "") // calculate
                    {
                        Dictionary<string, int> calculatedCart = new Dictionary<string, int>() { };
                        int totalPrice = 0;
                        int DiscountedPrice = 0;

                        Console.WriteLine("-----Total Items-----");
                        foreach (KeyValuePair<string, int> j in userCart)
                        {
                            calculatedCart[j.Key] = userCart[j.Key] * store[j.Key];
                            totalPrice += userCart[j.Key] * store[j.Key];
                        }

                        foreach (KeyValuePair<string, int> a in calculatedCart)
                        {
                            Console.WriteLine($"{a.Key} - {a.Value}");
                        }
                        Console.WriteLine($"Total Price: {totalPrice}");

                        Console.WriteLine("-------ENTER DISCOUNT-------\n[1]Loyalty Discount\n[2]Senior Discount\n[3]Student Discount");
                        Console.Write("Enter Discount: "); string userOption = Console.ReadLine();
                        discount discount = new discount();
                        if (userOption == "1")
                        {
                            DiscountedPrice += discount.loyaltyDiscount(totalPrice);
                        }
                        else if (userOption == "2")
                        {
                            DiscountedPrice += discount.seniorDiscount(totalPrice);
                        }
                        else if (userOption == "3")
                        {
                            DiscountedPrice += discount.studentDiscount(totalPrice);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Input!");
                        }
                        Console.WriteLine($"Discounted Price: {DiscountedPrice}");
                        Console.Write("Payment: "); int userPayment = Convert.ToInt32(Console.ReadLine());

                        if (userPayment < DiscountedPrice)
                        {
                            Console.WriteLine("Not Enough!");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("-----RECEIPT-----");
                            foreach (KeyValuePair<string, int> keyval in calculatedCart)
                            {
                                Console.WriteLine($"{keyval.Key} -- {keyval.Value}");
                            }
                            Console.WriteLine($"Total Price: {totalPrice}");
                            Console.WriteLine($"Discounted Price: {DiscountedPrice}");
                            Console.WriteLine($"Payment: {userPayment}");
                            Console.WriteLine($"Change: {userPayment - DiscountedPrice}");
                            Console.WriteLine("-----THANK YOU FOR SHOPPING!-----");
                            break;
                        }
                     

                    }

                    if (store.ContainsKey(userChoose))
                    {
                        if (userCart.ContainsKey(userChoose)) // if userChoose is in userCart then +1, else add item and 1
                        {
                            userCart[userChoose] += 1;
                        }
                        else
                        {
                            userCart[userChoose] = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item is not available");
                    }

                }
            }
            else
            {
                Console.WriteLine("Username or Password is Incorrect! Please Try Again!");
            }
        }
    }
}
