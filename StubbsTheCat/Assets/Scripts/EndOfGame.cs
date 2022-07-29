using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfGame : MonoBehaviour
{
    public TextMeshProUGUI endOfGameText;

	private void Start()
	{
        endOfGameText.text = string.Empty;

    }
	public void Victory()
    {
        endOfGameText.text = "You have won!";
    }

    public void Defeat()
    {
        endOfGameText.text = "You have lost";
    }
}
