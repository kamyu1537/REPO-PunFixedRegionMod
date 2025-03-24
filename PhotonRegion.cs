using System.Collections.Generic;

namespace PunFixedRegion;

internal class PhotonRegion
{
    public PhotonRegions Key { get; }
    public string Value { get; }

    private PhotonRegion(PhotonRegions key, string value)
    {
        Key = key;
        Value = value;

        All.TryAdd(key, this);
    }

    private static readonly Dictionary<PhotonRegions, PhotonRegion> All = new();

    internal static readonly PhotonRegion BestServer = new (PhotonRegions.BestServer, "");
    internal static readonly PhotonRegion Asia = new(PhotonRegions.Asia, "asia");
    internal static readonly PhotonRegion Australia = new(PhotonRegions.Australia, "au");
    // internal static readonly PhotonRegion Canada_East = new(PhotonRegions.Canada_East, "cae");
    // internal static readonly PhotonRegion Chinese_Mainland = new(PhotonRegions.Chinese_Mainland, "cn");
    internal static readonly PhotonRegion Europe = new(PhotonRegions.Europe, "eu");
    // internal static readonly PhotonRegion HongKong = new(PhotonRegions.HongKong, "hk");
    // internal static readonly PhotonRegion India = new(PhotonRegions.India, "in");
    internal static readonly PhotonRegion Japan = new(PhotonRegions.Japan, "jp");
    internal static readonly PhotonRegion SouthAfrica = new(PhotonRegions.SouthAfrica, "za");
    internal static readonly PhotonRegion SouthAmerica = new(PhotonRegions.SouthAmerica, "sa");
    // internal static readonly PhotonRegion SouthKorea = new(PhotonRegions.SouthKorea, "kr");
    // internal static readonly PhotonRegion Turkey = new(PhotonRegions.Turkey, "tr");
    // internal static readonly PhotonRegion UnitedArabEmirates = new(PhotonRegions.UnitedArabEmirates, "uae");
    internal static readonly PhotonRegion USA_East = new(PhotonRegions.USA_East, "us");
    internal static readonly PhotonRegion USA_West = new(PhotonRegions.USA_West, "usw");
    // internal static readonly PhotonRegion USA_SouthCentral = new(PhotonRegions.USA_SouthCentral, "ussc");

    internal static bool TryGetValue(PhotonRegions region, out PhotonRegion value) => All.TryGetValue(region, out value);
}