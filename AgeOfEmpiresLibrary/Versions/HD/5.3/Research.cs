namespace AgeOfEmpiresLibrary
{
    public class Research
    {
        public int id;
        public int duration;
        private string name;
        private int age;
        private Resources cost;

        public Research(int id, int duration, string name)
        {
            this.id = id;
            this.duration = duration;
            this.name = name;
        }

		public Research(int id, int duration, string name, Resources cost)
		{
			this.id = id;
			this.duration = duration;
			this.name = name;
            this.cost = cost;
		}

        public string getName()
        {
            return name;
        }
    }
}
