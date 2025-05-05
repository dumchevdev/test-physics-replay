using System;
using UnityEngine;

namespace Game
{
    internal sealed class InputSystem
    {
        internal event Action<float> OnMove;
        internal event Action OnJump;
        public event Action OnSpeedBoost;
        public event Action OnColorUpdated;
        public event Action OnCloneCreated;
        
        internal void OnUpdate()
        {
            ProcessAxisInput(Constance.Inputs.HorizontalAxis, OnMove);
            ProcessButtonPress(Constance.Inputs.JumpAxis, OnJump);
            ProcessButtonPress(Constance.Inputs.SpeedBoostKey, OnSpeedBoost);
            ProcessButtonPress(Constance.Inputs.ColorUpdatedKey, OnColorUpdated);
            ProcessButtonPress(Constance.Inputs.CloneCreationKey, OnCloneCreated);
        }
        
        private void ProcessAxisInput(string axisName, Action<float> eventAction)
        {
            float axisValue = Input.GetAxis(axisName);
            if (Mathf.Abs(axisValue) > 0.01f)
            {
                eventAction?.Invoke(axisValue);
            }
        }

        private void ProcessButtonPress(string buttonName, Action eventAction)
        {
            if (Input.GetButtonDown(buttonName))
            {
                eventAction?.Invoke();
            }
        }
        
        private void ProcessButtonPress(KeyCode keyCode, Action eventAction)
        {
            if (Input.GetKeyDown(keyCode))
            {
                eventAction?.Invoke();
            }
        }
    }
}