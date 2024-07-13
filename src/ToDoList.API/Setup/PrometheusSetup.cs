using Prometheus;

namespace ToDoList.API.Setup
{
    public static class PrometheusSetup
    {
        public static Summary CreateEndpointRequestDurationSummaryMetric()
        {
            return Metrics.CreateSummary("tati_todolist_endpoint_duration_seconds", "Duration of HTTP requests in seconds",
                new SummaryConfiguration
                {
                    Objectives =
                    [
                        new QuantileEpsilonPair(0.5, 0.05),
                        new QuantileEpsilonPair(0.9, 0.01),
                        new QuantileEpsilonPair(0.99, 0.001)
                    ],
                    LabelNames = ["method", "endpoint"]
                });
        }

        public static Counter CreateEndpointRequestCounterMetric()
        {
            return Metrics.CreateCounter("tati_todolist_endpoint_request_total", "Total number of HTTP requests",
                new CounterConfiguration
                {
                    LabelNames = ["method", "endpoint"]
                });
        }

        public static Histogram CreateEndpointRequestDurationHistogramMetric()
        {
            return Metrics.CreateHistogram("tati_todolist_endpoint_durationhistogram_seconds", "Histogram number of HTTP requests",
                new HistogramConfiguration
                {
                    LabelNames = ["method", "endpoint"]
                });
        }

        public static Gauge CreateEndpointRequestGaugeMetric()
        {
            return Metrics.CreateGauge("memory_usage_bytes", "Current memory usage in bytes");

        }
    }
}
