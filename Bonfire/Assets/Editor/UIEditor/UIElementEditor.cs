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
        myTarget.haveAnimation = EditorGUILayout.Toggle("Have animation", myTarget.haveAnimation);
        if (!myTarget.haveAnimation)
            return;
        if (myTarget.gameObject.GetComponent<Animator>() == null)
            myTarget.gameObject.AddComponent(typeof(Animator));
        myTarget.animator = myTarget.gameObject.GetComponent<Animator>();
        myTarget.hideAnimation = EditorGUILayout.TextField("Exit Animation", myTarget.hideAnimation);
      //  myTarget.player= (PlayerControls)EditorGUILayout.ObjectField("Control", myTarget.collection, typeof(SoundCollection), true);
    }
}
