using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TimelineTest
{
	[Test]
	public void TimelineBasicNonLoopingTest()
	{
		Timeline<string> line = new Timeline<string> ();
		line.addEvent (6f, "test");
		line.addEvent (0.5f, "is");
		line.addEvent (0.9f, "a");
		line.addEvent (0.1f, "this");

		string[] stringParts;
		string finalString = "";
		while (line.simulate (0.1f, out stringParts))
			foreach (string s in stringParts)
				finalString += s + " ";

		Assert.AreEqual ("this is a test ", finalString);
	}

	[Test]
	public void TimelineBasicLoopingTest()
	{
		Timeline<string> line = new Timeline<string> ();
		line.addEvent (1f, "nya");
		line.setLooping (true);

		string[] stringParts;
		string finalString = "";

		line.simulate (5f, out stringParts);
		foreach (string s in stringParts)
			finalString += s;
		finalString += "n";

		Assert.AreEqual ("nyanyanyanyanyan", finalString);
	}
}
