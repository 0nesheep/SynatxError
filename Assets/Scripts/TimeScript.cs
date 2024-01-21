using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timerText; // Change Text to TextMeshProUGUI
    public float gameDurationInMinutes = 300f;
    public float timeScale = 60f;

    private float currentTime;

    void Start()
    {
        currentTime = gameDurationInMinutes * 60f;
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime * timeScale;

            int hours = Mathf.FloorToInt(currentTime / 3600f);
            int minutes = Mathf.FloorToInt((currentTime % 3600f) / 60f);
            //int seconds = Mathf.FloorToInt(currentTime % 60f);

            timerText.text = string.Format("{0:00}:{1:00}", hours, minutes);
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
}
