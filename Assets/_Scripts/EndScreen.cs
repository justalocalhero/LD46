using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public float timeout = .5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startOverText;

    private void Start()
    {
        int hazards = PlayerPrefs.GetInt("Score");
        string hazardString = (hazards > 1) ? hazards + " Hazards" : hazards + " Hazard";

        scoreText.SetText("Lost Familiar After " + hazardString);
    }
    private void Update()
    {
        if (timeout <= 0 && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Menu");
        }

        if (timeout <= 0) return;

        timeout -= Time.deltaTime;

        if (timeout <= 0)
        {
            startOverText.SetText("Click To Find Familiar\nOne Incense Remaining");
        }

    }
}
