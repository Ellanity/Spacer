using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text points;
    private float time = 0;
    [SerializeField]
    private AnimationCurve koef;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        points.text ="Score : " + ((int)(time*koef.Evaluate(time))).ToString();
    }
}
