using System;
using System.Collections.Generic;

namespace AgeOfEmpiresLibrary.Versions.HD.Civilisations
{
    public class Civilisation
    {
        public int id;
		public Research uniqueTech1;
		public Research uniqueTech2;

		public Unit uniqueUnit;

		public List<Research> techTree;
		public List<Unit> unitTree;

        public Civilisation()
        {
        }
    }
}
