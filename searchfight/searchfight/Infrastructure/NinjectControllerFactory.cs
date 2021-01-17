using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using searchfight.Domain.Concrete;
using searchfight.Domain.Abstract;
using Moq;
using searchfight.Domain.Entities;
using System.Linq;
using searchfight.Model;

namespace searchfight.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ISearchEngineRepository>().To<EFSearchEngineRepository>();
            ninjectKernel.Bind<IParameterTypeRepository>().To<EFParameterTypeRepository>();
            ninjectKernel.Bind<IParameterRepository>().To<EFParameterRepository>();
            ninjectKernel.Bind<ISearch>().To<Search>();

            //Mock<ISearchEngineRepository> mockSearchEngine = new Mock<ISearchEngineRepository>();
            //mockSearchEngine.Setup(m => m.SearchEngines).Returns(new List<SearchEngine> {
            //    new SearchEngine { searchEngineID = 1, name = "Google", description = "Google", httpMethod = "GET", httpUrl = "https://www.google.com/search", httpBody = null, beginSection = "<div id=\"result-stats\">", endSection = "</div>", replaceOldValue = ",", replaceNewValue = "", patternRegexpExtract = @"\d+(,\d+)*", disabled = false },
            //    new SearchEngine { searchEngineID = 2, name = "BING", description = "Microsoft's Search Engine", httpMethod = "GET", httpUrl = "https://www.bing.com/search", httpBody = null, beginSection = "<span class=\"sb_count\">", endSection = "</span>", replaceOldValue = ".", replaceNewValue = "", patternRegexpExtract = @"\d+(.\d+)*", disabled = false }
            //}.AsQueryable());
            //ninjectKernel.Bind<ISearchEngineRepository>().ToConstant(mockSearchEngine.Object);

            //Mock<IParameterTypeRepository> mockParameterType = new Mock<IParameterTypeRepository>();
            //mockParameterType.Setup(m => m.ParameterTypes).Returns(new List<ParameterType> {
            //    new ParameterType { parameterTypeID = 1, name = "uri", disabled = false },
            //    new ParameterType { parameterTypeID = 2, name = "query", disabled = false },
            //    new ParameterType { parameterTypeID = 3, name = "header", disabled = false }
            //}.AsQueryable());
            //ninjectKernel.Bind<IParameterTypeRepository>().ToConstant(mockParameterType.Object);

            //Mock<IParameterRepository> mockParameter = new Mock<IParameterRepository>();
            //mockParameter.Setup(m => m.Parameters).Returns(new List<Parameter> {
            //    new Parameter { parameterID = 1, searchEngineID = 1, parameterTypeID = 2, name = "source", value = "hp", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 2, searchEngineID = 1, parameterTypeID = 2, name = "ei", value = "g2kDYN2RFIS25gLP950I", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 3, searchEngineID = 1, parameterTypeID = 2, name = "q", value = null, disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 4, searchEngineID = 1, parameterTypeID = 2, name = "oq", value = null, disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 5, searchEngineID = 1, parameterTypeID = 2, name = "gs_lcp", value = "CgZwc3ktYWIQAzIFCAAQsQMyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6AgguUKcLWMsPYP0TaAFwAHgAgAGaBYgB_Q-SAQU0LTMuMZgBAKABAaoBB2d3cy13aXqwAQA", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 6, searchEngineID = 1, parameterTypeID = 2, name = "sclient", value = "psy-ab", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 7, searchEngineID = 1, parameterTypeID = 2, name = "ved", value = "0ahUKEwid34CGwaHuAhUEm1kKHc97BwEQ4dUDCAY", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 8, searchEngineID = 1, parameterTypeID = 2, name = "uact", value = "5", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 9, searchEngineID = 1, parameterTypeID = 3, name = "Accept", value = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 10, searchEngineID = 1, parameterTypeID = 3, name = "Accept-Encoding", value = "gzip, deflate, br", disabled = true, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 11, searchEngineID = 1, parameterTypeID = 3, name = "Accept-Language", value = "en-US,en;q=0.5", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 12, searchEngineID = 1, parameterTypeID = 3, name = "Cache-Control", value = "max-age=0", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 13, searchEngineID = 1, parameterTypeID = 3, name = "Connection", value = "keep-alive", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 14, searchEngineID = 1, parameterTypeID = 3, name = "Cookie", value = "CGIC=Ikp0ZXh0L2h0bWwsYXBwbGljYXRpb24veGh0bWwreG1sLGFwcGxpY2F0aW9uL3htbDtxPTAuOSxpbWFnZS93ZWJwLCovKjtxPTAuOA; 1P_JAR=2021-01-16-22; NID=207=Uuqh8TU0afIcu_y14-uSsO9kJsjvmRdReuZrqffJzI6EzRTu6Y5d-vC4X9cHtOqxj0q1wCxn1jw5_fumS_S2RITHUTJq0aBUMAkjCVTZUwYiIzEWMrIMk6dpMApS7GHchSuAUftlIDTgUK-p-XJqYYtydpNFbI9H7OqLeKeVfLI; ANID=AHWqTUkTHwyEZ1L0dQ3MzWwFXxtx2lqBJKFlBz6zRPzqVMwrhawkiwjJKHKTy29V; OTZ=5802761_76_76__76_; DV=s2pDxgLCIpEqcJwiBMaOV24J8U_VcNdcOI1FeSUqQgMAAAA", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 15, searchEngineID = 1, parameterTypeID = 3, name = "Host", value = "www.google.com", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 16, searchEngineID = 1, parameterTypeID = 3, name = "Upgrade-Insecure-Requests", value = "1", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 17, searchEngineID = 1, parameterTypeID = 3, name = "User-Agent", value = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[0], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 18, searchEngineID = 2, parameterTypeID = 2, name = "q", value = null, disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 19, searchEngineID = 2, parameterTypeID = 2, name = "form", value = "QBLH", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 20, searchEngineID = 2, parameterTypeID = 2, name = "sp", value = "-1", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 21, searchEngineID = 2, parameterTypeID = 2, name = "pq", value = ".ne", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 22, searchEngineID = 2, parameterTypeID = 2, name = "sc", value = "9-3", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 23, searchEngineID = 2, parameterTypeID = 2, name = "qs", value = "n", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 24, searchEngineID = 2, parameterTypeID = 2, name = "sk", value = "", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 25, searchEngineID = 2, parameterTypeID = 2, name = "cvid", value = "025DE79650A84D9DB46D65C6AD58D07E", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[1] },
            //    new Parameter { parameterID = 26, searchEngineID = 2, parameterTypeID = 3, name = "accept", value = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 27, searchEngineID = 2, parameterTypeID = 3, name = "accept-encoding", value = "gzip, deflate, br", disabled = true, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 28, searchEngineID = 2, parameterTypeID = 3, name = "accept-language", value = "en-US,en;q=0.9", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 29, searchEngineID = 2, parameterTypeID = 3, name = "cache-control", value = "max-age=0", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 30, searchEngineID = 2, parameterTypeID = 3, name = "cookie", value = "SRCHUID=V=2&GUID=A7F5A4F33416451D84B84DEAD4ABAC1F&dmnchg=1; SRCHD=AF=NOFORM; MUID=2899DADFBC3F67350889D549B83F61C5; _RwBf=mtu=0&g=0&cid=&o=2&p=&c=&t=0&s=0001-01-01T00:00:00.0000000+00:00&ts=2021-01-10T03:21:58.5434423+00:00; MUIDB=2899DADFBC3F67350889D549B83F61C5; ABDEF=V=13&ABDV=11&MRNB=1610249308087&MRB=0; ANON=A=195FF7276D9D73B11DF76DB5FFFFFFFF; WLS=C=a8a161d223657b9e&N=Adalberto+Jos%c3%a9; _SS=SID=065F82716F506C1922428DB06EF76D4F; _U=1efcFXbPATdrqL1Lv-HegTGo758QWYVmFHfAfaSZcC2jdR2vS1gBQ_LddG-HXdXRS0i4dngyH_bn-epkjU6YL-Grlb7kysilp8991G6F-gqeEQ4babudrnbkEfZGhX_D-kUcJNC12QaBYlA4FyxdSJZhFSHZh1VYTqhdHV7OR5Ft_zC1w-0GLand3eiErHlkHBAxB3ayAv_W86MQpGP8q5g; _HPVN=CS=eyJQbiI6eyJDbiI6MiwiU3QiOjAsIlFzIjowLCJQcm9kIjoiUCJ9LCJTYyI6eyJDbiI6MiwiU3QiOjAsIlFzIjowLCJQcm9kIjoiSCJ9LCJReiI6eyJDbiI6MiwiU3QiOjAsIlFzIjowLCJQcm9kIjoiVCJ9LCJBcCI6dHJ1ZSwiTXV0ZSI6dHJ1ZSwiTGFkIjoiMjAyMS0wMS0xNlQwMDowMDowMFoiLCJJb3RkIjowLCJEZnQiOm51bGwsIk12cyI6MCwiRmx0IjowLCJJbXAiOjR9; _EDGE_S=SID=065F82716F506C1922428DB06EF76D4F&mkt=es-pe; SRCHUSR=DOB=20201204&T=1610836479000; ipv6=hit=1610840084704&t=4; SRCHHPGUSR=LUT=1610248146793&BRW=W&BRH=S&CW=1536&CH=454&DPR=1.25&UTC=-300&DM=0&HV=1610836491&WTS=63745844987", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 31, searchEngineID = 2, parameterTypeID = 3, name = "referer", value = "https://www.bing.com/", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 32, searchEngineID = 2, parameterTypeID = 3, name = "sec-fetch-dest", value = "document", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 33, searchEngineID = 2, parameterTypeID = 3, name = "sec-fetch-mode", value = "navigate", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 34, searchEngineID = 2, parameterTypeID = 3, name = "sec-fetch-site", value = "same-origin", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 35, searchEngineID = 2, parameterTypeID = 3, name = "sec-fetch-user", value = "?1", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 36, searchEngineID = 2, parameterTypeID = 3, name = "upgrade-insecure-requests", value = "1", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //    new Parameter { parameterID = 37, searchEngineID = 2, parameterTypeID = 3, name = "user-agent", value = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36 Edg/87.0.664.75", disabled = false, searchEngine = mockSearchEngine.Object.SearchEngines.ToList()[1], parameterType = mockParameterType.Object.ParameterTypes.ToList()[2] },
            //}.AsQueryable());
            //ninjectKernel.Bind<IParameterRepository>().ToConstant(mockParameter.Object);

            //Mock<ISearch> mockSearch = new Mock<ISearch>();
            //mockSearch.Setup(m => m.results).Returns(131000000);
            //mockSearch.Setup(m => m.searchEngine).Returns(mockSearchEngine.Object.SearchEngines.FirstOrDefault());
            //ninjectKernel.Bind<ISearch>().ToConstant(mockSearch.Object);

        }
    }
}
