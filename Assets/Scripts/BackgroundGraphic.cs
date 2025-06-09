using UnityEngine;
using UnityEngine.UI;
public class BackgroundGraphic : MonoBehaviour
{
    public Image imagecomponent;
    public Sprite[] bgframes;
    public float framesPerSecond = 10f;
    private int currentFrame = 0;
    private float timer;
    void Update()
    {
        if (bgframes.Length == 0)
            return;
        timer += Time.deltaTime;
        if (timer >= 1f / framesPerSecond)
        {
            currentFrame = (currentFrame + 1) % bgframes.Length;
            imagecomponent.sprite = bgframes[currentFrame];
            timer = 0f;
        }
    }

}
