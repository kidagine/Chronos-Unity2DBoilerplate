using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    private float _duration;

	public bool TimerEnded { get; private set; }

	void Update()
    {
        Debug.Log("2");

        _duration -= Time.deltaTime;
        if (_duration <= 0)
        {
            TimerEnded = true;
        }
    }

    public void StartTimer(float duration)
    {
        Debug.Log("1");
        TimerEnded = false;
        _duration = duration;
    }
}
