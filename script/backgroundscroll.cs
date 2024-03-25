using UnityEngine;

public class backgroundscroll : MonoBehaviour
{

    public float speed = 0.5f;
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * speed;
        _renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}