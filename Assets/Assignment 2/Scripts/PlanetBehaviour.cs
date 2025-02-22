using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetBehaviour : MonoBehaviour
{
    //UI 
    public Button spawn;
    public Slider speedSlider;
    public Slider sizeSlider;
    public SpriteRenderer[] renderers;
    public SpriteRenderer preview;
    public TMP_Dropdown dropdown;

    public bool[] isActive;
    public float[] speeds;

    private float size;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawn.onClick.AddListener(Spawn);
        speedSlider.onValueChanged.AddListener(delegate { SetSpeed(); });
        sizeSlider.onValueChanged.AddListener(delegate { SetSize(); });
        sizeSlider.minValue = 130f;
        sizeSlider.maxValue = 260f;
        size = sizeSlider.value;
        index = 0;

        //Initialize arrays
        isActive = new bool[10];
        speeds = new float[10];

        SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            if (isActive[i])
            {
                //move planet to right based on speed
                Vector3 pos = renderers[i].transform.position;
                pos.x += (speeds[i] * Time.deltaTime);
                renderers[i].transform.position = pos;
                if (pos.x > 45f) //if off of the screen set active to false
                {
                    isActive[i] = false;
                }
            }
        }
    }

    //Spawn planet onto the map
    void Spawn()
    {
        SpriteRenderer renderer = renderers[index];
        //assign sprite from drop down
        renderer.sprite = dropdown.options[dropdown.value].image;
        //set position and scale
        renderer.transform.position = new Vector3(-45, Random.Range(-19f, 19f), 0);
        renderer.transform.localScale = new Vector2(size / 13, size / 13);

        //activate planet and set speed
        isActive[index] = true;
        speeds[index] = speedSlider.value;



        //move to the next renderer in the array and loop
        index = (index + 1) % renderers.Length;
    }

    //Changes the speed of the planet
    void SetSpeed()
    {

    }

    //Changes the size of the planet
    void SetSize()
    {
        //adjusts size of the planet preview and spawn
        size = sizeSlider.value;
        //renderer.size = new Vector2(size, size);
        preview.transform.localScale = new Vector2(size, size);

    }
}
