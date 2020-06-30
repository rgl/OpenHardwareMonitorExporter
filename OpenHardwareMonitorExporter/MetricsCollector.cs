using OpenHardwareMonitor.Hardware;
using Prometheus;
using System;

namespace OpenHardwareMonitorExporter
{
    internal class MetricsCollector : IDisposable
    {
        private MetricsVisitor _visitor;
        private Computer _computer;

        public MetricsCollector(CollectorRegistry registry)
        {
            _visitor = new MetricsVisitor(registry);

            _computer = new Computer()
            {
                CPUEnabled = true,
            };
        }

        public void Open()
        {
            _computer.Open();
        }

        public void Close()
        {
            _computer.Close();
        }

        public void Dispose()
        {
            Close();
        }

        public void UpdateMetrics()
        {
            _computer.Traverse(_visitor);
        }
    }
}
