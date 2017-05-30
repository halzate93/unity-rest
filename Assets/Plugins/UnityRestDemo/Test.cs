using UnityEngine;
using UnityRest;

public class Test : MonoBehaviour 
{
	private UnityRestManager api;

	private void Start ()
	{
		api = UnityRestManager.Instance;
	}

	private void Update () 
	{
		if (Input.GetKeyDown (KeyCode.G))
			GetAll ();
		if (Input.GetKeyDown (KeyCode.O))
			GetOne ();
		if (Input.GetKeyDown (KeyCode.P))
			Post ();
	}

	public void GetAll ()
	{
		api.Get<Post> ("posts").OnResult<Post> (LogAll).Send ();
	}

	public void GetOne ()
	{
		api.Get<Post> ().OnResult<Post> (Log).WithId ("1").Send ();
	}

	private void LogAll (Post[] posts)
	{
		foreach (Post post in posts)
			Log (post);
	}

	private void Log (Post post)
	{
		Debug.Log (post.title);
	}	

	private void Post ()
	{
		Post post = new Post ("1", "Hello", "world");
		api.Post<Post> ().WithBody (post).OnResult (LogOk).Send ();
	}

	private void LogOk ()
	{
		Debug.Log ("Ok");
	}
}
