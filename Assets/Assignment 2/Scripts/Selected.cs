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
        if (Input.GetMouseButtonDown(0) && selected)
        {
            Debug.Log("click");
            Spawn();
        }
    }
    void SetImg()
    {
        selected = !selected;
    }





    void Spawn()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousepos;
        Debug.Log(mousepos.x);
        SpriteRenderer renderer = renderers[index];
        renderer.sprite = dropdown.options[dropdown.value].image;
        renderer.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
       renderer.transform.localScale = new Vector2(5f, 5f);



        index = (index + 1) % renderers.Length;
    }
}
