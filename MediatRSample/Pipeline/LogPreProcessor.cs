using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace MediatRSample.Pipeline

{
    public class LogPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;

        public LogPreProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"{nameof(LogPreProcessor<TRequest>)} Request -- {JsonSerializer.Serialize(request)}");
            return Task.CompletedTask;
        }
    }
}