using System.Linq;
using BepInEx;
using BepInEx.Logging;
using SPT.Custom.Patches;
using SPT.Reflection.Patching;

namespace Liquidwarp.DontCollectMyGarbage;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.SPT.custom", "4.1.6")]
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
