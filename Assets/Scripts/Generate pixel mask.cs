using UnityEngine;

public class GeneratePixelMask : MonoBehaviour
{
    public Material fadeMaterial; // Assign your PixelFade material here
    public int resolution = 64;

    void Start()
    {
        Texture2D mask = GenerateMask(resolution);
        mask.filterMode = FilterMode.Point;
        mask.wrapMode = TextureWrapMode.Clamp;
        fadeMaterial.SetTexture("_MaskTex", mask);
    }

    Texture2D GenerateMask(int size)
    {
        Texture2D texture = new Texture2D(size, size, TextureFormat.RFloat, false);
        float[,] values = new float[size, size];

        // Fill with random grayscale values
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float value = Random.Range(0f, 1f);
                values[x, y] = value;
                texture.SetPixel(x, y, new Color(value, value, value));
            }
        }

        texture.Apply();
        return texture;
    }
}
