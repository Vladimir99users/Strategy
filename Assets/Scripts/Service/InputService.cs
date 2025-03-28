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

        private void OnDisable()
        {
            inputScheme.Player.Click.performed -= PlayerMove;
            inputScheme.Camera.Move.performed -= CameraMove;
        }
        private void PlayerMove(InputAction.CallbackContext obj)
        {
            var positionClick = inputScheme.Player.PositionMouse.ReadValue<Vector2>();
            if (!IsUI(positionClick))
            {
                Debug.Log($"Mouse position = {positionClick}");
                OnPlayerMoved?.Invoke(positionClick);
            }
        }

#if UNITY_ANDROID
        private void CameraMove(InputAction.CallbackContext obj)
        {
            var positionClick = inputScheme.Player.PositionMouse.ReadValue<Vector2>();
            if (!IsUI(positionClick))
            {
                Debug.Log($"Mouse position = {obj.ReadValue<Vector2>()}");
                OnCameraMoved?.Invoke(obj.ReadValue<Vector2>());
            }
        }
#else
        private void CameraMove(InputAction.CallbackContext obj)
        {
            Debug.Log($"Mouse position = {obj.ReadValue<Vector2>()}");
            OnCameraMoved?.Invoke(obj.ReadValue<Vector2>());
        }
#endif
        private bool IsUI(Vector2 vector)
        {
            var pointerData = new PointerEventData(EventSystem.current) { position = vector };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            return results.Count > 0;
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
