using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace AJoys
{
    [CustomEditor(typeof(Joystick), true)]
    public class JoyStickEditor : Editor
    {
        private SerializedProperty handleRange;
        private SerializedProperty deadZone;
        private SerializedProperty axiesOption;
        private SerializedProperty snapX;
        private SerializedProperty snapY;
        protected SerializedProperty background;
        private SerializedProperty handle;

        protected Vector2 center = new Vector2(0.5f, 0.5f);

        protected virtual void OnEnable()
        {
            handleRange = serializedObject.FindProperty("handleRange");
            deadZone = serializedObject.FindProperty("deadZone");
            axiesOption = serializedObject.FindProperty("axiesOption");
            snapX = serializedObject.FindProperty("snapX");
            snapY = serializedObject.FindProperty("snapY");
            background = serializedObject.FindProperty("background");
            handle = serializedObject.FindProperty("handle");
        }
        protected virtual void DrawValues()
        {
            EditorGUILayout.PropertyField(handleRange, new GUIContent("handleRange", "The distance the virtul handle can move from the center of the joystick"));
            EditorGUILayout.PropertyField(deadZone, new GUIContent("deadZone", "The distance away from the center input has to before registering"));
            EditorGUILayout.PropertyField(axiesOption, new GUIContent("axiesOption", "Which axes the joystick use"));
            EditorGUILayout.PropertyField(snapX, new GUIContent("snapX", "Snap the Horizontal input to a whole Value"));
            EditorGUILayout.PropertyField(snapY, new GUIContent("snapY", "Snap the Vertical input to a whole Value"));
        }
        protected virtual void DrawComponents()
        {
            EditorGUILayout.ObjectField(background, new GUIContent("BackGround", "the backGround's rectTransfrom componenet"));
            EditorGUILayout.ObjectField(handle, new GUIContent("Handle", "The Handle's RectTransfrom component"));
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.Space();
            DrawComponents();
            serializedObject.ApplyModifiedProperties();
            if(handle != null)
            {
                RectTransform handleRect = (RectTransform)handle.objectReferenceValue;
                handleRect.anchorMax = center;
                handleRect.anchorMin = center;
                handleRect.pivot = center;
                handleRect.anchoredPosition = Vector2.zero;
            }
        }
    }
}