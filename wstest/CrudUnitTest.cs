using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using webservice.Controllers;
using webservice.Model;

namespace wstest
{
    [TestClass]
    public class CrudUnitTest
    {
        [TestMethod]
        public async Task TestPost()
        {
            // Arrange
            Meassurement m = new Meassurement(0, "300", "30", "23", DateTime.Now.ToString("dd, MM, yy"));
            string uri = "https://easj-mock3.azurewebsites.net/api/Meassurement/";
            List<Meassurement> ml = new List<Meassurement>();

            // Action
            using (HttpClient client = new HttpClient())
            {
                var jsonStr = JsonConvert.SerializeObject(m);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);
                await response.Content.ReadAsStringAsync();
            }

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri);
                ml = JsonConvert.DeserializeObject<List<Meassurement>>(content);
            }

            // Assert
            Assert.AreEqual(m.ToString(), ml.Last().ToString());
        }

        [TestMethod]
        public async Task TestGet()
        {
            // Arrange
            string uri = "https://easj-mock3.azurewebsites.net/api/Meassurement/";
            List<Meassurement> ml = null;

            // Action
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri);
                ml = JsonConvert.DeserializeObject<List<Meassurement>>(content);
            }
            // Assert
            Assert.IsNotNull(ml);
        }

        [TestMethod]
        public async Task TestGetOne()
        {
            // Arrange
            string uri = "https://easj-mock3.azurewebsites.net/api/Meassurement/";
            var id = 1;
            Meassurement ml = null;

            // Action
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + id);
                ml = JsonConvert.DeserializeObject<Meassurement>(content);
            }
            // Assert
            Assert.AreEqual(id, ml.Id);
        }

        [TestMethod]
        public async Task TestDeleteLast()
        {
            // Arrange
            string uri = "https://easj-mock3.azurewebsites.net/api/Meassurement/";
            var id = 0;
            HttpResponseMessage status = null;

            using (HttpClient client = new HttpClient())
            {
                List<Meassurement> allM = null;
                string content = await client.GetStringAsync(uri);
                allM = JsonConvert.DeserializeObject<List<Meassurement>>(content);
                id = allM.Last().Id;
            }

            // Action
            using (HttpClient client = new HttpClient())
            {
                status = await client.DeleteAsync(uri + id);
            }
            // Assert
            Assert.IsTrue(status.IsSuccessStatusCode);
        }
    }
}
