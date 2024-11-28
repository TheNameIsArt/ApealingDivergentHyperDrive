using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(HighscoreManager))]

public class CostomScoreInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        HighscoreManager manager = (HighscoreManager)target;
        if(GUILayout.Button("Reset Highscore"))
        {
            manager.ResetHighscore();
        }
    }
}
