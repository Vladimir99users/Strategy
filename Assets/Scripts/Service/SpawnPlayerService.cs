using UnityEngine;

namespace Assets.Scripts.Service
{
    public class SpawnPlayerService : MonoBehaviour
    {
        [SerializeField] private Player.Player playerPrefabs;
        [SerializeField] private Transform transformPoint;

        private Player.Player player;
        public Player.Player Player => player;
        public void Initialize()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            player = Instantiate(playerPrefabs, transformPoint.position, Quaternion.identity);
            player.Initialize();
        }
    }
}
