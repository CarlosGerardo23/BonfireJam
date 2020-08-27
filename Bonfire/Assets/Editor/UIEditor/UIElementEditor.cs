using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(UIElement), true)]
public class UIElementEditor : Editor
{

    UIElement myTarget;
    private void OnEnable()
    {
        myTarget = (UIElement)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        myTarget.uiName = myTarget.transform.name;
        myTarget.uiName = EditorGUILayout.TextField("Name", myTarget.uiName);
        myTarget.haveAnimation = EditorGUILayout.Toggle("Have exit animation", myTarget.haveAnimation);
        if (!myTarget.haveAnimation)
            return;
        myTarget.animator = (Animator)EditorGUILayout.ObjectField("Animator", myTarget.animator, typeof(Animator), true);
        myTarget.hideAnimation = EditorGUILayout.TextField("Exit Animation", myTarget.hideAnimation);
    }
}
