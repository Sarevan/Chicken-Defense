using UnityEditor;
using UnityEngine;

namespace Gameplay.Hero
{
    [CustomEditor(typeof(FireZone))]
    public class CustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            FireZone exam = (FireZone) target;
            if (GUILayout.Button("Start"))
            {
                exam.Start();
            }
        }
    }
}