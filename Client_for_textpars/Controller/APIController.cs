using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_for_textpars.Controller
{
    class APIController
    {
        const string uri = "https://localhost:44356/database";

        public async Task<string> APIGetText()
        {
            using (HttpClient client = new HttpClient())
            {
                string arrMsg = null;
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode) arrMsg = await response.Content.ReadAsAsync<string>();


                return arrMsg;
            }
        }
    }
}
