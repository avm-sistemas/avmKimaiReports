using avmKimaiSoapReports.KimaiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace avmKimaiReports
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = string.Empty;

            var client = new Kimai_Remote_ApiService();
            client.Url = "https://demo.kimai.org/core/soap.php";

            var apiToken = client.authenticate("admin", "changeme").ToList();
            var elements = apiToken.Where(x => x.GetType().ToString().Equals("System.Xml.XmlElement")).ToList();
            
            foreach (var item in elements)
            {
                if (item.GetType().ToString() == "System.Xml.XmlElement")
                {
                    var elemento = (System.Xml.XmlElement)item;
                    if (elemento.InnerText.Contains("itemsapiKey"))
                    {
                        apiKey = elemento.InnerText.Replace("itemsapiKey", "").ToString();
                        break;
                    }                    
                }
            }            

            var projects = client.getProjects(apiKey,null).ToList();
            var active = client.getActiveRecording(apiKey);
            var customers = client.getCustomers(apiKey);
            int projectId = 1;
            var tasks = client.getTasks(apiKey, projectId);
            var users = client.getUsers(apiKey);            
        }
    }
}
