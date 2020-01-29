using System;
using System.Collections.Generic;
using HarmonyLib;
using VoxelTycoon.Serialization;
using VoxelTycoon.Tracks;

public class ProfitMod : VoxelTycoon.Modding.IMod
{
    public void OnBeforeGameLoad()
    {
        var harmony = new Harmony("wxdao.100profit");
        harmony.PatchAll();
    }

    public void OnGameLoaded()
    {
    }

    public void Read(StateBinaryReader reader)
    {
    }

    public void Write(StateBinaryWriter writer)
    {
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

