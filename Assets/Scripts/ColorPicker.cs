using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    private Color coll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateSP(TMP_InputField _textObj)
    {
        UpdateSP(_textObj.text);
    }
    public void UpdateSP(string _hex)
    {

        if (_hex.StartsWith("#")) _hex = _hex.Substring(1, _hex.Length - 1);
        for (int i = 0; i < _hex.Length; i++)
        {
            if (_hex[i] == 32)
            {
               _hex = _hex.Remove(i);
            }
        }
        for (int i = 0; i < _hex.Length; i++)
        {
            bool valid = true;
            int hexVal = _hex[i];
            if (!(hexVal >= 65 && hexVal <= 70))
            {
                if (!(hexVal >= 97 && hexVal <= 102))
                {
                    if (!(hexVal >= 48 && hexVal <= 57))
                    {
                        valid = false;
                    }
                }
            }
            if(valid == false)
            {
                UpdateSP(0,0,0);

                return;
            }
        }
        int r = _hex.Length >= 2 ? Convert.ToInt32(_hex.Substring(0, 2), 16) : 0;
        int g = _hex.Length >= 4 ? Convert.ToInt32(_hex.Substring(2, 2), 16) : 0;
        int b = _hex.Length >= 6 ? Convert.ToInt32(_hex.Substring(4, 2), 16) : 0;

        UpdateSP(r, g, b);
    }
    public void UpdateSP(int _r, int _g, int _b)
    {
        UpdateSP(new Color(_r / 255.0f, _g / 255.0f, _b / 255.0f, 1.0f));
    }
    public void UpdateSP(Color _coll)
    {
        sp.color = _coll;
    }

   
}
