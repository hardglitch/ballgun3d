using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private Block block; 
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int towerSize;
        [SerializeField] private float distanceBetweenBlocks = 0.15f;

        public float DistanceBetweenBlocks { get; private set; }
        private List<Block> blocks;

        private void Start()
        {
            DistanceBetweenBlocks = distanceBetweenBlocks;
        }

        public List<Block> BuildTower()
        {
            blocks = new List<Block>();
            var currentBuildPoint = spawnPoint;

            for (var i = 0; i < towerSize; i++)
            {
                var newBlock = BuildBlock(currentBuildPoint);
                blocks.Add(newBlock);
                currentBuildPoint = newBlock.transform;
            }

            return blocks;
        }

        private Block BuildBlock(Transform currentBuildPoint)
        {
            return Instantiate(
                block,
                GetCurrentBuildPointPosition(currentBuildPoint),
                Quaternion.Euler(90,0,0),
                spawnPoint);
        }

        private Vector3 GetCurrentBuildPointPosition(Transform currentBlock)
        {
            return new Vector3(
                spawnPoint.position.x,
                currentBlock.position.y + distanceBetweenBlocks,
                spawnPoint.position.z);
        }
    }
}
