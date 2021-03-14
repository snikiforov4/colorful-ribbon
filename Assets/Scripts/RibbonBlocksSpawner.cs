using System.Collections.Generic;
using UnityEngine;

public class RibbonBlocksSpawner : MonoBehaviour
{
    [SerializeField] private Transform ribbonCenter;
    [SerializeField] private GameObject blockPrefab;
    private const float BlockSize = 1;

    private Vector3 _ribbonCenterPosition;
    private LinkedList<SpawnedRibbonBlock> _spawnedRibbonBlocks;

    private void Start()
    {
        _ribbonCenterPosition = ribbonCenter.position;
        _spawnedRibbonBlocks = new LinkedList<SpawnedRibbonBlock>();
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        var cameraBounds = GetCameraBounds();
        Debug.Log($"left={cameraBounds.Left}, right={cameraBounds.Right}");
        float generateUntil = cameraBounds.Left - 3;
        float currentOffset = -BlockSize;
        while (currentOffset > generateUntil)
        {
            InstantiateBlock(new Vector3(_ribbonCenterPosition.x + currentOffset, _ribbonCenterPosition.y));
            currentOffset -= BlockSize;
        }
        
        generateUntil = cameraBounds.Right + 3;
        currentOffset = 0;
        while (currentOffset < generateUntil)
        {
            InstantiateBlock(new Vector3(_ribbonCenterPosition.x + currentOffset, _ribbonCenterPosition.y));
            currentOffset += BlockSize;
        }
    }

    private void InstantiateBlock(Vector3 blockPosition)
    {
        var randomColor = RibbonColors.PickUpRandomColor();
        var newBlock = Instantiate(blockPrefab, blockPosition, Quaternion.identity);
        newBlock.GetComponent<SpriteRenderer>().color = randomColor;
        // todo not all blocks add first
        _spawnedRibbonBlocks.AddFirst(new SpawnedRibbonBlock(randomColor, newBlock));
    }

    private CameraBounds GetCameraBounds()
    {
        var verticalUnits = Camera.main.orthographicSize;
        var screenAspect = (float)Screen.width / Screen.height;
        var horizontalUnits = verticalUnits * screenAspect;

        return new CameraBounds(-horizontalUnits, horizontalUnits);
    }

    private readonly struct CameraBounds
    {
        public float Left { get; }
        public float Right { get; }

        public CameraBounds(float left, float right)
        {
            Left = left;
            Right = right;
        }
    }
}