using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    public SpriteRenderer[] renderers; 
    public TMP_Dropdown dropdown;
    public Button select;
    private int index = 0;
    private bool selected = false;
 
    // Start is called before the first frame update
    void Start()
    {
        select.onClick.AddListener(SetImg);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected) //if mouse button is clicked while the button is pressed, spawn the selected sprite
        {
            Debug.Log("click");
            Spawn();
        }
    }
    void SetImg()
    {
        selected = !selected; //toggles select button, if you press the select button again it stops you from being able to place sprites in the scene
    }





    void Spawn()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //covert mouse position to world point
        transform.position = mousepos; //set object to mouse position
        Debug.Log(mousepos.x);
        SpriteRenderer renderer = renderers[index]; //get current renderer and assign the selected sprite
        renderer.sprite = dropdown.options[dropdown.value].image;
        renderer.transform.position = new Vector3(mousepos.x, mousepos.y, 0); //set sprite position and scale
       renderer.transform.localScale = new Vector2(5f, 5f);


        //move to the next renderer in the array and loop
        index = (index + 1) % renderers.Length;
    }
}
