using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OOP2_GIT_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program will read the contents of two text files, chosen by the user and compare the contents
            //If they are the same a message will inform the user of that
            //And if they are different a message will inform the user of that

            //Array used to store the filepaths for each txt file
            var fileDir = new string[] { @"GitRepositories_1a.txt", @"GitRepositories_1b.txt", @"GitRepositories_2a.txt", @"GitRepositories_2b.txt", @"GitRepositories_3a.txt", @"GitRepositories_3b.txt", @"GitDiff.txt" };

            Console.WriteLine("Please choose two files to compare. \n 0 - GitRepositories_1a \n 1 - GitRepositories_1b \n 2 - GitRepositories_2a \n 3 - GitRepositories_2b \n 4 - GitRepositories_3a \n 5 - GitRepositories_3b");

            //Takes the user input and stores as a variable called userInput, int.parse is used to convert the string into an int, representing the array index
            Console.WriteLine("Enter the index of file 1: ");
            int userInput = int.Parse(Console.ReadLine());

            //^^^ Same as above ^^^
            Console.WriteLine("Enter the index of file 2:  ");
            int userInput2 = int.Parse(Console.ReadLine());

            //Points towards the given file dir, the userInput variable represents the given index in the array and userFile represents the data to be read
            string userFile = fileDir[userInput];
            string userFile2 = fileDir[userInput2];


            ////Reads the file, stores as a string and closes, whole txt file stored as string can be compared easily
            StreamReader readFile = new StreamReader(userFile);
            string fileContents1 = readFile.ReadToEnd();
            readFile.Close();

            //^^^ Same as above ^^^
            StreamReader readFile2 = new StreamReader(userFile2);
            string fileContents2 = readFile2.ReadToEnd();
            readFile2.Close();

            //Opens the text file for character by character comparison
            FileStream rtreadFile;
            rtreadFile = new FileStream(userFile, FileMode.Open);

            //^^^ Same as above ^^^
            FileStream rtreadFile2;
            rtreadFile2 = new FileStream(userFile2, FileMode.Open);

            //Declaring variable used in the do loop below
            int file1byte;
            int file2byte;

            Console.WriteLine("-------- File 1 contents --------" + "\n" + "" + "\n" + fileContents1 + "\n" + "" + "\n" + "-------- File 2 contents --------" + "\n" + "" + "\n" + fileContents2);

            ////Checks to see if the content is the same, if they are then a message is displayed
            if (fileContents1 == fileContents2)
            {
                Console.WriteLine("" + "\n" + "" + "-------- The Files are the same! --------");
            }
            else
            {
                //If not the same the do loop iterates through each file byte by byte until a exception is found 
                do
                {
                    //Read one byte from each file.
                    file1byte = rtreadFile.ReadByte();
                    file2byte = rtreadFile2.ReadByte();
                }
                while ((file1byte == file2byte) && (file1byte != -1));

                Console.WriteLine("" + "\n" + "" + "-------- The Files are not the same! --------");

                //Prints the byte diff position to console
                Console.WriteLine("Byte diff position 1 - " + "[ " + file1byte + " ]");
                Console.WriteLine("Byte diff position 2 - " + "[ " + file2byte + " ]");

                //Creates a text file at a given directory (entry 6 in the array) that will detail the text files that were compared and the first byte differance between them
                using StreamWriter stream = new StreamWriter(fileDir[6]);
                stream.Write("File 1 = " + userFile + " " + "Byte diff position " + "[ " + file1byte + " ]" + "   ");
                stream.Write("File 2 = " + userFile2 + " " + "Byte diff position " + "[ " + file2byte + " ]");
                stream.Close();

                // Close the text files.
                rtreadFile.Close();
                rtreadFile2.Close();

            }
        }
    }
}
