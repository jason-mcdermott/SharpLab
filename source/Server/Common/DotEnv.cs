using System;
using System.IO;

namespace SharpLab.Server.Common {
    public static class DotEnv {
        public static void Load() {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var envPath = Path.Combine(rootPath, ".env");
            if (!File.Exists(envPath))
                return;

            foreach (var line in File.ReadLines(envPath)) {
                var trimmed = line.Trim();
                if (trimmed == "" || trimmed.StartsWith("#"))
                    continue;
                var parts = trimmed.Split(new[] { '=' }, 2);
                var key = parts[0].TrimEnd();
                var value = parts[1].TrimStart();

                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }
}
