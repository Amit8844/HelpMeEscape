using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletText : MonoBehaviour
{
	Text Bullettext;
	public static int bulletAmount = 0;

	
	void Start()
	{
		Bullettext = GetComponent<Text>();
	}

	
	void Update()
	{
	
		Bullettext.text = bulletAmount > 0 ? "Bullet:-  " + bulletAmount : "Out of Bullet!";
    }
}
