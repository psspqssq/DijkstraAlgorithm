using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net.Http;
using CityApp.Class;
using Newtonsoft.Json;

namespace CityApp
{
    internal class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static SerialPort port = new SerialPort("COM3", 9600);
        static int routesCount = 0;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();
            _quitEvent.WaitOne();

        }
        static private async void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadLine();
            string command = data.Split('|')[0];
            Console.WriteLine($"Received: {data}");
            switch (command)
            {
                case "CYCLE":
                    using (HttpClient httpClient = new HttpClient())
                    {
                        try
                        {
                            string commandValue = data.Split('|')[1];
                            // Specify the URL for the POST request
                            string apiUrl = "https://localhost:7166/cycleitems";

                            // Create JSON data to be sent in the request body
                            string jsonData = $"{{ \"name\": \"Día {commandValue.Trim()}\", " +
                                $"\"isComplete\": true, " +
                                $"\"routesCount\": {routesCount}, " +
                                $"\"date\": {Newtonsoft.Json.JsonConvert.SerializeObject(DateTime.Now)} }}";

                            // Create a StringContent object with the JSON data and set the content type
                            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                            // Make a POST request with the JSON data
                            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                // Read and print the content of the response
                                string responseContent = await response.Content.ReadAsStringAsync();
                                Console.WriteLine("Response content: " + responseContent);
                                routesCount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                    break;
                case "TRAVEL":
                    using (HttpClient httpClient = new HttpClient())
                    {
                        try
                        {
                            string startNode = data.Split('|')[1];
                            string endNode = data.Split('|')[2];
                            // Specify the URL for the POST request
                            string apiUrl = $"https://localhost:7166/dijkstra/{startNode}/{endNode}";

                            // Make a POST request with the JSON data
                            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                // Read and print the content of the response
                                IEnumerable<CityRoute> routes = JsonConvert.DeserializeObject<IEnumerable<CityRoute>>(await response.Content.ReadAsStringAsync());
                                List<int> turnonleds = new List<int>();
                                foreach(CityRoute route in routes)
                                {
                                    routesCount++;
                                    Console.WriteLine($"Route {route.From} to {route.To}");
                                    if (route.From == "1" && route.To == "2") turnonleds = turnonleds.Append(0).Append(1).Append(2).ToList();
                                    if (route.From == "2" && route.To == "1") turnonleds = turnonleds.Append(2).Append(1).Append(0).ToList();

                                    if (route.From == "1" && route.To == "4") turnonleds = turnonleds.Append(3).Append(4).Append(5).ToList();
                                    if (route.From == "4" && route.To == "1") turnonleds = turnonleds.Append(5).Append(4).Append(3).ToList();

                                    if (route.From == "2" && route.To == "3") turnonleds = turnonleds.Append(6).Append(7).Append(8).ToList();
                                    if (route.From == "3" && route.To == "2") turnonleds = turnonleds.Append(8).Append(7).Append(6).ToList();

                                    if (route.From == "2" && route.To == "5") turnonleds = turnonleds.Append(9).Append(10).Append(11).ToList();
                                    if (route.From == "5" && route.To == "2") turnonleds = turnonleds.Append(11).Append(10).Append(9).ToList();

                                    if (route.From == "3" && route.To == "6") turnonleds = turnonleds.Append(12).Append(13).Append(14).ToList();
                                    if (route.From == "6" && route.To == "3") turnonleds = turnonleds.Append(14).Append(13).Append(12).ToList();

                                    if (route.From == "4" && route.To == "5") turnonleds = turnonleds.Append(15).Append(16).Append(17).ToList();
                                    if (route.From == "5" && route.To == "4") turnonleds = turnonleds.Append(17).Append(16).Append(15).ToList();

                                    if (route.From == "4" && route.To == "7") turnonleds = turnonleds.Append(18).Append(19).Append(20).ToList();
                                    if (route.From == "7" && route.To == "4") turnonleds = turnonleds.Append(20).Append(19).Append(18).ToList();

                                    if (route.From == "5" && route.To == "6") turnonleds = turnonleds.Append(21).Append(22).Append(23).ToList();
                                    if (route.From == "6" && route.To == "5") turnonleds = turnonleds.Append(23).Append(22).Append(21).ToList();

                                    if (route.From == "5" && route.To == "7") turnonleds = turnonleds.Append(26).Append(25).Append(24).ToList();
                                    if (route.From == "7" && route.To == "5") turnonleds = turnonleds.Append(24).Append(25).Append(26).ToList();

                                    if (route.From == "6" && route.To == "8") turnonleds = turnonleds.Append(30).Append(31).ToList();
                                    if (route.From == "8" && route.To == "6") turnonleds = turnonleds.Append(31).Append(30).ToList();

                                    if (route.From == "7" && route.To == "8") turnonleds = turnonleds.Append(27).Append(28).Append(29).ToList();
                                    if (route.From == "8" && route.To == "7") turnonleds = turnonleds.Append(29).Append(28).Append(27).ToList();
                                }
                                foreach(int led in turnonleds)
                                {
                                    Console.WriteLine($"Writing high to led {led}");
                                    port.Write($"{led},");
                                }
                                Console.WriteLine($"Ending led string writing");
                                port.Write("endleds");
                            }
                            else
                            {
                                Console.WriteLine("Request failed with status code: " + response.StatusCode);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
