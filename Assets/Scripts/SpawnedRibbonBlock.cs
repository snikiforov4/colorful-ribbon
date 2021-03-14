using UnityEngine;

public struct SpawnedRibbonBlock
{
    private Color _color;
    private GameObject _gameObject;

    public SpawnedRibbonBlock(Color color, GameObject gameObject)
    {
        _color = color;
        _gameObject = gameObject;
    }

    public Color Color => _color;

    public GameObject GameObject => _gameObject;
}