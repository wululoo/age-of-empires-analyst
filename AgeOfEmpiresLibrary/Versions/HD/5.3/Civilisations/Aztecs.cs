using System;
using AgeOfEmpiresLibrary;

namespace AgeOfEmpiresLibrary.Versions.HD.Civilisations
{
    public class Aztecs : Civilisation
    {
        public Aztecs()
        {
            this.id = AgeOfEmpiresLibrary.CivilisationType.AZTECS;
            this.uniqueUnit = AgeOfEmpiresLibrary.UnitType.UNIT_JAGUAR_WARRIOR;

            this.uniqueTech1 = AgeOfEmpiresLibrary.ResearchType.RESEARCH_ATLATL;
            this.uniqueTech2 = AgeOfEmpiresLibrary.ResearchType.RESEARCH_GARLAND_WARS;
        }
    }
}
