using Newtonsoft.Json;
using ParceriasParaVoce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ParceriasParaVoce.Controllers
{
    public class HomeController : Controller
    {
        Uri _uri = null;

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IList<Parceria>> RetornaLista()
        {
            IList<Parceria> parcerias;
            _uri = new Uri("https://localhost:44332/api/parceria/RetornaLista");
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(_uri))
                    {
                        var ParceriasJsonString = await response.Content.ReadAsStringAsync();
                        ParceriasJsonString = ParceriasJsonString.Replace($@"\","");
                        ParceriasJsonString = ParceriasJsonString.Replace($@"\", "");
                        var t = JsonConvert.DeserializeObject<IList<Parceria>>(ParceriasJsonString);
                        parcerias = t;
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }
           
            return parcerias; 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}