using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using AnglePair = System.Collections.Generic.KeyValuePair<UnityEngine.UI.InputField, UnityEngine.UI.InputField>;


public class AVACore : MonoBehaviour
{
    public InputField InputDeg1;
    public InputField InputRad1;
    public InputField InputDeg2;
    public InputField InputRad2;

    public AngleCircle Circle;

    protected KeyValuePair<InputField, InputField>[] InputAnglePairs;
    protected Image[] Arrows;

    // Use this for initialization
    void Start()
    {
        Arrows = new[] { Circle.Arrow1, Circle.Arrow2 };

        InputAnglePairs = new[] { new AnglePair(InputDeg1, InputRad1), new AnglePair(InputDeg2, InputRad2) };

        for (int i = 0; i < 2; i++)
        {
            int id = i;

            InputAnglePairs[i].Key.onEndEdit.AddListener(s => OnDegreeInput(id, s));
            InputAnglePairs[i].Value.onEndEdit.AddListener(s => OnRadiansInput(id, s));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnDegreeInput(int id, string value)
    {
        float floatValue = 0;
        float.TryParse(value, out floatValue);

        InputAnglePairs[id].Value.text = (floatValue * Mathf.Deg2Rad).ToString();
        Arrows[id].rectTransform.localRotation = Quaternion.Euler(0, 0, floatValue);
    }

    protected void OnRadiansInput(int id, string value)
    {
        float floatValue = 0;
        float.TryParse(value, out floatValue);
        floatValue *= Mathf.Rad2Deg;

        InputAnglePairs[id].Key.text = (floatValue).ToString();
        Arrows[id].rectTransform.localRotation = Quaternion.Euler(0, 0, floatValue);
    }
}


