using searchfight.Domain.Abstract;
using searchfight.Infrastructure;
using System;
using System.Web.Mvc;
using System.Linq;
using searchfight.Model;
using Ninject;
using System.Reflection;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectControllerFactory ninject = new NinjectControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(ninject);

            ISearchEngineRepository repositorySearchEngine = ninject.ninjectKernel.Get<ISearchEngineRepository>();
            IParameterRepository repositoryParameter = ninject.ninjectKernel.Get<IParameterRepository>();
            IParameterTypeRepository repositoryParameterType = ninject.ninjectKernel.Get<IParameterTypeRepository>();

            string[] searchEngineWinners = new string[args.Length];
            long[] maxResults = new long[args.Length];
            long[] totals = new long[args.Length];
            long maxTotal = 0;
            string maxArg = "";

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    maxResults[i] = 0;
                    totals[i] = 0;

                    Console.Write("\n" + args[i] + ": ");

                    foreach (var item in repositorySearchEngine.SearchEngines)
                    {
                        ISearch search = ninject.ninjectKernel.Get<ISearch>(new Ninject.Parameters.ConstructorArgument("searchEngine", item));

                        search.Execute(args[i], repositoryParameter.Parameters.Where(x => x.searchEngineID == item.searchEngineID), repositoryParameterType.ParameterTypes);

                        Console.Write(item.name + ": " + search.results + " ");

                        if(search.results > maxResults[i])
                        {
                            searchEngineWinners[i] = item.name;
                            maxResults[i] = search.results;
                        }
                        totals[i] += search.results;
                    }
                    if(totals[i] > maxTotal)
                    {
                        maxArg = args[i];
                        maxTotal = totals[i];
                    }
                }
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("\n" + searchEngineWinners[i] + " winner: " + args[i]);
                }
                Console.WriteLine("\nTotal winner: " + maxArg);
            }
            else
            {
                Console.WriteLine("\nBad Usage\nUsage: searchfight.exe [args]");
            }
        }
    }
}
