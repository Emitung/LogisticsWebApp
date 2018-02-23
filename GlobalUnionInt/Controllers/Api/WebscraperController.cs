using GlobalUnionInt.Services.interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GlobalUnionInt.Controllers.Api
{
    [RoutePrefix("api/webscrapers")]
    public class WebscraperController : ApiController
    {
        IWebscraper _webscraper;

        public WebscraperController(IWebscraper webscraper)
        {
            _webscraper = webscraper;
        }

        [Route("1/{trackingNum:int}"), HttpGet]
        public HttpResponseMessage NCA1(int trackingNum)
        {
            try
            {
                string AWBNum = trackingNum.ToString();
                string url = ("https://www.nca.aero/icoportal/jsp/operations/shipment/AWBTracking.jsf?prefix1=933&doc1=" + AWBNum + "&prefix2=933&doc2=&prefix3=933&doc3=&prefix4=933&doc4=");
                List<string> response = _webscraper.NCA1(url);
                //string response = _webscraper.NCA(url);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("2/{trackingNum:int}"), HttpGet]
        public HttpResponseMessage NCA2(int trackingNum)
        {
            try
            {
                string AWBNum = trackingNum.ToString();
                string url = ("https://www.nca.aero/icoportal/jsp/operations/shipment/AWBTracking.jsf?prefix1=933&doc1=" + AWBNum + "&prefix2=933&doc2=&prefix3=933&doc3=&prefix4=933&doc4=");
                List<string> response = _webscraper.NCA2(url);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
