//using Grpc.Net.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.gRPC
//{
//    public class AuthServiceGrpcClient
//    {
//        private readonly AuthGrpc.AuthGrpcClient _client;

//        public AuthServiceGrpClient()
//        {
//            var channel = GrpcChannel.ForAddress("https://localhost:5001"); // Spring Boot gRPC Service URL
//            _client = new AuthGrpc.AuthGrpcClient(channel);
//        }

//        public async Task<UserDetailsDto> GetUserDetailsAsync(string userId)
//        {
//            var request = new UserRequest { UserId = userId };
//            var response = await _client.GetUserAsync(request);
//            return new UserDetailsDto(response.FullName, response.Email);
//        }
//    }
//}
