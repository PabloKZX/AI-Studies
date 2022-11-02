using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingEntity))]
public class MovingEntityEditor : Editor
{
    private Editor editor = null;
    bool showSteeringBehaviour;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var movingEntity = target as MovingEntity;
        var steeringBehaviour = movingEntity.steeringBehaviour;

        if(steeringBehaviour == null)
        {
            return;
        }

        showSteeringBehaviour = EditorGUILayout.Foldout(showSteeringBehaviour, "Steering Behaviour");
        if(showSteeringBehaviour)
        {
            EditorGUI.indentLevel++;

            if(!editor)
            {
                Editor.CreateCachedEditor(steeringBehaviour, null, ref editor);
            }

            editor.OnInspectorGUI();
            EditorGUI.indentLevel--;
        }
    }
}
