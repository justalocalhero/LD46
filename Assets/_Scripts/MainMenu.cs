using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float frameTime;
    private int currentFrame = 0;
    public float frameTimer;
    public Sprite[] menuFrames;
    public SpriteRenderer spriteRender;
    public AudioSource audioSource;
    public AudioClip clip0, clip1, clip2;
    private void Update()
    {
        frameTimer -= Time.deltaTime;

        if (frameTimer <= 0)
        {
            frameTimer += frameTime;

            if ((currentFrame + 1) >= menuFrames.Length)
            {
                SceneManager.LoadScene("Main");
                return;
            }

            if (currentFrame == 0)
            {
                audioSource.clip = clip0;
                audioSource.Play();
            }
            if (currentFrame == 1)
            {
                audioSource.clip = clip1;
                audioSource.Play();
            }
            if (currentFrame == 2)
            {
                audioSource.clip = clip2;
                audioSource.Play();
            }
            spriteRender.sprite = menuFrames[++currentFrame];
        }
        
    }
}
