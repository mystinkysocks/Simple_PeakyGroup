using UnityEngine;

[CreateAssetMenu(fileName ="Grid_", menuName ="SO/Grid")]
public class GridProperties : ScriptableObject
{
    [field: Header("Properties")]
    [field: SerializeField] public CellComponent CellPrefab { get; private set; }
    [field: SerializeField] public int Width { get; private set; } = 5;
    [field: SerializeField] public int Height { get; private set; } = 5;
    [field: Header("Spacing")]
    [field: SerializeField] public Vector2 Spacing { get; private set; }
    [field: SerializeField] public Vector2 Padding { get; private set; }
}