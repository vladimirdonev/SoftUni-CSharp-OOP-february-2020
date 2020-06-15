using System;
using WildFarm.Engine;
namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Build build = new Build();
            build.run();
        }
    }
}
