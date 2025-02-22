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
        mySprite.sprite = dropdown.options[0].image; //set initial sprite to the first option in the dropdown
    }
    // Update is called once per frame
    public void OnValueChanged(int index) //called when dropdown value is changed
    {
        Debug.Log(dropdown.options[index].text);
        mySprite.sprite = dropdown.options[index].image; //update the sprite to match the dropdown option
    }
}
