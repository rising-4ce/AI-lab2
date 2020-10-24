using UnityEngine;

namespace Assets.Scripts.AI.Areas
{
    public class Area : MonoBehaviour
    {
        private GameObject Player;
        public int N;
        public GameObject[] WaypointsToNeighbors;
        private CurrentAreaContainer CurrentAreaContainer;
        public Area[] Neighbors;

        private void Start()
        {
            CurrentAreaContainer = transform.parent.GetComponent<CurrentAreaContainer>();
            Player = CurrentAreaContainer.Player;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Player == other.gameObject)
            {
                CurrentAreaContainer.current = this;
                Debug.Log($"Area changed to {N}");
            }
        }
    }
}
