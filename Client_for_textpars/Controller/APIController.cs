using Client_for_textpars.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_for_textpars.Controller
{
    class APIController
    {
        const string uri = "http://tmgwebtest.azurewebsites.net/api/textstrings/";

        private async Task<string> APIGetText(int textID)
        {
            using (HttpClient client = new HttpClient())
            {
                TextModel text = null;

                HttpRequestMessage request = new HttpRequestMessage { Method = HttpMethod.Get };
                request.Headers.Add("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
                request.RequestUri = new Uri(uri + textID);

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode) text = await response.Content.ReadAsAsync<TextModel>();
                else
                {
                    MessageBox.Show("Error : " + (int)response.StatusCode + " ReasonPhrase : " + response.ReasonPhrase);
                }

               return text?.text;
            }
        }

        public async Task<List<string>> getTextListFromServerAsync (List<int> textIdList)
        {
            List<string> textList = new List<string>();
            foreach (var x in textIdList)
            {
                string text = await APIGetText(x);
                if (text != null) textList.Add(text);
            }

            return textList;
        } 
    }
}
