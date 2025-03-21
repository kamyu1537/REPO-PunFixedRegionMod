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
        PunFixedRegionPlugin.Logger.LogInfo($"Current FixedRegion: {currentFixedRegion}");
        
        if (currentFixedRegion == PunFixedRegionPlugin.Region.Value) return true;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = PunFixedRegionPlugin.Region.Value;
        PunFixedRegionPlugin.Logger.LogInfo($"Photon Fixed Region changed!: {currentFixedRegion} -> {PunFixedRegionPlugin.Region.Value}");

        return true;
    }
}