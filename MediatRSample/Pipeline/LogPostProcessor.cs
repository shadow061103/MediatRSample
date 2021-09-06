using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading;

namespace MediatRSample.Pipeline
{
    public class LogPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LogPostProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"{nameof(LogPostProcessor<TRequest, TRequest>)} Request -- {JsonSerializer.Serialize(request)}");
            _logger.LogDebug($"{nameof(LogPostProcessor<TRequest, TResponse>)} Response -- {JsonSerializer.Serialize(response)}");
            return Task.CompletedTask;
        }
    }
}