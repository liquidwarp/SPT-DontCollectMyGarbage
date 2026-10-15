using System.Linq;
using BepInEx;
using BepInEx.Logging;
using SPT.Custom.Patches;
using SPT.Reflection.Patching;

namespace Liquidwarp.DontCollectMyGarbage;

[BepInPlugin(MyModInfo.MOD_GUID, MyModInfo.MOD_NAME, MyModInfo.MOD_VERSION)]
[BepInDependency("com.SPT.custom", MyModInfo.CLIENT_SPT_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource LogSource;

    private void Awake()
    {
        LogSource = Logger;

        if (ModPatchCache.GetActivePatches()
                .FirstOrDefault(p => p.GetType() == typeof(MemoryCollectionPatch))
            is MemoryCollectionPatch patch)
        {
            patch.Disable();
            LogSource.LogInfo($"Disabled {typeof(MemoryCollectionPatch).FullName}");
        }
        else
        {
            LogSource.LogWarning($"{typeof(MemoryCollectionPatch).FullName} is not active, nothing to disable");
        }
    }
}
