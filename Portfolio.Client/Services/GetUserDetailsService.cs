using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;
using System;
using static Portfolio.Client.Models.ControllersModels;

namespace Portfolio.Client.Services
{
    public class GetUserDetailsService
    {
       
        public async Task<AllUserDetails> GetUserDetails(string url)
        {
           
            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync($"{url}Get/GetUserDetails");
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Check if the response was successful
                    if (response.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject<AllUserDetails>(responseContent);
                        return data;
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString() +": "+ responseContent);
                    }

                }
                catch 
                {
                    throw;
                }
                
            }
        }

    }
}
