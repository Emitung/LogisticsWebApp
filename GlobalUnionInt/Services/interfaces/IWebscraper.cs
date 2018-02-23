using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalUnionInt.Services.interfaces
{
    public interface IWebscraper
    {
        List<string> NCA1(string url);
        List<string> NCA2(string url);
    }
}
