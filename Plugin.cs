using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace PunFixedRegion;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class PunFixedRegionPlugin : BaseUnityPlugin
{
    private const string PluginGuid = "PunFixedRegion";
    private const string PluginName = "PunFixedRegion";
    private const string PluginVersion = "1.0.0";

    internal new static ManualLogSource Logger;
    internal static ConfigEntry<bool> Enabled;
    internal static ConfigEntry<string> Region;
    
    private readonly Harmony _harmony = new(PluginGuid);

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {PluginGuid} is loaded!");

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
            "",
            "Empty is default. (https://doc.photonengine.com/pun/current/connection-and-authentication/regions)"
        );
    }
}