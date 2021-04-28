using UnityEngine;

[RequireComponent(typeof(Block))]
public class LookAtBlockEffect : MonoBehaviour
{
    [SerializeField] private Block block;
    public void CallBreak()
    {
        block.Break();
    }
}