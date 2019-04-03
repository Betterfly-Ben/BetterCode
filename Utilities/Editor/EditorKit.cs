#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Betterfly.BetterCode
{
    // Before scene start:          isPlayingOrWillChangePlaymode = false;  isPlaying = false
    // Pressed Playback button:     isPlayingOrWillChangePlaymode = true;   isPlaying = false
    // Playing:                     isPlayingOrWillChangePlaymode = false;  isPlaying = true
    // Pressed stop button:         isPlayingOrWillChangePlaymode = true;   isPlaying = true
    public enum EditorApplicationStatus
    {
        BeforeSceneStart = 0,
        PressedPlayButton = 1,
        Playing = 2,
        PressedStopButton = 3,
    }
    
    public static class EditorKit
    {
        /// <summary>
        /// 设置当前Scene为dirty
        /// </summary>
        public static void SetCurrentSceneDirty()
        {
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }

        /// <summary>
        /// 刷新Assets
        /// </summary>
        public static void RefreshAssets()
        {
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 暂停Editor的播放
        /// </summary>
        public static void PauseEditor()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPaused = true;
            }
        }

        /// <summary>
        /// 获取EditorApplication当前的状态
        /// </summary>
        /// <returns>EditorApplicationStatus</returns>
        public static EditorApplicationStatus GetEditorApplicationStatus()
        {
            // Before scene start:          isPlayingOrWillChangePlaymode = false;  isPlaying = false
            // Pressed Playback button:     isPlayingOrWillChangePlaymode = true;   isPlaying = false
            // Playing:                     isPlayingOrWillChangePlaymode = false;  isPlaying = true
            // Pressed stop button:         isPlayingOrWillChangePlaymode = true;   isPlaying = true
            bool isPlayingOrWillChangePlayMode = EditorApplication.isPlayingOrWillChangePlaymode;
            bool isPlaying = EditorApplication.isPlaying;
            
            if (isPlayingOrWillChangePlayMode == false && isPlaying == false)
            {
                return EditorApplicationStatus.BeforeSceneStart;
            }
            
            if (isPlayingOrWillChangePlayMode && isPlaying == false)
            {
                return EditorApplicationStatus.PressedPlayButton;
            }
            
            if (isPlayingOrWillChangePlayMode == false)
            {
                return EditorApplicationStatus.Playing;
            }

            return EditorApplicationStatus.PressedStopButton;
        }
    }
}
#endif