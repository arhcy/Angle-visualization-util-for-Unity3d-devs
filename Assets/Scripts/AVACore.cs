using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Artics.Math;

using InputPair = System.Collections.Generic.KeyValuePair<UnityEngine.UI.InputField, UnityEngine.UI.InputField>;


public class AVACore : MonoBehaviour
{
    public InputField InputDeg1;
    public InputField InputRad1;
    public InputField InputDeg2;
    public InputField InputRad2;

    public InputField VectorX1;
    public InputField VectorY1;
    public InputField VectorX2;
    public InputField VectorY2;
    public Button Vector1Button;
    public Button Vector2Button;



    public AngleCircle Circle;

    public Text SinCos1;
    public Text SinCos2;
    public Text LongestAngle;
    public Text ShortestAngle;
    public Text Range180;
    public Text Range360;


    protected KeyValuePair<InputField, InputField>[] InputAnglePairs;
    protected KeyValuePair<InputField, InputField>[] InputVectorPairs;
    protected Image[] Arrows;
    protected Text[] SinCosValues;
    protected Text[] Period180;

    protected float[] Angles;

    // Use this for initialization
    void Start()
    {
        Angles = new float[2];

        Arrows = new[] { Circle.Arrow1, Circle.Arrow2 };
        SinCosValues = new[] { SinCos1, SinCos2 };

        InputAnglePairs = new[] { new InputPair(InputDeg1, InputRad1), new InputPair(InputDeg2, InputRad2) };

        for (int i = 0; i < 2; i++)
        {
            int id = i;

            InputAnglePairs[i].Key.onEndEdit.AddListener(s => OnDegreeInput(id, s));
            InputAnglePairs[i].Value.onEndEdit.AddListener(s => OnRadiansInput(id, s));
        }


        InputVectorPairs = new[] { new InputPair(VectorX1, VectorY1), new InputPair(VectorX2, VectorY2) };

        Vector1Button.onClick.AddListener(() => CalcVector(0));
        Vector2Button.onClick.AddListener(() => CalcVector(1));

        UpdateAngleValues(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnDegreeInput(int id, string value)
    {
        UpdateAngleValues(id, ParseFloat(value) * Mathf.Deg2Rad);
    }

    protected void OnRadiansInput(int id, string value)
    {
        UpdateAngleValues(id, ParseFloat(value));
    }

    protected void UpdateAngleValues(int id, float value)
    {
        Angles[id] = value;

        for (int i = 0; i < 2; i++)
        {
            RoatteArrow(i, Angles[i]);
            SetAngleInputFields(i, Angles[i]);
            SetSinCos(i, Angles[i]);
        }

        SetShortestAngle();
        SetPeriod180();
    }

    protected void RoatteArrow(int id, float value)
    {
        Arrows[id].rectTransform.localRotation = Quaternion.Euler(0, 0, value * Mathf.Rad2Deg);
    }

    protected void SetAngleInputFields(int id, float value)
    {
        InputAnglePairs[id].Key.text = Round(value * Mathf.Rad2Deg);
        InputAnglePairs[id].Value.text = Round(value);
    }

    protected void SetSinCos(int id, float value)
    {
        SinCosValues[id].text = "[Angle " + id + "] Sin:" + Round(Mathf.Sin(value)) + " Cos:" + Round(Mathf.Cos(value)) + " Tan:" + Round(Mathf.Tan(value));
    }

    protected void SetPeriod180()
    {
        Range180.text = "Range [-180; 180]: Angle1: " + Round(MathUtils.ConvertTo180Period2(Angles[0] * Mathf.Rad2Deg)) + "° Angle: " + Round(MathUtils.ConvertTo180Period2(Angles[1] * Mathf.Rad2Deg)) + "°";
    }

    protected void SetShortestAngle()
    {
        float angle = MathUtils.FindNearestAngle(MathUtils.ConvertTo180Period2(Angles[0] * Mathf.Rad2Deg), MathUtils.ConvertTo180Period2(Angles[1] * Mathf.Rad2Deg));
        ShortestAngle.text = "Shortest angle: [" + angle + "°] [" + Round(angle * Mathf.Deg2Rad) + "]";

        angle = (360 - Mathf.Abs(angle)) * -1 * MathUtils.GetSign(angle);
        LongestAngle.text = "Longest angle: [" + angle + "°] [" + Round(angle * Mathf.Deg2Rad) + "]";
    }

    protected void CalcVector(int id)
    {
        UpdateAngleValues(id, Mathf.Atan2(ParseFloat(InputVectorPairs[id].Value.text), ParseFloat(InputVectorPairs[id].Key.text)));
    }

    protected float ParseFloat(string value)
    {
        float floatValue = 0;
        float.TryParse(value, out floatValue);

        return floatValue;
    }

    protected string Round(float value)
    {
        //return value.ToString();
        return System.Math.Round(value, 3).ToString();
    }
}


