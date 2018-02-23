using GlobalUnionInt.Services.interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GlobalUnionInt.Services
{
    public class WebscraperService : IWebscraper
    {
        public List<string> NCA1(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//span[@id='shipmentTracking:trckingDetails:segmentInfoGrp']//table[@class='portalTableStyle']//tbody//tr[@class='portalTableDataRow1']//td").ToArray();

            List<string> items = new List<string>();


            if (nodes != null)
            {
                foreach (HtmlNode td in nodes)
                {
                    items.Add(td.InnerHtml);
                }
                return items;
            }
            else
            {
                items.Add("Nothing found.");
            }
            return items;
        }

        public List<string> NCA2(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            //HtmlNode node = doc.DocumentNode.SelectSingleNode("//span[@id='shipmentTracking:trckingDetails:segmentInfoGrp']//table[@class='portalTableStyle']");
            //HtmlNode node = doc.DocumentNode.SelectSingleNode("//table[@class='portalTableStyle']");
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//span[@id='shipmentTracking:trckingDetails:segmentInfoGrp']//table[@class='portalTableStyle']//tbody//tr[@class='portalTableDataRow2']//td").ToArray();

            List<string> items = new List<string>();


            if (nodes != null)
            {
                foreach (HtmlNode td in nodes)
                {
                    items.Add(td.InnerHtml);
                }
                return items;
            }
            else
            {
                items.Add("Nothing found.");
                //return "Nothing found.";
            }
            return items;
        }
    }
}