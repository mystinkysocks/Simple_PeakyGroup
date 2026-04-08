using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour, IService
{
    [SerializeField] private GridProperties props;

    private List<CellComponent> cells = new List<CellComponent>();

    private void Start()
    {
        ServiceLocator.Instance.Register(this);
    }
    public IEnumerator Init()
    {
        BuildGrid();
        yield return new WaitForEndOfFrame();
    }
    public void BuildGrid()
    {
        if (!ServiceLocator.Instance.TryGet(out SaveManager save))
            return;

        float size = props.CellPrefab.Size;
        float stepX = size + props.Spacing.x;
        float stepY = size + props.Spacing.y;

        for (int x = 0; x < props.Width; x++)
        {
            for (int y = 0; y < props.Height; y++)
            {
                Vector3 pos = transform.position + new Vector3(props.Padding.x + x * stepX, 0, props.Padding.y + y * stepY);

                var cell = Instantiate(props.CellPrefab, pos, Quaternion.identity, transform);
                cell.Init(save.GetCellEntryById($"{x}_{y}"));
                cells.Add(cell);
            }
        }
    }

    public void RebuildGrid()
    {
        for (int i = 0; i < cells.Count; i++)
            cells[i].DeInit();

        cells.Clear();

        BuildGrid();
    }
    private void OnDrawGizmos()
    {
        if (props == null)
            return;

        Gizmos.color = Color.green;

        float size = props.CellPrefab.Size;
        float stepX = size + props.Spacing.x;
        float stepY = size + props.Spacing.y;

        for (int x = 0; x < props.Width; x++)
        {
            for (int y = 0; y < props.Height; y++)
            {
                Vector3 pos = transform.position + new Vector3(props.Padding.x + x * stepX, 0, props.Padding.y + y * stepY);

                Gizmos.DrawWireCube(pos, new Vector3(size, 0.01f, size));
            }
        }
    }
}