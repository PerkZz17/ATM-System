using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string addMoney;
            double withdraw = 0;
            string name = "";
            string pin = "";
            string option1;
            string option2;

            SqlConnection conectarBD = new SqlConnection(@"Server = DESKTOP-33VTQCF\SQLEXPRESS; Database= AtmDB; Integrated Security=True;");

        Sorry:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t Would you like to");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t     1 - Register a new account");
            Console.WriteLine("\t     2 - Login into your account ");

            Console.Write(" Option: ");
            option1 = Console.ReadLine();

            //Register new bank acc into DB
            if (option1 == "1")
            {
                try
                {

                    conectarBD.Open();
                    Console.WriteLine("\n Lets create a new bank account: ");

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n Name: ");
                        name += Console.ReadLine();
                        Console.Write(" Pin: ");
                        pin += Console.ReadLine();

                        SqlCommand verif = new SqlCommand("SELECT * from Credentials where Name='" + name.ToString() + "'", conectarBD);
                        SqlDataReader drverif = verif.ExecuteReader();

                        if (drverif.Read())
                        {
                            drverif.Close();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Username already registered, please insert a new one");
                            name = "";
                            pin = "";
                        }
                        else
                        {
                            drverif.Close();
                            string Inserir = "INSERT INTO Credentials (Name, Pin) VALUES (@name, @pin)";
                            string bid = "INSERT INTO bank (balance, bid) VALUES (@balance, @bid)";

                            SqlCommand cmdDados = new SqlCommand(Inserir, conectarBD);
                            SqlCommand cmdBid = new SqlCommand(bid, conectarBD);

                            if (name.Length > 0 && pin.Length > 0)
                            {
                                cmdDados.Parameters.AddWithValue("@name", name.ToString());
                                cmdDados.Parameters.AddWithValue("@pin", pin.ToString());
                                cmdBid.Parameters.AddWithValue("@balance", 0);
                                cmdBid.Parameters.AddWithValue("@bid", pin.ToString());
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Please insert valid credentials");
                            }
                            cmdDados.ExecuteNonQuery();
                            cmdBid.ExecuteNonQuery();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Account successfully created");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conectarBD.Close();
                }
                Thread.Sleep(1000);
                goto Sorry;
            }
            else if (option1 == "2")
            {
                try
                {
                    conectarBD.Open();

                    Console.WriteLine("\n Login into your acc: ");

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n Name: ");
                        name = Console.ReadLine();
                        Console.Write(" Pin: ");
                        pin = Console.ReadLine();

                        SqlCommand cmdDados = new SqlCommand("Select * from Credentials where Name='" + name.ToString() + "' and Pin='" + pin.ToString() + "'", conectarBD);
                        SqlDataReader drDados = cmdDados.ExecuteReader();
                        if (drDados.Read())
                        {
                            drDados.Close();
                            if (name.Length > 0 && pin.Length > 0)
                            {
                                cmdDados.ExecuteNonQuery();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n Trying to login.");
                                Thread.Sleep(1000);
                                Console.Write(".");
                                Thread.Sleep(1000);
                                Console.WriteLine(".");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" Successfully logged in");
                                break;
                            }
                        }
                        else
                        {
                            drDados.Close();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Incorrect Credentials");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conectarBD.Close();
                }
            }



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Welcome {0}", name);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n What can we do for you today?");
                Console.WriteLine("\n 1 - Check balance\n 2 - Add money\n 3 - Withdraw money\n 4 - Exit");
                Console.Write(" Option: ");
                option2 = Console.ReadLine();
                switch (option2)
                {
                    case "1":
                        try
                        {
                            conectarBD.Open();

                            SqlCommand cmdDados = new SqlCommand("Select balance from bank where bid='" + pin.ToString() + "'", conectarBD);
                            SqlDataReader drDados = cmdDados.ExecuteReader();
                            if (drDados.Read())
                            {
                                if (drDados.GetValue(0) != null)
                                {
                                    drDados.Close();
                                    cmdDados.ExecuteNonQuery();

                                    SqlDataReader drDados2 = cmdDados.ExecuteReader();
                                    if (drDados2.Read())
                                    {
                                        if ((int)drDados2.GetValue(0) == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("\n Checking balance.");
                                            Thread.Sleep(1000);
                                            Console.Write(".");
                                            Thread.Sleep(1000);
                                            Console.WriteLine(".");
                                            Thread.Sleep(1000);
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\n You have ${0} on your bank account", drDados2.GetValue(0));
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("\n Checking balance.");
                                            Thread.Sleep(1000);
                                            Console.Write(".");
                                            Thread.Sleep(1000);
                                            Console.WriteLine(".");
                                            Thread.Sleep(1000);
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\n You have ${0} on your bank account", drDados2.GetValue(0));

                                        }
                                        drDados2.Close();
                                    }
                                }
                            }
                            else
                            {
                                drDados.Close();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Error trying to get account balance");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            conectarBD.Close();
                        }
                        break;

                    case "2":

                        try
                        {
                            conectarBD.Open();

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n How much money would you like to deposite?: ");
                            addMoney = Console.ReadLine();
                            if (addMoney != null)
                            {
                                //Update balance
                                string update = "UPDATE bank SET balance +='" + addMoney.ToString() + "' where bid='" + pin.ToString() + "'";
                                SqlCommand cmdup = new SqlCommand(update, conectarBD);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n Depositing the money.");
                                Thread.Sleep(1000);
                                Console.Write(".");
                                Thread.Sleep(1000);
                                Console.WriteLine(".");
                                Thread.Sleep(1000);
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n ${0} have been successfully deposited into your account", addMoney);
                                cmdup.ExecuteNonQuery();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n Please insert a valid value");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            conectarBD.Close();
                        }
                        break;

                    case "3":

                        try
                        {
                            int wd;
                            conectarBD.Open();

                            SqlCommand cmdDados = new SqlCommand("Select balance from bank where bid='" + pin.ToString() + "'", conectarBD);
                            SqlDataReader drDados = cmdDados.ExecuteReader();
                            if (drDados.Read())
                            {
                                if (drDados.GetValue(0) != null)
                                {
                                    drDados.Close();
                                    cmdDados.ExecuteNonQuery();

                                    SqlDataReader drDados2 = cmdDados.ExecuteReader();
                                    if (drDados2.Read())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n How much money would you like to withdraw?: ");
                                        withdraw = Convert.ToDouble(Console.ReadLine());
                                        if (withdraw > 0)
                                        {
                                            wd = (int)drDados2.GetValue(0) - (int)withdraw;
                                            drDados2.Close();

                                            string withd = "UPDATE bank SET balance ='" + wd.ToString() + "' where bid='" + pin.ToString() + "'";
                                            SqlCommand cmdup = new SqlCommand(withd, conectarBD);

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("\n Withdrawing your money.");
                                            Thread.Sleep(1000);
                                            Console.Write(".");
                                            Thread.Sleep(1000);
                                            Console.WriteLine(".");
                                            Thread.Sleep(1000);
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("\n ${0} has been successfully withdrawn from your account", withdraw);
                                            cmdup.ExecuteNonQuery();

                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("\n Please insert a valid value");
                                        }
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            conectarBD.Close();
                        }
                        break;

                    case "4":

                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n An error has occured, please insert a valid optionn");
                        break;
                }
            }
        }
    }
}
