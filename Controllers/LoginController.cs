using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Program.Models;

namespace Program.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_In(IFormCollection form)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4000/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                LoginRequest lr = new LoginRequest(){Email = form["Email"].ToString(),Password = form["Password"].ToString(),Device = "LAPTOP-2T731P5F"};
                
                var login = client.PostAsJsonAsync("api/Users/SignIn",lr);
                login.Wait();
                
                var loginResult = login.Result;
                if(loginResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Sign_Up(IFormCollection form)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4000/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                SignUpRequest sr = new SignUpRequest(){
                    Name = form["Name"].ToString(),
                    Email = form["Email"].ToString(),
                    Password = form["Password"].ToString(),
                    Gender = true,
                    Address = "Quang Nam,Viet Nam",
                    Hobbies = "Drink :>",
                    Device = "Chuong's LAPTOP",
                };
                var signUp = client.PostAsJsonAsync("api/Users/SignUp",sr);
                signUp.Wait();
                
                var signUpResult = signUp.Result;
                if(signUpResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Privacy","Home");
                }
            }
            return RedirectToAction("Login");
        }
    }
    // class Product
    // {
    //     public string Name { get; set; }
    //     public double Price { get; set; }
    //     public string Category { get; set; }
    // }
    // class Program
    // {
    //     static void Main()
    //     {
    //         RunAsync().Wait();
    //     }

    //     static async Task RunAsync()
    //     {
    //         using (var client = new HttpClient())
    //         {
    //             client.BaseAddress = new Uri("http://localhost:9000/");
    //             client.DefaultRequestHeaders.Accept.Clear();
    //             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //             // HTTP GET
    //             HttpResponseMessage response = await client.GetAsync("api/products/1");
    //             if (response.IsSuccessStatusCode)
    //             {
    //                 Product product = await response.Content.ReadAsAsync<Product>();
    //                 Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
    //             }

    //             // HTTP POST
    //             var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
    //             response = await client.PostAsJsonAsync("api/products", gizmo);
    //             if (response.IsSuccessStatusCode)
    //             {
    //                 Uri gizmoUrl = response.Headers.Location;

    //                 // HTTP PUT
    //                 gizmo.Price = 80;   // Update price
    //                 response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

    //                 // HTTP DELETE
    //                 response = await client.DeleteAsync(gizmoUrl);
    //             }
    //         }
    //     }
    // }
}