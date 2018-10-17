using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TowerRange : MonoBehaviour
{
    public int segments = 50;
    public Color Color;

    private Tower tower;
    private float radius;
    private LineRenderer line;

    private void Awake()
    {
        tower = GetComponent<Tower>();
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.material.color = Color;
        radius = tower.GetTowerRange() / 2;
        CreatePoints();
    }

    private void Update()
    {
        radius = tower.GetTowerRange() / 2;

        if (tower.towerRangeOn)
        {
            CreatePoints();
        }
        else
        {
            DestroyPoints();
        }
    }

    public void CreatePoints()
    {
        float x;
        float z;

        float change = 2 * Mathf.PI / segments;
        float angle = change;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(angle) * radius;
            z = Mathf.Cos(angle) * radius;

            line.SetPosition(i, new Vector3(x, -0.49f, z));

            angle += change;
        }
    }

    public void DestroyPoints()
    {
        for (int i = 0; i < (segments + 1); i++)
        {
            line.SetPosition(i, new Vector3(0.0f, 0.0f, 0.0f));
        }
    }
}
