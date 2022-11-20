using DoubleTap.Affinity_Patches;
using DoubleTap.Configuration;
using DoubleTap.UI;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using System;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace DoubleTap;

[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
public class Plugin {

    [Init]
    public void Init(Zenjector zenjector, IPALogger logger, Config config) {
        // disable in FPFC
        if (Environment.CommandLine.Contains("fpfc")) return;
        
        var cfg = config.Generated<PluginConfig>();

        zenjector.UseLogger(logger);
        zenjector.UseMetadataBinder<Plugin>();
        zenjector.UseAutoBinder();
        
        zenjector.Install(Location.App, delegate(DiContainer container) {
            container.BindInstance(cfg).AsSingle();
            container.BindInterfacesTo<PauseMenu>().AsSingle();
        });
        
        zenjector.Install(Location.Menu, delegate(DiContainer container) {
            container.BindInterfacesTo<SettingsMenu>().AsSingle();
        });
    }
}