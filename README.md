[![Build status](https://ci.appveyor.com/api/projects/status/8je2pyhqtj9bhdi6?svg=true)](https://ci.appveyor.com/project/rgl/openhardwaremonitorexporter)

This is a [Prometheus Exporter](https://prometheus.io/docs/instrumenting/exporters/) Windows service for the [Open Hardware Monitor](http://openhardwaremonitor.org/) CPU sensors.

Install the Windows service with:

```powershell
.\OpenHardwareMonitorExporter.exe install
```

**NB** you can change the default url (`http://localhost:9398/metrics`) with the `-url` parameter, e.g., `-url:http://localhost:9398/ohm/metrics`.
