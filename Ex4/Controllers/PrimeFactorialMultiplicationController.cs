using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex4.Controllers
{
    public class PrimeFactorialMultiplicationController : Controller
    {
        // GET: PrimeFactorialMultiplication
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PrimeNumbers()
        {
            var primes = GetPrimes(1, 100);
            return View(primes);
        }

        // GET: Math/Factorials
        public ActionResult Factorials()
        {
            var factorials = GetFactorials(1, 10);
            return View(factorials);
        }

        // GET: Math/MultiplicationTable
        public ActionResult MultiplicationTable()
        {
            var table = GetMultiplicationTable(2, 9);
            return View(table);
        }

        private List<int> GetPrimes(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private List<long> GetFactorials(int start, int end)
        {
            List<long> factorials = new List<long>();
            for (int i = start; i <= end; i++)
            {
                factorials.Add(Factorial(i));
            }
            return factorials;
        }

        private long Factorial(int number)
        {
            if (number <= 1) return 1;
            return number * Factorial(number - 1);
        }

        private Dictionary<int, Dictionary<int, int>> GetMultiplicationTable(int start, int end)
        {
            var table = new Dictionary<int, Dictionary<int, int>>();
            for (int i = start; i <= end; i++)
            {
                table[i] = new Dictionary<int, int>();
                for (int j = 1; j <= 10; j++)
                {
                    table[i][j] = i * j;
                }
            }
            return table;
        }
    }
}