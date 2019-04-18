namespace Capitalism.Logic.Models
{
    public class Skills
    {
        /// <summary>
        /// Used to create construction materials and work in construction professions.
        /// </summary>
        public int Carpentry
        {
            get { return _carpentry; }
            private set
            {
                if (value < 0) _carpentry = 0;
                else _carpentry = value;
            }
        }
        private int _carpentry;

        /// <summary>
        /// Used to create various types of food and recipes and work in bars and restraunts.
        /// </summary>
        public int Cooking
        {
            get { return _cooking; }
            private set
            {
                if (value < 0) _cooking = 0;
                else _cooking = value;
            }
        }
        private int _cooking;

        /// <summary>
        /// Used to create science packs and work in medical related professions
        /// </summary>
        public int Science
        {
            get { return _science; }
            private set
            {
                if (value < 0) _science = 0;
                else _science = value;
            }
        }
        private int _science;

        /// <summary>
        /// Used to create technlogy packs and work in technology related professions.
        /// </summary>
        public int Technology
        {
            get { return _technology; }
            private set
            {
                if (value < 0) _technology = 0;
                else _technology = value;
            }
        }
        private int _technology;

        public Skills(int carpentry, int cooking, int science, int technology)
        {
            this.Carpentry = carpentry;
            this.Cooking = cooking;
            this.Science = science;
            this.Technology = technology;
        }

        public static Skills Default => new Skills(0, 0, 0, 0);
    }
}
