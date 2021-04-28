using System;
using UnityEngine;
using TMPro;

public class BlocksUI : MonoBehaviour
{
    [SerializeField] private Tower.Tower tower;
    [SerializeField] private TMP_Text blocksUI;

    private void OnEnable()
    {
        tower.GetBlocks += OnGetBlocks;
    }

    private void OnDisable()
    {
        tower.GetBlocks -= OnGetBlocks;
    }

    private void OnGetBlocks(int blocks)
    {
        blocksUI.text = blocks.ToString();
    }
}
