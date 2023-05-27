namespace Sample;

internal interface IApplication
{
    Task Run(CancellationToken ct);
}