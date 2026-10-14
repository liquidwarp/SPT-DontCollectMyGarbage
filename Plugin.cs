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

        // Not that I expect another mod to subclass `MemoryCollectionPatch`, but we still
        // ensure we disable one and only one `MemoryCollectionPatch` in the `SPT.Custom.Patches` namespace.
        var patch = ModPatchCache.GetActivePatches()
            .SingleOrDefault(p => p.GetType() == typeof(MemoryCollectionPatch));
        if (patch == null)
        {
            LogSource.LogWarning($"{typeof(MemoryCollectionPatch).FullName} is not active, nothing to disable");
            return;
        }

        patch.Disable();
        LogSource.LogInfo($"Disabled {typeof(MemoryCollectionPatch).FullName}");
    }
}
