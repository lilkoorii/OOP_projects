using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------   Task 1   ----------------");

            Task Eratos = new Task(() => ErSieve(300));                           // Создаем новый Task
            Console.WriteLine($"Task ID:              {Eratos.Id}");             
            Console.WriteLine($"Status when created:  {Eratos.Status}");          
            Eratos.Start();                                                       
            Console.WriteLine($"Status when started:  {Eratos.Status}\n");        
            Eratos.Wait();                                                        // Ждём пока выполн. Task Eratos
            Console.WriteLine($"Status when ended:    {Eratos.Status}");         

            Console.WriteLine("----------------    Task 2   ----------------");

            Task Eratos2 = new Task(() => EratosSieve2(400));                         
            Console.WriteLine($"Task #{Eratos2.Id} status:{Eratos2.Status}");
            Eratos2.Start();

            Console.WriteLine("Enter 0 to stop the process:\n");                        // Зав. таск при введении 0
            string s = Console.ReadLine();                                              
            if (s == "0")                                                                 
                tokenSource.Cancel();                                                   
            Console.WriteLine($"Task #{Eratos2.Id} status:       Completed");

            Console.WriteLine("----------------   Task 3   ----------------");
            Task<int> task3_1 = new Task<int>(() =>               // формулы
            {
                int x = 2;
                for (int i = 1; i < 7; i++)
                    x *= i;
                Console.WriteLine($"Result #1:            {x}");
                return x;
            });
            Task<int> task3_2 = new Task<int>(() =>
            {
                int x = 1;
                for (int i = 1; i < 4; i++)
                {
                    x++;
                    x *= x;
                }
                Console.WriteLine($"Result #2:            {x}");
                return x;
            });
            Task<int> task3_3 = new Task<int>(() =>
            {
                int z = -300;
                for (int i = 0; i < 54; i++)
                    z += i;
                Console.WriteLine($"Result #3:            {z}");
                return z;
            });
            Task[] tasks = { task3_1, task3_2, task3_3 };
            foreach (Task task in tasks)
                task.Start();               // Запускаем все задачи
            Task.WaitAll(tasks);            
            Console.WriteLine("Sum of all results:" + (task3_1.Result + task3_2.Result + task3_3.Result));

            Console.WriteLine("----------------   Task 4   ----------------");
            Task<int> task1 = new Task<int>(() => Sum(42, 53));             // ContinueWith
            Task task2 = task1.ContinueWith(sum => Display(sum.Result));    // Вторая задача запускается после завершения первой
            task1.Start();                                                  
            task2.Wait();                                                   

            // методы GetAwaiter и GetResult предназначены для использ. компилятором а не в коде, не работают :(

            // Task<int> task = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            // Получ. объект продолжения 
            // var awaiter = task.GetAwaiter();
            // awaiter.OnCompleted(() => 
            // {
            // Получ. результат вычислений предшественника 
            //    int res = awaiter.GetResult();
            //    Console.WriteLine(res);
            // });

            Console.WriteLine("----------------   Task 5   ----------------");
            List<long> list = new List<long>() { 10, 8, 7, 15 };              

            Console.WriteLine("Parallel cycle:\n");
            ParallelLoopResult result = Parallel.ForEach<long>(list, Factorial);// Параллельный foreach

            Console.WriteLine("\nDefault cycle:\n");                            // Обычный foreach
            foreach (long l in list)                                           
            {                                                                   
                long result1 = 1;                                              
                for (int i = 1; i <= l; i++)
                    result1 *= i;
                Console.WriteLine($"Factorial of {l} is {result1}.");
            }

            Console.WriteLine("----------------   Task 6   ----------------");
            Console.WriteLine("Using Invoke():");                               // Через Invoke() выз. методы, выводится тот кто вып. быстрее
            Parallel.Invoke(Display,                                           
            () =>
            {                                                            
                Console.WriteLine($"Completing Task #{Task.CurrentId}");
            },
            () => Factorial(5));




            Console.WriteLine("----------------   Task 8   ----------------");
            FactorialAsync();                               // Асинхронный факториал
            Console.WriteLine("Main is still running.");
            Console.ReadKey();                             




            //  TASK 7
            BlockingCollection<string> bc = new BlockingCollection<string>(5);                      
            CancellationTokenSource ts = new CancellationTokenSource();                            
            CancellationToken token7 = ts.Token;                                                   

            Task[] sellers = new Task[10]
            {
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Шампиньон"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Цапля"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Кулебяка"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Щавель"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Микроволновка"); } }),

                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Вантуз"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Трамвайная ручка"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Спиннинг"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Подстаканник"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Пульверизатор"); } }),
            };

            Task[] consumers = new Task[5]
            {
                new Task(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(250);   bc.Take(); } })
            };

            foreach (var item in sellers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            foreach (var item in consumers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            int count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("Press 0 to cancel");
                    Console.WriteLine("----------------   Task 7   ----------------");
                    Console.WriteLine("--------------- Склад ---------------");

                    foreach (var item in bc)
                    {
                        Console.WriteLine(item);
                    }
                    string s1 = Console.ReadLine();
                    if (s1 == "0")
                        ts.Cancel();
                    if (token7.IsCancellationRequested)
                    {
                        Console.WriteLine("\nProcess stopped.");
                        return;
                    }
                    Console.WriteLine("-------------------------------------");
                    
                }

            }
        }
        // Исп. в Эратосфене (ниже)
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Factorial equals {result}");
        }
        public static async void FactorialAsync()  // await и async
        {
            Console.WriteLine("Start of FactorialAsync");
            await Task.Run(() => Factorial());
            Console.WriteLine("End of FactorialAsync");
        }
        static void Display()
        {
            Console.WriteLine($"Display: Running Task #{Task.CurrentId}");
        }
        public static void Factorial(long x)
        {
            long result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Completing Task #{Task.CurrentId}...");
            Console.WriteLine($"Factorial of {x} is {result}.");
        }
        public static int Sum(int a, int b)
        {
            Console.WriteLine($"Input A:              {a}\nInput B:              {b}");
            return (a + b);
        }
        public static void Display(int sum)
        {
            Console.WriteLine($"Sum of A+B:           {sum}");
        }
        public static void ErSieve(int n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
            }
            Console.WriteLine($"All simple numbers from 1 to {n}:");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Thread.Sleep(1);
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

            stopWatch.Stop();                                                     // ост. StopWatch
            TimeSpan ts = stopWatch.Elapsed;                                       
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",     
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("\nTotal runtime:        " + elapsedTime);
        }
        public static void EratosSieve2(int n)
        {
            CancellationToken tokenForEr = tokenSource.Token;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                Console.WriteLine($"Running task #{Task.CurrentId}...");
                System.Threading.Thread.Sleep(3000);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;

                if (tokenSource.Token.IsCancellationRequested)
                    return;

                if (tokenForEr.IsCancellationRequested)                         
                {                                                               
                    Console.WriteLine("\nThe process was stopped.");            
                    break;
                    return;
                }
            }
            Console.WriteLine($"All simple numbers from 1 to {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
            stopWatch.Stop();                                                     // останавливаем StopWatch 
            TimeSpan ts = stopWatch.Elapsed;                                      
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",    
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("\nTotal runtime:        " + elapsedTime);
        }

    }
}