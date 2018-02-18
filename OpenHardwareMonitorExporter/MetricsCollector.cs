using OpenHardwareMonitor.Hardware;
using Prometheus.Advanced;
using System;

namespace OpenHardwareMonitorExporter
{
    internal class MetricsCollector : IOnDemandCollector, IDisposable
    {
        private Computer _computer;
        private MetricsVisitor _visitor;

        public MetricsCollector()
        {
            _computer = new Computer()
            {
                CPUEnabled = true,
            };

            _computer.Open();
        }

        public void Dispose()
        {
            _computer.Close();
        }

        public void RegisterMetrics(ICollectorRegistry registry)
        {
            _visitor = new MetricsVisitor(registry);
        }

        public void UpdateMetrics()
        {
            _computer.Traverse(_visitor);
        }
    }
}
