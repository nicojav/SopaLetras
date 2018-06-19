using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SopaLetrasDataAccess;
using SopaLetrasApp;

namespace SopaLetrasWebApi.Controllers
{
    public class BusquedaController : ApiController
    {
       private IAppManager app = new AppManager();

       public IEnumerable<Busqueda> Get()
       {
           using(SopaLetrasEntities entities = new SopaLetrasEntities())
           {
               return entities.Busqueda.ToList();
           }

       }

       public HttpResponseMessage Post([FromBody] Busqueda request)
       {
           try
           {
               using (SopaLetrasEntities entities = new SopaLetrasEntities())
               {
                   entities.Busqueda.Add(new Busqueda { busqueda_palabra = request.busqueda_palabra, busqueda_coordenadas = request.busqueda_coordenadas });
                   entities.SaveChanges();

                   var message = Request.CreateResponse(HttpStatusCode.Created, request.busqueda_palabra);
                   message.Headers.Location = new Uri(Request.RequestUri + request.busqueda_palabra);
                   return message;
               }

           }
           catch (Exception ex)
           {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
           }

       }

       public IHttpActionResult GetPosiciones(string palabra)
       {
           using (SopaLetrasEntities entities = new SopaLetrasEntities())
           {
               var posiciones = app.getPosiciones(palabra);

               Post(new Busqueda { busqueda_palabra = palabra, busqueda_coordenadas = posiciones });
               
               return Ok(new {results = posiciones});
           }

       }

    }
}
