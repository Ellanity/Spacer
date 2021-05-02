using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text points;
    public int _Score = 0;
    private float time = 0;
    [SerializeField]
    private AnimationCurve koef;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        _Score = (int)(time * koef.Evaluate(time));
        points.text ="Score : " + _Score.ToString();
    }
}
