using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Objekat : MonoBehaviour
{
    // само команде за ротирање и превлачење
    // при ротирању се мења број ротације (од 1 до 8)
    private Vector3 pozicijaNaEkranu;
    private Vector3 ofset;
    public int trenutnaRotacija;
   
    void OnMouseDown()
    {
        pozicijaNaEkranu = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        ofset = gameObject.transform.position - Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, pozicijaNaEkranu.z));
    }

    void OnMouseDrag()
    {
        Vector3 trenutnaPozicijaNaEkranu = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pozicijaNaEkranu.z);
        Vector3 trenutnaPozicija = Camera.main.ScreenToWorldPoint(trenutnaPozicijaNaEkranu) + ofset;
        transform.position = trenutnaPozicija;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(new Vector3(0, 45, 0));
            if (trenutnaRotacija < 8) trenutnaRotacija++;
            else trenutnaRotacija = 1;
        }       
    }
}
