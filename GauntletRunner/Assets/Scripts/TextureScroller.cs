using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public float speed = .5f;

    private Renderer _renderer;

    private float _offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _offset += Time.deltaTime * speed;

        if (_offset > 1)
        {
            _offset -= 1;
        }
        _renderer.material.mainTextureOffset = new Vector2(0, _offset);
    }
}
