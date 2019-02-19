using System;
using TurtleInterface;

namespace TurtleLogic
{
	public static class CurrentGame
	{
		// Hello World
		public static ITurtleGame Game = new PongGame ();

		// Simple Game
		//public static ITurtleGame Game = new MyTurtleGame ();
	}
}
