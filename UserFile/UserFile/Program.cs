using System;
using System.IO;

namespace UserFile
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            
            
            string path = "C:/Users/Yasmin/Desktop";
            string folderName = "/YasminFolder";
            string HistoryFile = "/History.txt";
           
            
            char cont = 'y';
            while (true)
            {

                Console.WriteLine("Do you want to create a file, delete a file, or edit and exising file? (c, d, e)");
                string input = Console.ReadLine();

                if (input == "c")
                {
                    Console.WriteLine("Please enter the name of the file you want to create:");
                    string fileName = "/" + Console.ReadLine() + ".txt";
                    //To make sure the file doesn't exist
                    if (!File.Exists(path + folderName + fileName))
                    {
                        File.Create(path + folderName + fileName);
                        Console.WriteLine("File " + fileName + " created!");
                    }
                    else
                    {
                        Console.WriteLine("File " + fileName + " already exists!");
                        File.Delete(path + folderName + fileName);
                    }

                    var hist = name + " created " + fileName + " at " + DateTime.Now;
                    File.WriteAllText(path + folderName + HistoryFile, hist);

                    string content = File.ReadAllText(path + folderName + HistoryFile);
                    Console.WriteLine(content);

                }

                else if (input == "d")
                {
                    Console.WriteLine("Please enter the name of the file you want to delete:");
                    string fileName = "/" + Console.ReadLine() + ".txt";
                    if (!File.Exists(path + folderName + fileName))
                    {
                        Console.WriteLine("File doesn't exist.");
                    }
                    else
                    {
                        Console.WriteLine("File deleted successfully!");
                        File.Delete(path + folderName + fileName);
                    }

                    var hist = name + " deleted " + fileName + " at " + DateTime.Now;
                    File.WriteAllText(path + folderName + HistoryFile, hist);

                    string content = File.ReadAllText(path + folderName + HistoryFile);
                    Console.WriteLine(content);
                }

                else if (input == "e")
                {

                    Console.WriteLine("Please enter the name of the file you want to edit:");
                    string fileName = "/" + Console.ReadLine() + ".txt";


                    if (!File.Exists(path + folderName + fileName))
                    {
                        Console.WriteLine(fileName + " doesn't exist!");
                    }
                    else
                    {
                        Console.WriteLine("Enter what you want to write inside the text file: ");
                        string userInput = Console.ReadLine();

                        File.WriteAllText(path + folderName + fileName, userInput);

                        string content = File.ReadAllText(path + folderName + fileName);
                        Console.WriteLine(content);
                    }
                   

                    var hist = name + " edited " + fileName + " at " + DateTime.Now;
                    File.WriteAllText(path + folderName + HistoryFile, hist);

                    string content2 = File.ReadAllText(path + folderName + HistoryFile);
                    Console.WriteLine(content2);
                }

                else
                {
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine("Do you want to continue? (y/n)");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'n')
                    break;

            }
        }
    }
}
