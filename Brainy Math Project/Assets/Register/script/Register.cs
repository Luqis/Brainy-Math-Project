﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Register : MonoBehaviour {

	public string inputUsername;
	private bool done = false;
	public static string username = "";
	public static string password = "";

	private string cpassword = "";
	public string Confirmpassword="";



	string userUrl = "http://localhost/game/register.php";

	public GameObject window;
	public Text messageField;
	private bool msg = false;
	public static bool donemsg = false;

	public void Show(string message){
		if (msg == true) {
			messageField.text = message;
			window.SetActive (true);
			msg = false;
		}
	}

	public void Hide(){

		if (donemsg == false) {
			window.SetActive (false);
		} else if (donemsg == true) {
			done = true;
			changeScene ("Login");
		}

	}


	public void changeScene(string sceneName)
	{
		if (done == true) {
			SceneManager.LoadScene (sceneName);
		}


	}

	public void getUsername (string getname){
		username = getname;
	}

	public void getPassword (string getpass){
		password= getpass;
	}

	public void getcPassword (string getpass){
		cpassword= getpass;
	}

	public void Create (){
		
		if (password == cpassword && password != "") {
			
			StartCoroutine ("x");
		} else {
			msg = true;
			Show ("Password Not Match!");
		}


		}

	IEnumerator x ()
	{
		
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username);
		form.AddField ("passwordPost", password);
		WWW	www = new WWW (userUrl, form);

		yield return www;

		string x = www.text;
		if (x == "OK") {
			done = true;
		
			msg = true;
			Show ("DONE Register!");
			donemsg = true;
		
		} else if (x == "Failed") {
			msg = true;
			Show ("Username Has Been used!");
		}


	}









}