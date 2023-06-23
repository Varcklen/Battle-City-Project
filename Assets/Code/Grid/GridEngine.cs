using UnityEngine;
using UnityEditor;

/// <summary>
/// A class for an editor that hooks objects to an integer position.
/// </summary>
[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
#if UNITY_EDITOR
    Grid grid;
    void OnEnable() { EditorApplication.update += Update; }
    void OnDisable() { EditorApplication.update -= Update; }

    //[MenuItem("Custom\\Grid")]
    public static void Init()
    {
        new GameObject("Code\\Grid", typeof(Grid));
    }

    void Update()
    {
        grid = (Grid)target;

        if (grid.Active)
        {
            foreach (var obj in Selection.objects)
            {
                Vector3 pos = (obj as GameObject).transform.position;
                float x = Mathf.CeilToInt(pos.x / grid.Width) * grid.Width;
                float y = Mathf.CeilToInt(pos.y / grid.Height) * grid.Height;
                float z = pos.z;
                (obj as GameObject).transform.position = new Vector3(x, y, z);
            }
        }
    }
#endif
}