using UnityEngine;

public class RibbonColors
{
    public static readonly Color[] AllAvailableColors = {Color.yellow, Color.black, Color.cyan, Color.magenta,};
    
    public static Color PickUpRandomColor()
    {
        return AllAvailableColors[Random.Range(0, AllAvailableColors.Length)];
    } 
    
}