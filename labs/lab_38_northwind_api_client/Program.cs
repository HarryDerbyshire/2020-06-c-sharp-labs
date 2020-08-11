using lab_38_northwind_api_client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace lab_38_northwind_api_client
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer customer = new Customer();
        static Uri url = new Uri("https://localhost:44390/api/Customers");
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            
            GetAllCustomersAsync();
            GetCustomerAsync("BOTTM");

            Thread.Sleep(3000);

            // Output
            //customers.ForEach(item => Console.WriteLine(item.ContactName));
            Console.WriteLine($"\n\nMy name is: {customer.ContactName}");

            // Post a customer
            
            

            var newCustomer = new Customer()
            {
                CustomerId = RandomString(),
                ContactName = "HarryButWrongAgain",
                CompanyName = "My Company",
                City = "London",
                Country = "England"
            };

            PostCustomerAsync(newCustomer);
            // Update

            // Delete
            //DeleteCustomer(newCustomer.CustomerId);
            Thread.Sleep(3000);
            //DeleteCustomerAsync(newCustomer.CustomerId);
            DeleteCustomerWithReturnAsync(newCustomer.CustomerId).Wait();

            //var response = await DeleteCustomerWithReturnAsync(newCustomer.CustomerId);
            //if (response.IsSuccessStatusCode) Console.WriteLine($"Record successfully deleted for and awaited for");
           
            //Thread.Sleep(10000);            
            GetAllCustomersAsync();
            customers.ForEach(item => Console.WriteLine($"{item.CustomerId}: {item.ContactName}"));
            
            Console.ReadLine();
        }

       
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region Read
        static async void GetAllCustomersAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);  
              
            }
        }

        static async void GetCustomerAsync(string customerId)
        {          
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{url}/{customerId}");
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
        }

        static bool CustomerExists(string customerId)
        {
            
            var customerExists = customers.FirstOrDefault(c => c.CustomerId == customerId);

             if (customerExists == null)
            {
                return false;
            } else
            {
               
                return true;
            };

        }
        #endregion

        #region Create
        static async void PostCustomerAsync(Customer newCustomer)
        {
            // Check customer doesn't exist
           

            if (CustomerExists(newCustomer.CustomerId) == false)
            {
                // Firstly serialise customer to JSON
                string newCustomerJson = JsonConvert.SerializeObject(newCustomer);

                // Convert to HTTP
                var httpContent = new StringContent(newCustomerJson);

                // Add headers before send
                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                // Send data
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync(url, httpContent);
                    Console.WriteLine(httpResponse.IsSuccessStatusCode);
                    customers.Add(newCustomer);
                }
            }
        }
        #endregion

        #region Delete
        static void DeleteCustomer(string customerId)
        {
            if (CustomerExists(customerId) == true){ 
                
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.DeleteAsync($"{url}/{customerId}");
                    if (response.Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {customerId} successfully deleted");
                    }
                }
            } else
            {
                Console.WriteLine($"Cannot delete customer with ID: {customerId} as it does not exist");
            }
        }

        static async void DeleteCustomerAsync(string customerId)
        {
            if (CustomerExists(customerId) == true)
            {

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{url}/{customerId}");
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {customerId} successfully deleted");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Cannot delete customer with ID: {customerId} as it does not exist");
            }
        }

        static async Task<HttpResponseMessage> DeleteCustomerWithReturnAsync(string customerId)
        {
            if (CustomerExists(customerId) == true)
            {

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{url}/{customerId}");
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {customerId} successfully deleted");
                    }
                    return response;
                }
            }
            else
            {
                Console.WriteLine($"Cannot delete customer with ID: {customerId} as it does not exist");
                return null;
            }
        }
        #endregion

        #region Update
        static async void UpdateCustomerAsync (Customer customerToUpdate)
        {
            if (CustomerExists(customerToUpdate.CustomerId))
            {
                string updateCustomerAsJson = JsonConvert.SerializeObject(customerToUpdate, Formatting.Indented);

                var httpContent = new StringContent(updateCustomerAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PutAsync($"{url}/{customerToUpdate.CustomerId}", httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {customerToUpdate.CustomerId} successfully updated");
                    }

                }
            }
            else
            {
                Console.WriteLine($"A customer with ID: {customerToUpdate.CustomerId} doesn't exist so cannot be updated");
            }
        }

        #endregion
    }
}
