#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattlePhaze.Vsync
{
    /// <summary>
    /// BattlePhaze Vsync Controller
    /// </summary>
    public class BattlePhazeVsyncOff : MonoBehaviour
    {
        /// <summary>
        /// Target Frame Rate
        /// </summary>
        public int TargetFrameRate = 60;
        /// <summary>
        /// Vsync
        /// </summary>
        public VSync Sync;
        /// <summary>
        /// On Enable
        /// </summary>
        public void OnEnable()
        {
            VSyncApply();
        }
        /// <summary>
        /// VSync Apply
        /// </summary>
        public void VSyncApply()
        {
            QualitySettings.vSyncCount = (int)Sync;
            Application.targetFrameRate = TargetFrameRate;
        }
        /// <summary>
        /// VSync
        /// </summary>
        public enum VSync
        {
            DontSync, EveryVBlank, EverySecondVBlank
        }
    }
}
#endif