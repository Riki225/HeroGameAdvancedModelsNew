using System;
using Xunit;
using HeroGameAdvancedLib;

namespace HeroGameAdvancedTests
{
    public class DiceTests
    {
        Dice dice0;
        Dice dice1;
        Dice dice2;
        Dice dice3;
        Dice dice4;
        Dice dice5;
        Dice[] diceList;

        public DiceTests(){
            this.dice0 = new Dice(1,6);
            this.dice1 = new Dice(1,1);
            this.dice2 = new Dice(0,5);
            this.dice3 = new Dice(-5,5);
            this.dice4 = new Dice(-5,0);
            this.dice5 = new Dice(-1,-1);
            this.diceList = new Dice[]{ this.dice0, this.dice1, this.dice2, this.dice3, this.dice4, this.dice5 };
        }

        [Theory]
        [InlineData(0,1,6)]
        [InlineData(1,1,1)]
        [InlineData(2,0,5)]
        [InlineData(3,-5,5)]
        [InlineData(4,-5,0)]
        [InlineData(5,-1,-1)]
        public void DiceInRangeTests(int diceIndex, int diceValueMin, int diceValueMax)
        {
            int diceValue;
            for(int i=0; i<1000; i++){
                diceValue = this.diceList[diceIndex].Roll();
                Assert.InRange(diceValue, diceValueMin, diceValueMax);
            }
        }

        [Theory]
        [InlineData(0,1,6)]
        [InlineData(1,1,1)]
        [InlineData(2,0,5)]
        [InlineData(3,-5,5)]
        [InlineData(4,-5,0)]
        [InlineData(5,-1,-1)]
        public void DiceMinTests(int diceIndex, int diceValueMin, int diceValueMax)
        {
            int diceValue;
            int diceMin;
            diceValue = diceMin = this.diceList[diceIndex].Roll();
            for(int i=0; i<1000; i++){
                diceValue = this.diceList[diceIndex].Roll();
                if(diceValue<diceMin){
                    diceMin=diceValue;
                }
            }
            Assert.Equal(diceValueMin,diceMin);
        }

        [Theory]
        [InlineData(0,1,6)]
        [InlineData(1,1,1)]
        [InlineData(2,0,5)]
        [InlineData(3,-5,5)]
        [InlineData(4,-5,0)]
        [InlineData(5,-1,-1)]
        public void DiceMaxTests(int diceIndex, int diceValueMin, int diceValueMax)
        {
            int diceValue;
            int diceMax;
            diceValue = diceMax = this.diceList[diceIndex].Roll();

            for(int i=0; i<1000; i++){
                diceValue = this.diceList[diceIndex].Roll();
                if(diceValue>diceMax){
                    diceMax=diceValue;
                }
            }
            Assert.Equal(diceValueMax,diceMax);
        }
    }
}