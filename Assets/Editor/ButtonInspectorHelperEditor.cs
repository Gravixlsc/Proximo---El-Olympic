using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonInspector))]
class ButtonInspectorHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Post"))
            FindObjectOfType<Query>().Post();
    }
}
