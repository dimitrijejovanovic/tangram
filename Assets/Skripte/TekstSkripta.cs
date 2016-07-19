using UnityEngine;
using System.Collections;

public class TekstSkripta : MonoBehaviour {

    public int score;
    public GUIText guiText;

    void Start()
    {
        score = 0;
        updateText();
    }
   
   public void updateScore(int a)
    {
        score += a;
        updateText();       
    }
	
    public void updateText()
    {
        if (score == 6)
            guiText.text = "BRAVO! FIGURA JE SKLOPLJENA!";
        else
            guiText.text = "Oblici se pomeraju prevlačenjem, a rotiraju na desni klik miša.\nFiguru je moguće sklopiti na bilo kom delu ekrana u bilo kojoj rotaciji.\nPomoć: žuti trougao je manja grba";
    }
}
