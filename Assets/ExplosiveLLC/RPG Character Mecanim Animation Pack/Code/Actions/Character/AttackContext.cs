using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class AttackContext
    {
        public string type;
        public AttackWeight AttackWeight;
        public int number;
        public int combo;

        public AttackContext(string type, AttackWeight attackWeight, int number = -1 )
        {
            this.type = type;
            AttackWeight = attackWeight;
            this.number = number;
        }
    }
}