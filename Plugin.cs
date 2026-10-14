using BepInEx;
using BepInEx.Logging;

namespace Liquidwarp.DontCollectMyGarbage;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource LogSource;

    private void Awake()
    {
        LogSource = Logger;
        LogSource.LogInfo("plugin loaded!");
    }
}
