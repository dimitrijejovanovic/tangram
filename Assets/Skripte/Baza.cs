using UnityEngine;
using System.Collections;

public class Baza : MonoBehaviour {
    // ова класа је скоро идентична класи Објекат
    // поента је да се сви оквири ставе унутар објекта са овом скриптом
    // како би могли да се ротирају заједно са тим објектом
    // а ова скрипта је постављена на једини објекат који је јединствен и нема флексибилну ротацију

    private Vector3 pozicijaNaEkranu;
    private Vector3 ofset;
    public int trenutnaRotacija;
    public Okvir[] okviri;


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
            foreach (Okvir o in okviri)
            {
                o.trenutnaRotacija++;
            }
        }
    }
}
