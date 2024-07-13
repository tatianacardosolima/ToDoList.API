using Prometheus;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace ToDoList.API.Middlewares
{
    [ExcludeFromCodeCoverage]
    internal static class PrometheusMiddleware
    {
        private static readonly List<string> ExceptionsPaths = new List<string>
            {
                "/favicon.ico", ""
            };

        public static IApplicationBuilder UsePrometheusMiddleware(
            this WebApplication app,
            Counter endpointRequestCounterMetric,
            Summary endpointRequestDurationMetric,
            Histogram endpointhistogramMetric,
            Gauge gaugeMetric)
        {
            return app.Use(async (context, next) =>
            {
                if (ExceptionsPaths.Contains(context.Request.Path))
                {
                    await next();
                }
                else
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    endpointRequestCounterMetric.WithLabels(context.Request.Method, context.Request.Path).Inc();
                    await next();
                    stopwatch.Stop();
                    endpointRequestDurationMetric.WithLabels(context.Request.Method, context.Request.Path).Observe(stopwatch.Elapsed.TotalSeconds);
                    endpointhistogramMetric.WithLabels(context.Request.Method, context.Request.Path).Observe(stopwatch.Elapsed.TotalSeconds);

                    var currentMemoryUsage = GC.GetTotalMemory(false);
                    gaugeMetric.Set(currentMemoryUsage);
                }    

            });
        }
    }
}
