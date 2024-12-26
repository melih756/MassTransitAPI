using MassTransit;
using MassTransitAPI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public class RegistrationBatchConsumer : IConsumer<SubmitRegistration>
{
    private readonly IPublishEndpoint _publishEndpoint;




    public RegistrationBatchConsumer(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<SubmitRegistration> context)
    {
        var registration = context.Message;

        Console.WriteLine($"{registration.guid} = {(DateTime.Now - registration.publishDate).TotalMilliseconds}");

        await Task.CompletedTask;
    }


}
