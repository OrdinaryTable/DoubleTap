using BeatSaberMarkupLanguage.Attributes;
using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace DoubleTap.Configuration;

internal class PluginConfig {
    public virtual bool Enabled { get; set; } = true;
    public virtual float Threshold { get; set; } = 0.4f;

    [UIAction("MsFormatter")]
    public string MsFormatter(float v) {
        return $"{v * 1000:F0}ms";
    }
}