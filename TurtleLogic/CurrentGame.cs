using System;
using TurtleInterface;

namespace TurtleLogic
{
	public static class CurrentGame
	{
		// Hello World
		public static ITurtleGame Game = new MyTurtleHelloWorld ();

		// Simple Game
		//public static ITurtleGame Game = new MyTurtleGame ();
	}
}
