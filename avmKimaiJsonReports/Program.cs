using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace avmKimaiJsonReports
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static async Task<object> Reports()
        {
            HttpClient client = new HttpClient();

            string user = "";
            string pass = "";

            string jsonString = "{\"method\":\"authenticate\", \"jsonrpc\":\"2.0\",\"id\":\"1\",\"params\":[\"{0}\",\"{1}\"]}";
            jsonString = string.Format(jsonString, user, pass);

            string url = "http://example.com/core/json.php";

            StringContent sc = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, sc);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
