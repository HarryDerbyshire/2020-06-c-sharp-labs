using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using api_safari_entity_core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace client_safari_entity_core
{
    class Program
    {
        static List<Animal> animals = new List<Animal>();
        static List<AnimalType> animalTypes = new List<AnimalType>();
        static Animal animal = new Animal();
        static AnimalType animalType = new AnimalType();
        static Uri url = new Uri("https://localhost:44334/api");
        static void Main(string[] args)
        {
            //Thread.Sleep(5000);
            GetAllAnimals();
            //Console.WriteLine("List of all animals");
            //animals.ForEach(item => Console.WriteLine(item.AnimalName));

            //GetAnimal(2);
            //Console.WriteLine($"\nAnimal with ID 2 is: {animal.AnimalName}");

            //GetAllAnimalTypes();
            //Console.WriteLine("\nList of all animals");
            //animalTypes.ForEach(item => Console.WriteLine(item.TypeName));

            //GetAnimalType(2);
            //Console.WriteLine($"\nAnimal with ID 2 is: {animalType.TypeName}");

            //var createAnimalType = new AnimalType
            //{
            //    //TypeId = 4,
            //    TypeName = "Bird",
            //    NumberOfLegs = 2
            //};

            var createAnimal = new Animal
            {
                AnimalId = 1,
                AnimalName = "Duck",
                TypeId = 0
                
            };
            //Thread.Sleep(3000);
            //PostAnimalType(createAnimalType);
            Thread.Sleep(3000);
            UpdateAnimal(createAnimal);
            //PostAnimal(createAnimal);

            Console.ReadLine();
        
        }

        static bool AnimalExists(int animalId)
        {
            var animalObject = animals.FirstOrDefault(a => a.AnimalId == animalId);

            return !(animalObject == null);  
        }
        static bool AnimalTypeExists(int animalTypeId)
        {
            var animalTypeObject = animalTypes.FirstOrDefault(at => at.TypeId == animalTypeId);

            return !(animalTypeObject == null);
        }

        #region Read
        public static void GetAllAnimals()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync($"{url}/Animals");
                animals = JsonConvert.DeserializeObject<List<Animal>>(data.Result);
            }
        }

        public static void GetAllAnimalTypes()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync($"{url}/AnimalTypes");
                animalTypes = JsonConvert.DeserializeObject<List<AnimalType>>(data.Result);
            }

        }

        public static void GetAnimal(int animalId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync($"{url}/Animals/{animalId}");
                animal = JsonConvert.DeserializeObject<Animal>(data.Result);
            }

        }

        public static void GetAnimalType(int animalTypeId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync($"{url}/AnimalTypes/{animalTypeId}");
                animalType = JsonConvert.DeserializeObject<AnimalType>(data.Result);
            }

        }

        #endregion

        #region Create
        static async void PostAnimal(Animal newAnimal)
        {
            //if (AnimalExists(Convert.ToInt32(newAnimal.AnimalId)) == false)
            //{
                string newAnimalJson = JsonConvert.SerializeObject(newAnimal);

                var httpContent = new StringContent(newAnimalJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync($"{url}/animals", httpContent);                   
                    animals.Add(newAnimal);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("New animal added");
                    }
                }
            //}
        }

        static async void PostAnimalType(AnimalType newAnimalType)
        {
            if (AnimalTypeExists(Convert.ToInt32(newAnimalType.TypeId)) == false)
            {
                string newAnimalTypeJson = JsonConvert.SerializeObject(newAnimalType);

                var httpContent = new StringContent(newAnimalTypeJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync($"{url}/animalTypes", httpContent);                   
                    animalTypes.Add(newAnimalType);
                }
            }
        }


        #endregion

        #region Delete
        static async void DeleteAnimal(int animalId)
        {
            if(AnimalExists(animalId))
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{url}/animals/{animalId}");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {animalId} successfully deleted");
                    }
                }
            }
        }

        static async void DeleteAnimalType(int animalTypeId)
        {
            if (AnimalTypeExists(animalTypeId))
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{url}/animals/{animalTypeId}");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {animalTypeId} successfully deleted");
                    }
                }
            }
        }
        #endregion

        #region Update
        static async void UpdateAnimal (Animal animalToUpdate)
        {
            if (AnimalExists(Convert.ToInt32(animalToUpdate.AnimalId)))
            {
                string updateAnimalAsJson = JsonConvert.SerializeObject(animalToUpdate, Formatting.Indented);

                var httpContent = new StringContent(updateAnimalAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PutAsync($"{url}/animals/{animalToUpdate}", httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {animalToUpdate.AnimalId} successfully updated");
                    }
                }
            } else
            {
                Console.WriteLine($"An animal with ID {animalToUpdate.AnimalId} doesn't exist so cannot be updated");
            }
        }

        static async void UpdateAnimalType(AnimalType animalTypeToUpdate)
        {
            if (AnimalExists(Convert.ToInt32(animalTypeToUpdate.TypeId)))
            {
                string updateAnimalTypeAsJson = JsonConvert.SerializeObject(animalTypeToUpdate, Formatting.Indented);

                var httpContent = new StringContent(updateAnimalTypeAsJson);

                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PutAsync($"{url}/animals/{animalTypeToUpdate}", httpContent);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {animalTypeToUpdate.TypeId} successfully updated");
                    }
                }
            }
            else
            {
                Console.WriteLine($"An animal type with ID {animalTypeToUpdate.TypeId} doesn't exist so cannot be updated");
            }
        }
        #endregion
    }
}
