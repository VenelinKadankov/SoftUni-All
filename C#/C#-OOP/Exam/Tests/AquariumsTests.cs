namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("pesho");
            aquarium = new Aquarium("lokva", 1000);
        }


        [Test]
        public void CheckFishNameIsAccurate()
        {
            Assert.AreEqual("pesho", fish.Name);
        }

        [Test]
        public void CheckFishAvailabilityIsAccurate()
        {
            Assert.AreEqual(true, fish.Available);
        }

        [Test]
        public void CheckAquariumThrowsMistakeOnNameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            aquarium = new Aquarium(null, 200));
        }

        [Test]
        public void CheckAquariumThrowsMistakeOnNameEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            aquarium = new Aquarium("", 200));
        }

        [Test]
        public void CheckAquariumSetsNameProperly()
        {
            Assert.AreEqual(aquarium.Name, "lokva");
        }

        [Test]
        public void CheckAquariumThrowsExOnNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
                            aquarium = new Aquarium("cc", -200));
        }

        [Test]
        public void CheckAquariumSetsCapacityProperly()
        {
            Assert.AreEqual(aquarium.Capacity, 1000);
        }

        [Test]
        public void CheckAquariumCountProperly()
        {
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }


        [Test]
        public void CheckAquariumCantAddFishWhenFull()
        {
            aquarium = new Aquarium("z", 1);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("ivan")));
        }

        [Test]
        public void CheckAquariumRemoveThrowsExIfFishNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Stoqn"));
        }


        [Test]
        public void CheckAquariumRemoveFishWorks()
        {
            aquarium.Add(fish);
            aquarium.Add(new Fish("gosho"));

            aquarium.RemoveFish("gosho");

            Assert.AreEqual(aquarium.Count, 1);
        }


        [Test]
        public void CheckAquariumSellFishThrowsExIfFishNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Stoqn"));
        }


        [Test]
        public void CheckAquariumSellFishWorksPropperly()
        {
            aquarium.Add(fish);

            var requested = aquarium.SellFish("pesho");

            Assert.AreEqual(fish, requested);
        }

        [Test]
        public void CheckAquariumSellFishChangesAvailability()
        {
            aquarium.Add(fish);

            var requested = aquarium.SellFish("pesho");

            Assert.AreEqual(fish.Available, false);
        }


        [Test]
        public void CheckAquariumReportWorksPropperly()
        {
            aquarium.Add(fish);
            aquarium.Add(new Fish("Gosho"));

            var report = aquarium.Report();

            var compared = $"Fish available at lokva: pesho, Gosho";

            Assert.AreEqual(report, compared);
        }
    }
}
