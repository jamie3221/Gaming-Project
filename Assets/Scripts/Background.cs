using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorAnimator : MonoBehaviour
{
    public Color[] colors;
    public float duration = 2f;

    private Image panel;
    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        panel = GetComponent<Image>();
        if (colors.Length > 0)
            panel.color = colors[0];
    }

    void Update()
    {
        if (colors.Length < 2) return;

        timer += Time.deltaTime;
        float t = timer / duration;

        panel.color = Color.Lerp(colors[currentIndex], colors[(currentIndex + 1) % colors.Length], t);

        if (t >= 1f)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % colors.Length;
        }
    }
}
