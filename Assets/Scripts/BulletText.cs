using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletText : MonoBehaviour
{
	Text text;
	public static int bulletAmount = 0;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		if (bulletAmount > 0)
			text.text = "Bullet:-  " + bulletAmount;
		else
			text.text = "Out of Bullet!";
	}
}
