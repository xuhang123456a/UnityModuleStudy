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
    }
}
