using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Frosting;

public static class Program
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .Run(args);
    }
}

public class BuildContext : FrostingContext
{
    public BuildContext(ICakeContext context)
        : base(context)
    {
    }
}

[TaskName("Successful-Task")]
public sealed class SuccessfulTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.Log.Information("✓ Passed");
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(SuccessfulTask))]
public class DefaultTask : FrostingTask;
