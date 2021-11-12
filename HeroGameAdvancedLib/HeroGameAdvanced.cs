using System;

namespace HeroGameAdvancedLib {
    public class Hero {
        public int HeroId { get; set; }
        public string Name { get; set; }
        public Dice Dice { get; set; }
        public int Uses { get; set; }

        public Hero (int heroId, string name, Dice dice, int uses) {
            this.HeroId = heroId;
            this.Name = name;
            this.Dice = dice;
            this.Uses = uses;
        }

        // Hero is able to attack a given number of times.  Each time a hero attacks subtract 1 from Uses
        // timesToAttack is greater that the number of Uses should return -1 and not subtract from Uses.
        public int Attack(int timesToAttack) {
            this.Uses -= timesToAttack;
            return this.Dice.Roll() * timesToAttack;
        }

        
    }

    public class Villain {
        public int VillainId { get; set; }
        public string Name { get; set; }
        public int Hitpoints { get; set; }

        public Villain (int villainId, string name, int hitpoints) {
            this.VillainId = villainId;
            this.Name = name;
            this.Hitpoints = hitpoints;
        }

        // applies amount of damage to Hitpoints.
        // if damage is greater that Hitpoints, Hitpoints should be set to 0 (zero)
        public void Damage(int amount) {
            this.Hitpoints -= amount;
            if (this.Hitpoints < 0)
                this.Hitpoints = 0; 
        }
    }

    public class Dice {
        public int Min { get; set; }
        public int Max { get; set; }
        private Random rand = new Random();

        public Dice (int min, int max) {
            this.Min = min;
            this.Max = max;
        }

        // Roll returns an integer between Min and Max inclusive
        public int Roll() {
            return rand.Next(this.Min, this.Max);
        }
    }
}