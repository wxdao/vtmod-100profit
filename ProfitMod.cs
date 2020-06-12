using System;
using System.Collections.Generic;
using HarmonyLib;
using VoxelTycoon.Serialization;
using VoxelTycoon.Tracks;

public class ProfitMod : VoxelTycoon.Modding.Mod
{
    protected override void Initialize()
    {
        var harmony = new Harmony("wxdao.100profit");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(VehicleStation), "OnInvalidateSiblings")]
class VehicleStation_OnInvalidateSiblings_ProfitPatch
{
    static void Postfix(List<VehicleStation.Customer> ____customers)
    {
        var oldList = new List<VehicleStation.Customer>(____customers);
        ____customers.Clear();
        foreach (var c in oldList)
        {
            ____customers.Add(new VehicleStation.Customer
            {
                Demand = c.Demand,
                NormalizedProfit = 1,
            });
        }
    }
}
