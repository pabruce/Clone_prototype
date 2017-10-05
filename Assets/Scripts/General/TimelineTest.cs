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

	[Test]
	public void TimelineBasicCloneTest()
	{
		Timeline<string> original = new Timeline<string> ();
		original.addEvent (6f, "test");
		original.addEvent (0.5f, "is");
		original.addEvent (0.9f, "a");
		original.addEvent (0.1f, "this");

		Timeline<string> duplicate = original.clone (false);

		original.addEvent (0.6f, "not");

		string[] stringParts;
		string finalString = "";
		while (duplicate.simulate (0.1f, out stringParts))
			foreach (string s in stringParts)
				finalString += s + " ";

		Assert.AreEqual ("this is a test ", finalString);
	}

	[Test]
	public void TimelineAdvancedCloneTest()
	{
		Timeline<string> original = new Timeline<string> ();
		original.addEvent (0f, "hello");
		original.addEvent (0.7f, "there");
		original.addEvent (1.5f, "friend");
		original.addEvent (2f, "how");
		original.addEvent (2.5f, "are");
		original.addEvent (2.5f, "you");

		string[] dump_ori;
		original.simulate (1.9f, out dump_ori);

		Timeline<string> duplicate = original.clone (true);

		string[] dump_dup;
		duplicate.simulate (0.6f, out dump_dup);

		string finalString = "";
		foreach (string s in dump_ori)
			finalString += s + " ";
		foreach (string s in dump_dup)
			finalString += s + " ";

		Assert.AreEqual ("hello there friend how are you ", finalString);
	}
}
