using UnityEngine;

namespace Assets.Scripts.Service
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Screen : MonoBehaviour
    {
        private CanvasGroup group;

        public bool IsOpen => group.interactable;
        private void Awake()
            => OnAwake();

        private void OnAwake()
        {
            group = GetComponent<CanvasGroup>();
        }

        public virtual void Open()
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
            group.interactable = true;
        }

        public virtual void Close()
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            group.interactable = false;
        }
    }
}