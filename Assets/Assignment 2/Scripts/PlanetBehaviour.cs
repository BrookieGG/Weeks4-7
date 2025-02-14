using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetBehaviour : MonoBehaviour
{
    public Button spawn;
    public Slider speedSlider;
    public Slider sizeSlider;
    public SpriteRenderer renderer;
    public SpriteRenderer preview;
    public TMP_Dropdown dropdown;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        spawn.onClick.AddListener(Spawn);
        speedSlider.onValueChanged.AddListener(delegate { SetSpeed(); });
        sizeSlider.onValueChanged.AddListener(delegate { SetSize(); });
        sizeSlider.minValue = 0f;
        sizeSlider.maxValue = 10f;
        size = sizeSlider.value;
        size = 130f;
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn planet onto the map
    void Spawn()
    {
        renderer.sprite = dropdown.options[dropdown.value].image;
        renderer.transform.position = new Vector3(0,0,0);
    }

    //Changes the speed of the planet
    void SetSpeed()
    {

    }

    //Changes the size of the planet
    void SetSize()
    {
        size = sizeSlider.value + 100f;
        float scale = size / 100f;
        renderer.size = new Vector2(size, size);
        preview.transform.localScale = new Vector2(scale * 10 , scale * 10 );
        
        

    }

}
