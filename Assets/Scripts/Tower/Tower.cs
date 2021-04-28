using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tower
{
    [RequireComponent(typeof(TowerBuilder))]
    public class Tower : MonoBehaviour
    {
        private TowerBuilder towerBuilder;
        private List<Block> blocks;

        public event UnityAction<int> GetBlocks;
        
        private void Start()
        {
            towerBuilder = GetComponent<TowerBuilder>();
            blocks = towerBuilder.BuildTower();

            foreach (var block in blocks)
            {
                block.BulletHit += OnBulletHit;
            }
            
            GetBlocks?.Invoke(blocks.Count);
        }

        private void OnBulletHit(Block hitBlock)
        {
            hitBlock.BulletHit -= OnBulletHit;
            blocks.Remove(hitBlock);

            foreach (var block in blocks)
            {
                block.transform.position = new Vector3(
                    block.transform.position.x,
                    block.transform.position.y - towerBuilder.DistanceBetweenBlocks,
                    block.transform.position.z);
            }
            GetBlocks?.Invoke(blocks.Count);
        }
    }
}
