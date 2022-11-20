using BeatSaberMarkupLanguage.Settings;
using DoubleTap.Configuration;
using System;
using Zenject;

namespace DoubleTap.UI;

internal class SettingsMenu : IInitializable, IDisposable {
    [Inject] private PluginConfig _config;
    
    public void Initialize() {
        BSMLSettings.instance.AddSettingsMenu("DoubleTap", "DoubleTap.UI.BSML.SettingsView.bsml", this);
    }

    public void Dispose() {
        BSMLSettings.instance.RemoveSettingsMenu(this);
    }
}