using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace AJoys
{
    public class VariablesJoyStickEditor : JoyStickEditor
    {
        private SerializedProperty moveThershold;
        private SerializedProperty joystickType;

        protected override void OnEnable()
        {
            base.OnEnable();
            moveThershold = serializedObject.FindProperty("moveThreshold");
            joystickType = serializedObject.FindProperty("joyStickType");
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (background != null)
            {
                RectTransform backGroundRect = (RectTransform)
                    background.objectReferenceValue;
                backGroundRect.pivot = center;
            }
        }

        protected override void DrawValues()
        {
            base.DrawValues();
            EditorGUILayout.PropertyField(moveThershold, new GUIContent("moveThershold", "the distance away from the center input has to before the joystick beging to move"));
            EditorGUILayout.PropertyField(joystickType, new GUIContent("joyStickType", "the type of joystick the variable joyStick is curent using"));
        }


    }
}