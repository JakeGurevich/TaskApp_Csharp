using System;

namespace ConsoleDrow
{
    class Program
    {
        static void Main(string[] args)
        {
            
           // char c = '$';
            try
            {
                // DrawSqure(40, 20, c);
                //DrawMultBoard();
                //  DrawPrimeNums();
                DrawSqure(20, 10, "#");
                DrawRomb(10, 10,"#");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        //public static void DrawSqureOldWay(int width , int height,char ch)
        //{
        //    if (width < 0)
        //    {
        //        throw new Exception("Width has to be positive");
        //    }
        //    if (height < 0)
        //    {
        //        throw new Exception("Height has to be positive");
        //    }
        //    string str = new string(ch, width);
        //    string str2 = "";
        //    for (var i = 1; i < width - 1; i++)
        //    {
        //        str2 +=ch+" ";

        //    }
        //    string emtyStr = new string(' ', width-3);
        //    Console.WriteLine($"{str2}");
        //    for (var i=1;i < height-1; i++)
        //    {
        //        Console.WriteLine($"{ch}{emtyStr}{emtyStr}{ch}");
              
        //    }
        //    Console.WriteLine(str2);
        //    Console.WriteLine($"Width: {width} , Height: {height}");
        //}
        public static void DrawSqure(int width, int height,string strn)
        {
            if (width < 0)
            {
                throw new Exception("Width has to be positive");
            }
            if (height < 0)
            {
                throw new Exception("Height has to be positive");
            }
            var str = strn;
           
            for (int i = 1; i <= height; i++)
            {
              
                for (int j = 0; j< width; j++)
                {
                    if ( (i>1&&j>0)&&(i<height&&j<width-1))
                    {
                        str = " ";
                    } else
                    {
                        str = strn;
                    }
                    Console.Write($" {str}");
                }
                
                Console.WriteLine();
            }
        }
        public static void DrawRomb(int width,int height,string strn)
        {
            if (width < 0)
            {
                throw new Exception("Width has to be positive");
            }
            if (height < 0)
            {
                throw new Exception("Height has to be positive");
            }
            var str = strn;
            var center = width / 2;
            var left = center;
            var right = center;
            for (int i = 1; i <= height; i++)
            {
               
                for (int j = 0; j <= width; j++)
                {
                    if ((i==1||i==height) && j==center)
                    {
                        str = strn;
                    }
                    else if(left==j || right==j )
                    {  
                        str = strn;
                    }
                    else
                    {
                        str = " ";
                    }
                  
                    Console.Write($"{str}");
                }
                if (i <= height / 2)
                {
                    left -= 1;
                    right += 1;
                }
                else
                {
                    left += 1;
                    right -= 1;
                }
             
                Console.WriteLine();
            }
        }
        public static void DrawMultBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                if (i == 1) {
                    Console.Write("  "); 
                }else
                {
                    Console.Write($"0{i}");
                }

                for (int j = 2; j < 10; j++)
                {
                    if (i == 0)
                    {
                        Console.Write($" 0{j}");
                    }
                    else
                    {
                        var num = i * j;
                        if (num < 10)
                        {
                            Console.Write($" 0{num}");
                        }else
                        {
                            Console.Write($" {i * j}");
                        }
                       
                    }
                }
                Console.WriteLine("");
            }
        }
        public static void DrawPrimeNums()
        {
            var count = 0;
            var countPrime = 0;
            var prime = true;
            for (int i = 2; i <= 100; i++)
            {
                var num = 1;
                
                
                for (int j = 2; j <= i/2; j+=num)
                {
                   
                    count++;
                    if (j ==10)
                    {
                        num = 10;
                    }
                    
                    if (i % j == 0)
                    {
                       
                        
                        prime = false;
                        break;

                    }
                    else
                    {
                        
                        prime = true;
                    }
                    
       }
                if (prime)
                {
                    Console.Write($" {i}");
                   
                    countPrime++;
                }
                
               

               
                
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Total iterations :{count}");
            Console.WriteLine($"Prime numbers :{countPrime}");
        }
    }
}
