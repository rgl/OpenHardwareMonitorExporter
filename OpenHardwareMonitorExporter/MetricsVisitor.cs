using OpenHardwareMonitor.Hardware;
using Prometheus;

namespace OpenHardwareMonitorExporter
{
    internal class MetricsVisitor : IVisitor
    {
        private CollectorRegistry _registry;

        public MetricsVisitor(CollectorRegistry registry)
        {
            _registry = registry;
        }

        public void VisitComputer(IComputer computer)
        {
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            hardware.Traverse(this);
        }

        public void VisitParameter(IParameter parameter)
        {
        }

        public void VisitSensor(ISensor sensor)
        {
            if (sensor.Hardware.HardwareType == HardwareType.CPU)
            {
                var metricName = $"ohm_cpu_{sensor.SensorType.ToString().ToLowerInvariant()}";
                var hw = sensor.Hardware.Identifier.ToString();
                var help = "TODO";
                switch (sensor.SensorType)
                {
                    case SensorType.Clock:
                        help = "Clock [MHz]";
                        break;
                    case SensorType.Load:
                        help = "Load [%]";
                        break;
                    case SensorType.Temperature:
                        help = "Temperature [C]";
                        break;
                    case SensorType.Power:
                        help = "Power consumption [W]";
                        break;
                }
                var gauge = Metrics.WithCustomRegistry(_registry).CreateGauge(metricName, help, "hw", "name");
                gauge.Labels(hw, sensor.Name).Set(sensor.Value.Value);
            }
        }
    }
}
