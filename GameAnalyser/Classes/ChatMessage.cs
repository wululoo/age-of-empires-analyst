namespace GameAnalyser
{
	public class ChatMessage
	{
		public int playerIndex;
		public string target;
		public int time;
		public string content;

		public ChatMessage(int v1, int index, string v2, string target)
		{
			this.time = v1;
			this.playerIndex = index;
			this.content = v2;
			this.target = target;
		}
	}
}