using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PatientSeeder
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Family { get; set; }
        public string[] Given { get; set; }
        public string Use { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }

        public string ToString() => $"{Family} {Given[0]} {Given[1]} {BirthDate.ToShortDateString()} {Gender}";
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start adding 100 patients.");
            /*https://localhost:32773/swagger/index.html*/
            var base_url = "https://localhost:32792/api/";
            var client = new HttpClient { BaseAddress = new Uri(base_url) };
            client.Timeout = TimeSpan.FromSeconds(1000);
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var p = new Patient
                {
                    Id = Guid.NewGuid(),
                    Family = $"Иванов_{i}",
                    Given = new[] { $"Иван_{i}", $"Иванович_{i}" },
                    Use = "official",
                    BirthDate = DateTime.Now.AddDays(-i),

                    Gender = rnd.Next(100) > 60 ? "male" : 
                    rnd.Next() > 20 ? "female" :
                    rnd.Next() > 10 ? "other" :
                    "unknown",

                    Active = rnd.Next(100) > 50 ? true : false
                };

                var response = await client.PostAsJsonAsync("patients", p);
                try
                {
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine($"Patient {p.Family} {p.Given[0]} {p.Given[1]} added.");
                    Console.WriteLine($"Patient {p.ToString()} added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR {ex}");
                }
            }

            Console.WriteLine("100 patients added succesfully.");

            Console.ReadLine();
        }
    }
}