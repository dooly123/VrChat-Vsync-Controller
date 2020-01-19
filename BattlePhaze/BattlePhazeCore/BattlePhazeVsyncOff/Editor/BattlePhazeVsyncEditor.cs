using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace BattlePhaze.Vsync.EditorCustom
{
    [CustomEditor(typeof(BattlePhazeVsyncOff))]
    public class BattlePhazeVsyncEditor : Editor
    {
        public Color32 PrimaryWhiteColor = new Color32(242, 85, 228, 255);
        public Color32 SecondaryColor = new Color32(140, 140, 140, 255);
        public GUIStyle FoldOutStyle;
        public GUIStyle TextStyling;
        public GUIStyle StyleButton;
        public GUIStyle EnumStyling;
        private bool rerun;
        /// <summary>
        /// On Inspector GUI
        /// </summary>
        public override void OnInspectorGUI()
        {
            BattlePhazeVsyncOff BattlePhazeVsyncOffManager = (BattlePhazeVsyncOff)target;
            if (rerun == false)
            {
                UIDesign();
            }
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Target Frame Rate", TextStyling);
            BattlePhazeVsyncOffManager.TargetFrameRate = EditorGUILayout.IntField(BattlePhazeVsyncOffManager.TargetFrameRate);
            GUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Vsync Setting", TextStyling);
            BattlePhazeVsyncOffManager.Sync = (BattlePhazeVsyncOff.VSync)EditorGUILayout.EnumPopup(BattlePhazeVsyncOffManager.Sync, EnumStyling);
            GUILayout.EndVertical();
            if (GUILayout.Button("Vsync Value Update",StyleButton))
            {
                if(BattlePhazeVsyncOffManager.TargetFrameRate == 0)
                {
                    BattlePhazeVsyncOffManager.TargetFrameRate = 90;
                }
                BattlePhazeVsyncOffManager.VSyncApply();
            }
        }
        /// <summary>
        /// UI Design
        /// </summary>
        public void UIDesign()
        {
            rerun = true;
            StyleButton = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleCenter,
                margin = new RectOffset(3, 3, 3, 3),
                fontSize = 15,
                fontStyle = FontStyle.Bold
            };
            StyleButton.normal.background = SetColor(40, 40, SecondaryColor);
            StyleButton.normal.textColor = PrimaryWhiteColor;
            TextStyling = new GUIStyle(GUI.skin.textArea)
            {
                alignment = TextAnchor.MiddleLeft,
                margin = new RectOffset(3, 3, 3, 3),
                fontSize = 15,
                fontStyle = FontStyle.Bold
            };
            TextStyling.fixedWidth = 300;
            TextStyling.fixedHeight = 20;
            TextStyling.normal.background = SetColor(2, 2, new Color(0.9f, 0.9f, 0.9f, 0f));
            TextStyling.clipping = TextClipping.Overflow;
            TextStyling.normal.textColor = PrimaryWhiteColor;
            EnumStyling = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 10,
                fontStyle = FontStyle.Bold
            };
            EnumStyling.normal.background = SetColor(2, 2, new Color(0.4f, 0.4f, 0.4f, 0.5f));
            EnumStyling.normal.textColor = PrimaryWhiteColor;
        }
        /// <summary>
        /// Used for setting a color of a Texture2D
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Texture2D SetColor(int x, int y, Color32 color)
        {
            Texture2D tex = new Texture2D(x, y);
            Color[] pix = new Color[x * y];

            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = color;
            }
            tex.SetPixels(pix);
            tex.Apply();
            return tex;
        }
    }
}
