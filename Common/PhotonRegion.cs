using System.Collections.Generic;

namespace PunFixedRegion.Common;

internal class PhotonRegion
{
    public EPhotonRegion Key { get; }
    public string Value { get; }

    private PhotonRegion(EPhotonRegion key, string value)
    {
        Key = key;
        Value = value;

        All.TryAdd(key, this);
    }

    private static readonly Dictionary<EPhotonRegion, PhotonRegion> All = new();

    internal static readonly PhotonRegion BestServer = new (EPhotonRegion.BestServer, "");
    internal static readonly PhotonRegion Asia = new(EPhotonRegion.Asia, "asia");
    internal static readonly PhotonRegion Australia = new(EPhotonRegion.Australia, "au");
    // internal static readonly PhotonRegion Canada_East = new(PhotonRegions.Canada_East, "cae");
    // internal static readonly PhotonRegion Chinese_Mainland = new(PhotonRegions.Chinese_Mainland, "cn");
    internal static readonly PhotonRegion Europe = new(EPhotonRegion.Europe, "eu");
    // internal static readonly PhotonRegion HongKong = new(PhotonRegions.HongKong, "hk");
    // internal static readonly PhotonRegion India = new(PhotonRegions.India, "in");
    internal static readonly PhotonRegion Japan = new(EPhotonRegion.Japan, "jp");
    internal static readonly PhotonRegion SouthAfrica = new(EPhotonRegion.SouthAfrica, "za");
    internal static readonly PhotonRegion SouthAmerica = new(EPhotonRegion.SouthAmerica, "sa");
    // internal static readonly PhotonRegion SouthKorea = new(PhotonRegions.SouthKorea, "kr");
    // internal static readonly PhotonRegion Turkey = new(PhotonRegions.Turkey, "tr");
    // internal static readonly PhotonRegion UnitedArabEmirates = new(PhotonRegions.UnitedArabEmirates, "uae");
    internal static readonly PhotonRegion USA_East = new(EPhotonRegion.USA_East, "us");
    internal static readonly PhotonRegion USA_West = new(EPhotonRegion.USA_West, "usw");
    // internal static readonly PhotonRegion USA_SouthCentral = new(PhotonRegions.USA_SouthCentral, "ussc");

    internal static bool TryGetValue(EPhotonRegion region, out PhotonRegion value) => All.TryGetValue(region, out value);
}