using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DropDown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer mySprite;

    // Start is called before the first frame update
    private void Start()
    {
        mySprite.sprite = dropdown.options[0].image;
    }
    // Update is called once per frame
    public void OnValueChanged(int index)
    {
        Debug.Log(dropdown.options[index].text);
        mySprite.sprite = dropdown.options[index].image;
    }
}
