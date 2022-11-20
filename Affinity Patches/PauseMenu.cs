using DoubleTap.Configuration;
using SiraUtil.Affinity;
using UnityEngine;

namespace DoubleTap.Affinity_Patches; 

internal class PauseMenu : IAffinity {
    private PluginConfig _config;
    private float _lastPressTime;
    
    public PauseMenu(PluginConfig config) {
        _config = config;
        _lastPressTime = Time.realtimeSinceStartup;
    }

    [AffinityPrefix] 
    [AffinityPatch(typeof(PauseController), nameof(PauseController.HandlePauseMenuManagerDidPressMenuButton))]
    [AffinityPatch(typeof(PauseController), nameof(PauseController.HandlePauseMenuManagerDidPressRestartButton))]
    public bool Prefix() {
        if (!_config.Enabled) return true;

        var t = Time.realtimeSinceStartup;
        var flag = t - _lastPressTime < _config.Threshold;
        _lastPressTime = t;
        
        return flag;
    }
}