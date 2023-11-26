using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataGov_API_Intro_7.Models;
using Newtonsoft.Json;
using DataGov_API_Intro_7.DataAccess;

namespace DataGov_API_Intro_7.Controllers;

public class HomeController : Controller
{
    HttpClient? httpClient;

    static string BASE_URL = "https://developer.nps.gov/api/v1";
    static string API_KEY = "mdBybOievMdeX3eYSC0MhFu3U7xRV18xHAPG04qb"; //Add your API key here inside ""

    // Obtaining the API key is easy. The same key should be usable across the entire
    // data.gov developer network, i.e. all data sources on data.gov.
    // https://www.nps.gov/subjects/developer/get-started.htm

    public ApplicationDbContext dbContext;

    public HomeController(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public async Task<IActionResult> Index()
    {
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.Timeout = TimeSpan.FromMinutes(5); // Set the timeout to 5 minutes


        string NATIONAL_PARK_API_PATH = "https://developer.nrel.gov/api/alt-fuel-stations/v1.json?api_key=hkZVQijE8ZvMpchuICzQYDI8gIyPjxVsGzt9h0oI";
        string parksData = "";

        root_object s = new root_object();
        //httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);
        httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

        try
        {
            //HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
            //                                        .GetAwaiter().GetResult();
            HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
                                                    .GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!parksData.Equals(""))
            {
                //JsonConvert is part of the NewtonSoft.Json Nuget package
                s = JsonConvert.DeserializeObject<root_object>(parksData);
            }

            foreach (Stations st in s.fuel_stations)
            {
                st.Date_Updated = DateTime.Now;
                dbContext.Fuel_Stations.Add(st);

            }
            await dbContext.SaveChangesAsync();

        }
        catch (Exception e)
        {
            // This is a useful place to insert a breakpoint and observe the error message
            Console.WriteLine(e.Message);
        }

        return View();
        //return View();
    }


}

