using System;
using Xunit;
using HeroGameAdvancedLib;

namespace HeroGameAdvancedTests
{
    public class HeroTests
    {
        Dice heroDice1;
        Hero heroTest1;
        Dice heroDice2;
        Hero heroTest2;

        public HeroTests(){
            this.heroDice1 = new Dice(1,6);
            this.heroTest1 = new Hero(1,"Test1",this.heroDice1,3);
            this.heroDice2 = new Dice(0,5);
            this.heroTest2 = new Hero(2,"Test2",this.heroDice2,0);
        }

        [Theory]
        [InlineData(1,1,6,2)]
        [InlineData(0,0,0,3)]
        [InlineData(3,3,18,0)]
        [InlineData(4,-1,-1,3)]
        [InlineData(-1,-1,-1,3)]
        public void Hero1AttackTests(int numAttacks, int attackValueMin, int attackValueMax, int expectedUses)
        {
            int attackValue = this.heroTest1.Attack(numAttacks);
            Assert.InRange(attackValue, attackValueMin, attackValueMax);
            Assert.Equal(this.heroTest1.Uses,expectedUses);
        }

        [Theory]
        [InlineData(1,-1,-1,0)]
        [InlineData(0,0,0,0)]
        public void Hero2AttackTests(int numAttacks, int attackValueMin, int attackValueMax, int expectedUses)
        {
            int attackValue = this.heroTest2.Attack(numAttacks);
            Assert.InRange(attackValue, attackValueMin, attackValueMax);
            Assert.Equal(this.heroTest2.Uses,expectedUses);
        }
    }
}