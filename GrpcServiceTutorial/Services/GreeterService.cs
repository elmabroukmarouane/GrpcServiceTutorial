using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceTutorial
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<CallServiceGrpcReply> CallServiceGrpc(CallServiceGrpcoRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CallServiceGrpcReply
            {
                Message = "Hello " + request.Name + ". This is your message : " + request.Message
            });
        }
    }
}
