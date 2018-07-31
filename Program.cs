using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sample = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 0, 1, 7, 3, 6, 4, 10, 0, 2, 8, 6 };
            
            //int[] sample = {                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 0,                 10, 10, 10 };
            //int[] sample = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int score = FuncBowling(sample); //Should be equal to 133

            Console.WriteLine(score);
        }

        static int FuncBowling(int[] throws)
        {
        
            string lastThrow = "none";
            //bool lastFrameBonus = false;

            int bonus = 1;

            int frame = 1;
            int score = 0;

            for (var i = 0; i < 20; i += 2)
            {
                //add score dep on multiplier
                if (lastThrow == "strike")
                {
                    if (throws[i] == 10 && frame != 10)
                    {
                        bonus = 3;
                    }
                    else
                    {
                        bonus = 2;
                    }
                    score += (throws[i] + throws[i + 1]) * bonus;
                }
                else if (lastThrow == "spare")
                {
                    score += throws[i] * 2;
                    score += throws[i + 1];
                }
                else
                {
                    score += throws[i] + throws[i + 1];
                }


                //determine strike/spare
                if (throws[i] == 10)
                {
                    //STRIKE
                    lastThrow = "strike";
                }
                else if (throws[i] + throws[i + 1] == 10)
                {
                    //SPARE
                    lastThrow = "spare";
                }
                else
                {
                    lastThrow = "none";
                }
   
                //extra throws for final frame
                if(frame == 10)
                {
                    Console.WriteLine("Final Frame");
                    if(lastThrow == "spare")
                    {
                        Console.WriteLine("Final spare!");
                        score += throws[i + 2];
                    }
                    else if(lastThrow == "strike")
                    {
                        Console.WriteLine("Final Striiiiike!");
                        score += throws[i + 2];
                    }
                }
                Console.WriteLine("Score at frame: " + frame + " is " + score);
                frame++;
            }

            return score;
        }
    }
}
