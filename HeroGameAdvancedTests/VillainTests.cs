using System;
using Xunit;
using HeroGameAdvancedLib;

namespace HeroGameAdvancedTests
{
    public class VillainTests
    {
        Villain villainTest1;
        Villain villainTest2;

        public VillainTests(){
            this.villainTest1 = new Villain(1,"Test1",3);
            this.villainTest2 = new Villain(2,"Test2",0);
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(0,3)]
        [InlineData(3,0)]
        [InlineData(4,0)]
        [InlineData(-1,4)]
        public void Villain1AttackTests(int damageValue, int expectedHealth)
        {
            this.villainTest1.Damage(damageValue);
            Assert.Equal(expectedHealth, this.villainTest1.Hitpoints);
        }

        [Theory]
        [InlineData(1,0)]
        [InlineData(0,0)]
        [InlineData(3,0)]
        [InlineData(4,0)]
        [InlineData(-1,1)]
        public void Villain2AttackTests(int damageValue, int expectedHealth)
        {
            this.villainTest2.Damage(damageValue);
            Assert.Equal(expectedHealth, this.villainTest2.Hitpoints);
        }
    }
}