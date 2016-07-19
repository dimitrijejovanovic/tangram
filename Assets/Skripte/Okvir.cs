using UnityEngine;
using System.Collections;

public class Okvir : MonoBehaviour
{
    // provera se radi na osnovu malih kolajdera unutar zapremina okvira i objekata
	// i preko provera da li su okvir i objekat u odgovarajucoj rotaciji

    public Objekat[] objekti;
    public int tolerancijaRotacije; //za kontrolu rotacije
    public TekstSkripta tekst;
	public int trenutnaRotacija; //za kontrolu rotacije

    private bool uspesnaPozicija;
    private int brojRotacijaObjekta;
    
    private Collider[] bc;

    void Update() // moguca rotacija od 1 do 8
    {
        if (trenutnaRotacija > 8)
            trenutnaRotacija = 1;
    }

    void Start()
    {
        bc = new Collider[objekti.Length]; // omogucava veci broj objekata po okviru
        for (int i = 0; i < objekti.Length; i++)
        {
            bc[i] = objekti[i].GetComponent<BoxCollider>();
        }
        uspesnaPozicija = false;
    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objekti.Length; i++)
        {
			// glavna provera rotacije
            if (other == bc[i] && (objekti[i].trenutnaRotacija % tolerancijaRotacije == trenutnaRotacija % tolerancijaRotacije))
            {
                tekst.updateScore(1);
                uspesnaPozicija = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < objekti.Length; i++)
        {
            if (other == bc[i] && uspesnaPozicija)
            {
                tekst.updateScore(-1);
                uspesnaPozicija = false;
            }
        }
    }
}
