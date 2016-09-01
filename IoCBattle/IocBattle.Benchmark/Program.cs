using System;
using IocBattle.Benchmark.Tests;

namespace IocBattle.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			var containers = new IContainer[]
			                 {
			                 	new NewContainer(),

									new AutoFacLambdaContainer(),
									
									new AutoFacContainer(),

                                    new SimpleInjectorContainer(), 

                                    new MicrosoftExtensionsContainer(),

			                 	    new UnityContainer(),

									new NinjectContainer()
			                 };

			foreach (var container in containers)
			{
				(new BenchEngine(container)).Start();
			}

			Console.Read();
		}
	}
}