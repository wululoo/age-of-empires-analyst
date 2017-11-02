using System;
namespace AgeOfEmpiresLibrary
{
	public class Player
	{
		private int id;
		private string name;
		private int colour;
		private int team;
		private int civilisation;
		private int rating;
        private bool isHuman;
        private bool isSpectator;

        public Player()
        {
            
        }

		public Player(int id, string name, int colour, int team, int civ, int state)
		{
            this.id = id;
            this.name = name;
            this.colour = colour;
            this.team = team;
            this.civilisation = civ;
            setState(state);
		}

        public bool isValid()
        {
            throw new NotImplementedException();
        }

        public void setTeam(int team)
        {
            this.team = team;
        }

        public void setState(int state)
        {
            switch (state)
            {
                case PlayerSetting.STATE_HUMAN:
					this.isHuman = true;
					this.isSpectator = false;
                    break;

                case PlayerSetting.STATE_SPECTATOR:
					this.isHuman = false;
                    this.isSpectator = true;
                    break;

                case PlayerSetting.STATE_AI_1:
                case PlayerSetting.STATE_AI_2:
                default:
					this.isHuman = false;
					this.isSpectator = false;
					break;
                    
            }
            if (state == PlayerSetting.STATE_HUMAN)
            {
                this.isHuman = true;
                this.isSpectator = false;
            }
            
        }

        public int getId()
        {
            return id;
        }
    }
}
