using System;
using System.Collections.Generic;
using System.Linq;

namespace Top_K_words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int numToys = 6;
            int topToys = 2;
            List <string> toys = new List<string>() { "elmo", "elsa", "legos", "drone", "tablet", "warcraft" };
            int numQuotes = 6;
            List <string> quotes = new List<string>() {"Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
            "The new Elmo dolls are super high quality",
            "Expect the Elsa dolls to be very popular this year, Elsa",
            "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
            "For parents of older kids, look into buying them a drone",
            "Warcraft is slowly rising in popularity ahead of the holiday season" };

            Solution s = new Solution();
            foreach (var v in s.popularNToys(numToys, topToys, toys, numQuotes, quotes))
                Console.WriteLine(v); 
        }
    }

    public class Solution
    {
        public List<string> popularNToys (int numtoys,int topToys,List<string> toys, int numQuotes, List<string> quotes)
        {
          
            Dictionary<string, int> dic = new Dictionary<string, int>();
           
            foreach(var t in toys)
            {
                dic.Add(t, 0);
            }


            for (int i=0; i< quotes.Count; i++)
            {
                quotes[i] = quotes[i].ToLower();
                string[] words = quotes[i].Split(' ');
                foreach(var w in words)
                    if (dic.ContainsKey(w))
                        dic[w] = dic[w] + 1;
           
            }
         
            return dic.OrderByDescending(x => x.Value).Select(x => x.Key).Take(topToys).ToList(); ; 

        }
    }
}
