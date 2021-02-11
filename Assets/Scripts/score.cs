using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text points;
    public float time;
    public AnimationCurve koef;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        points.text ="Score : " + ((int)(time*koef.Evaluate(time))).ToString();
    }
}
