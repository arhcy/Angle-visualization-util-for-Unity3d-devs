using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Artics.Physics.UnityPhisicsVisualizers;

public class AngleCircle : Graphic
{
    const int Proximity = 180;

    public Text[] Values;

    public Image Arrow1;
    public Image Arrow2;

    public float Angle1;
    public float Angle2;

    protected override void Awake()
    {
        base.Awake();

        SetValuesText();
        //InitMaterial();
    }

    [ContextMenu("InitValues")]
    protected void InitValues()
    {
        bool checkValues = NeedValuesUpdate();

        if (checkValues)
        {
            if (Values != null)
                foreach (var text in Values)
                {
                    if (text != null)
                        DestroyImmediate(text);
                }

            Values = new Text[8];

            for (int i = 0; i < 8; i++)
            {
                GameObject tmpGo = new GameObject();
                tmpGo.transform.SetParent(this.transform);

                Values[i] = tmpGo.AddComponent<Text>();
            }
        }
    }

    protected bool NeedValuesUpdate()
    {
        if (Values == null || Values.Length < 8)
        {
            return true;
        }

        for (int i = 0; i < Values.Length; i++)
            if (Values == null)
                return true;

        return false;
    }


    protected void InitMaterial()
    {
        //if (materialForRendering == null)
        {
            material = new Material(Shader.Find("UI/Default"));
        }
    }


    protected override void OnPopulateMesh(VertexHelper vh)
    {
        Vector2[] points = null;
        Mesh mesh = new Mesh();

        var rect = rectTransform.rect;

        Collider2dPointsGetter.GetCircleCoordinates(rect.center, CalcRadius(), ref points, Proximity);
        //Collider2dPointsGetter.GetCircleCoordinates(rectTransform.anchoredPosition, 1f, ref points, Proximity);

        float ppu = (Camera.main.orthographicSize * 2) / Screen.height * 300;

        PolygonTriangulator.TriangulateAsLine(points, mesh, ppu, true);

        vh.Clear();

        for (int i = 0; i < mesh.vertices.Length; i++)
            vh.AddVert(mesh.vertices[i], new Color32(1, 1, 1, 1), new Vector2(0.5f, 0.5f));

        for (int i = 0; i < mesh.triangles.Length; i += 3)
            vh.AddTriangle(mesh.triangles[i], mesh.triangles[i + 1], mesh.triangles[i + 2]);
    }

    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
        base.SetVerticesDirty();

        SetValuesPositions();
        SetValuesSize();
        UpdateAnglesArrows();
    }

    protected float CalcRadius()
    {
        var rect = rectTransform.rect;
        return Mathf.Min(rect.width, rect.height) * 0.4f;
    }

    protected float GetAngleDegreebyID(int id)
    {
        return ((id % 4 + 1) * 45) * (id / 4 == 0 ? 1 : -1);
    }

    protected void SetValuesPositions()
    {
        var rect = rectTransform.rect;
        Vector2 center = rect.center;
        float radius = CalcRadius();


        for (int i = 0; i < 7; i++)
        {
            var angle = GetAngleDegreebyID(i) * Mathf.Deg2Rad;

            Values[i].rectTransform.anchoredPosition = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
        }

        Values[7].rectTransform.anchoredPosition = center + new Vector2(Mathf.Cos(0), Mathf.Sin(0)) * radius;
    }

    protected void SetValuesSize()
    {
        float size = CalcRadius() * 0.12f;

        foreach (var text in Values)
        {
            text.fontSize = (int)size;
            text.rectTransform.sizeDelta = new Vector2(600, text.rectTransform.sizeDelta.y);
        }
    }

    [ContextMenu("Update text")]
    protected void SetValuesText()
    {
        for (int i = 0; i < 7; i++)
        {
            float degrees = GetAngleDegreebyID(i);

            Values[i].text = degrees + "°\n" + System.Math.Round(degrees * Mathf.Deg2Rad, 2);
        }

        Values[7].text = "0";
    }


    public void UpdateAnglesArrows()
    {
        float radius = CalcRadius();
        Arrow1.rectTransform.sizeDelta = new Vector2(radius, radius * 0.02f);
        Arrow2.rectTransform.sizeDelta = new Vector2(radius, radius * 0.02f);
    }


}
