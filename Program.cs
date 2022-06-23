using System;
using System.IO;

namespace NCCleaner
{
    class Program
    {

        static void Main(string[] args)
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\Solirax\NeosVR\Cache";
            //string path = @"F:\Temp";
            int days = 14;
            TimeSpan time = TimeSpan.FromDays(days);
            ConsoleKey answer;
            ConsoleKey cont = ConsoleKey.Y;
            bool done = false;

            while (!done)
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("The currently selected Cache location exits! It is: " + path);
                    Console.WriteLine("Have you moved your cache location or wish to clean a diffrent folder?");
                    Console.WriteLine("Y to accept or any key to change path");
                    answer = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (answer == cont)
                    {

                        Console.WriteLine("Currently set to remove all files not used in " + time.Days + " days.");
                        Console.WriteLine("Is this a good number?");
                        answer = Console.ReadKey().Key;
                        Console.WriteLine();

                        if (answer == cont)
                        {

                            Console.WriteLine("This will remoce all files in " + path + " that have not been used in " + time.Days + " days.");
                            Console.WriteLine("Is this okay?");
                            answer = Console.ReadKey().Key;
                            Console.WriteLine();
                            if (answer == cont)
                            {

                                string[] files = Directory.GetFiles(path);
                                for (int i = 0; i < files.Length; i++)
                                {
                                    Console.WriteLine(path + @"\" + Path.GetFileName(files[i]));
                                    if (File.GetLastAccessTime(path + @"\" + Path.GetFileName(files[i])) < DateTime.UtcNow.Subtract(time))
                                    {
                                        File.Delete(files[i]);
                                        Console.WriteLine("Deleted: " + files[i]);


                                    }

                                }

                                done = true;


                            }
                        }
                    }



                }
                else
                {
                    Console.WriteLine(path + " does not exist. Please input new path.");
                    path = Console.ReadLine();
                }

            }





        }
    }
}
