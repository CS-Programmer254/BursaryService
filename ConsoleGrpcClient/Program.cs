using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using ConsoleGrpcClient.Protos;

class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:8085",
         new GrpcChannelOptions { Credentials = Grpc.Core.ChannelCredentials.Insecure });
        var client = new AuthService.AuthServiceClient(channel);

        var request = new UserRequest { PhoneNumber = "1234567890" };

        try
        {
            var response = await client.GetUserAsync(request);
            Console.WriteLine($"User ID: {response.UserId}, Name: {response.FirstName} {response.LastName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
