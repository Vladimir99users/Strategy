using UnityEngine;

namespace Assets.Scripts.Service
{
    public class SpawnPlayerService : MonoBehaviour
    {
        [SerializeField] private Player.Player playerPrefabs;
        [SerializeField] private Transform transformPoint;

        private Player.Player player;
        public Player.Player Player => player;
        public void Initialize(IPlayerController controller)
        {
            SpawnPlayer(controller);
        }

        private void SpawnPlayer(IPlayerController controller)
        {
            player = Instantiate(playerPrefabs, transformPoint.position, Quaternion.identity);
            player.Initialize(controller);
        }
    }
}
