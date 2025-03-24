using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using PunFixedRegion.Common;
using PunFixedRegion.Patches;

namespace PunFixedRegion;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class PunFixedRegionPlugin : BaseUnityPlugin
{

    internal new static ManualLogSource Logger;
    internal static ConfigEntry<bool> Enabled;
    internal static ConfigEntry<EPhotonRegion> Region;
    
    private readonly Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        SetupConfiguration();

        _harmony.PatchAll(typeof(SteamManagerPatch));
        Logger.LogInfo("SteamManagerPatch is patched!");
    }

    private void SetupConfiguration()
    {
        Enabled = Config.Bind(
            "General",
            "Enabled",
            true,
            "Toggle"
        );
        
        Region = Config.Bind(
            "General",
            "Region",
            EPhotonRegion.BestServer,
            "https://doc.photonengine.com/pun/current/connection-and-authentication/regions"
        );
    }
}