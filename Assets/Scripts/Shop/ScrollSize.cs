using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSize : MonoBehaviour
{
    private RectTransform _cur => GetComponent<RectTransform>();
    private void Start() {
        if (Camera.main.aspect >= 0.55)
            _cur.sizeDelta = _cur.sizeDelta;
        else 
            _cur.sizeDelta = _cur.sizeDelta + new Vector2(0, 177);
    }
}
