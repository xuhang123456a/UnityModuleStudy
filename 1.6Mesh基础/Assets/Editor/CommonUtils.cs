using UnityEditor;

namespace Editor
{
    public static class CommonUtils
    {
        [MenuItem("Tools/暂停游戏 _F1")]
        public static void PauseGame()
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
        }

        [MenuItem("Tools/添加预编译指令")]
        public static void SetCustomPreprocessorDirective()
        {
            string defineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            defineSymbols += ";USING_COROUTINE";
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defineSymbols);
        }
    }
}
