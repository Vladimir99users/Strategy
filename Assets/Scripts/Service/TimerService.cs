using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public class TimerService : MonoBehaviour, ISecondElapsedNotifier
    {
        public event System.Action OnSecondEnd;
        private Coroutine timerCoroutine;
        internal void Initialize()
        {
            if (timerCoroutine is not null)
                StopCoroutine(timerCoroutine);

            timerCoroutine = StartCoroutine(TimerStart());
        }

        private IEnumerator TimerStart()
        {
            var time = 0f;
            while (true)
            {
                time += Time.deltaTime;
                if (time > 1f)
                {
                    time = 0;
                    OnSecondEnd?.Invoke();
                    Debug.Log("Second is end");
                }

                yield return null;
            }
        }
    }

    public interface ISecondElapsedNotifier
    {
        public event System.Action OnSecondEnd;
    }
}
