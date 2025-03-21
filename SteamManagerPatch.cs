using HarmonyLib;
using Photon.Pun;

namespace PunFixedRegion;

internal class SteamManagerPatch
{
    [HarmonyPatch(typeof(SteamManager), nameof(SteamManager.HostLobby))]
    private static bool Prefix()
    {
        if (false == PunFixedRegionPlugin.Enabled.Value) return true;
        
        var currentFixedRegion = PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion;
        PunFixedRegionPlugin.Logger.LogInfo("SteamManager.HostLobby called!");
        PunFixedRegionPlugin.Logger.LogInfo($"Selected Region: \"{PunFixedRegionPlugin.Region.Value}\"");
        PunFixedRegionPlugin.Logger.LogInfo($"Current FixedRegion: \"{currentFixedRegion}\"");

        if (false == PhotonRegion.TryGetValue(PunFixedRegionPlugin.Region.Value, out var region))
        {
            region = PhotonRegion.BestServer;
        }
        
        if (currentFixedRegion == region.Value) return true;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.Value;
        PunFixedRegionPlugin.Logger.LogInfo($"Photon Fixed Region changed!: \"{currentFixedRegion}\" -> \"{region.Value}\"");

        return true;
    }
}