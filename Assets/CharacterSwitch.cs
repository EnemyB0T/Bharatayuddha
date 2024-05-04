using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public WeaponSwitching ws;
    public Sprite Dendro;
    public Sprite Pyro;
    public Sprite Hydro;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the SpriteRenderer component for better performance
        spriteRenderer = GetComponent<SpriteRenderer>();
        ws = FindObjectOfType<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ws.selectedWeapon = 1;
            ws.SelectWeapon();
            spriteRenderer.sprite = Pyro;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
             ws.selectedWeapon = 2;
             ws.SelectWeapon();
            spriteRenderer.sprite = Dendro;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ws.selectedWeapon = 3;
             ws.SelectWeapon();
            spriteRenderer.sprite = Hydro;
        }
    }
}
