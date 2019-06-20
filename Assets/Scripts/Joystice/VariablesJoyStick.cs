using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace AJoys
{
    public class VariablesJoyStick : Joystick
    {
        public float MoveThreshold
        {
            get { return moveThreshold; }
            set { moveThreshold = Mathf.Abs(value); }
        }
        [SerializeField]
        private float moveThreshold;
        [SerializeField]
        private JoyStickType joyStickType = JoyStickType.Fixed;
        private Vector2 fixedPosition = Vector2.zero;



        public void SetMode(JoyStickType joyStickType)
        {
            this.joyStickType = joyStickType;
            if (joyStickType == JoyStickType.Fixed)

            {
                background.anchoredPosition = fixedPosition;
                background.gameObject.SetActive(true);
            }
            else
            {
                background.gameObject.SetActive(false);
            }
        }

        protected override void Start()
        {
            base.Start();
            fixedPosition = background.anchoredPosition;
            SetMode(joyStickType);
        }
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (joyStickType != JoyStickType.Fixed)
            {
                background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
                background.gameObject.SetActive(true);
                handle.anchoredPosition = Vector2.zero;
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (joyStickType != JoyStickType.Fixed)
            {

                background.gameObject.SetActive(false);
            }
        }
        protected override void HandleInput
           (float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            base.HandleInput(magnitude, normalised, radius, cam);
            if (joyStickType == JoyStickType.Dynamic && magnitude > moveThreshold)
            {
                Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
                background.anchoredPosition += difference;
            }
        }

        // Use this for initialization
        public enum JoyStickType
        { Fixed, Floating, Dynamic }

    }
}