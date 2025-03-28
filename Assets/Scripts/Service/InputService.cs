using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Service
{
    public class InputService : MonoBehaviour, IPlayerController, ICameraController
    {
        public event Action<Vector2> OnPlayerMoved;
        public event Action<Vector2> OnCameraMoved;
        private InputSystem_Actions inputScheme;
        public void Initialize()
        {
            OnInitialize();
        }

        protected void OnInitialize()
        {
            inputScheme = new InputSystem_Actions();
            inputScheme.Enable();

            inputScheme.Player.Click.performed += PlayerMove;
            inputScheme.Camera.Move.performed += CameraMove;
        }
        private void PlayerMove(InputAction.CallbackContext obj)
        {

            var pointerData = new PointerEventData(EventSystem.current)
            {
                position = inputScheme.Player.PositionMouse.ReadValue<Vector2>()
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            if (results.Count == 0)
            {
                Debug.Log($"Mouse position = {inputScheme.Player.PositionMouse.ReadValue<Vector2>()}");
                OnPlayerMoved?.Invoke(inputScheme.Player.PositionMouse.ReadValue<Vector2>());
            }
        }
        private void CameraMove(InputAction.CallbackContext obj)
        {
            Debug.Log($"Mouse position = {obj.ReadValue<Vector2>()}");
            OnCameraMoved?.Invoke(obj.ReadValue<Vector2>());
        }


    }

    public interface IPlayerController
    {
        public event System.Action<Vector2> OnPlayerMoved;
    }

    public interface ICameraController
    {
        public event System.Action<Vector2> OnCameraMoved;
    }
}
