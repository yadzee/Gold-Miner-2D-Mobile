using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : MonoBehaviour
{
    private HookMovement _hookmovement;
    private TagManager _tagManager;
    private ItemCatchUI _itemCatchUI;
    private void Awake()
    {
        _itemCatchUI = GameObject.Find("ItemCatchUI").GetComponent<ItemCatchUI>();
        _itemCatchUI.gameObject.SetActive(false);
        _hookmovement = GetComponentInParent<HookMovement>();
        _tagManager = GameObject.Find("TagManager").GetComponent<TagManager>();
    }

    private void Update()
    {
        DestroyPickUps();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == _tagManager.TagUpdate(other.tag))
        {
            _hookmovement.moveDown = false;

            _itemCatchUI.gameObject.SetActive(true);
            _itemCatchUI._animation.Play("Catch");
            _itemCatchUI._image.sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.localPosition = new Vector3(0, -0.2f, 0);
        }
    }

    private void DestroyPickUps()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (_hookmovement.transform.position.y > _hookmovement._inital_Y)
            {
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
    }


}
