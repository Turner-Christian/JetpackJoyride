using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed;

    [SerializeField]
    private Renderer bgRenderer; // Reference to the background renderer

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0); // Scroll the background texture
    }
}
