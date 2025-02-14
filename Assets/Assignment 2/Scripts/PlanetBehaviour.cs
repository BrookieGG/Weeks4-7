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
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        spawn.onClick.AddListener(Spawn);
        speedSlider.onValueChanged.AddListener(delegate { SetSpeed(); });
        sizeSlider.onValueChanged.AddListener(delegate { SetSize(); });

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
        renderer.transform.localScale = new Vector3(sizeSlider.value,  sizeSlider.value, sizeSlider.value);
    }

}
