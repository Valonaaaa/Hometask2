using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input:");
        string input = Console.ReadLine();
        string[] separator = new String[] { ", ", " - ", " ","."};
        string[] words = input.Split(separator,StringSplitOptions.None);


        foreach (string word in words) 
        {
            string reverse = "";
            if (word == "") continue; 
            for (int index = 0; index < word.Length; index++)
            {
                char currentSym = word[index];
                reverse = currentSym + reverse;
            }
     
            

            bool isPalindrome = word.ToLower() == reverse.ToLower();
            string isPalindromeDecision = isPalindrome ?"palindrome": "not palindrome";
            Console.WriteLine(word + " - " + isPalindromeDecision);
        }
        Console.ReadKey();
    }
}
