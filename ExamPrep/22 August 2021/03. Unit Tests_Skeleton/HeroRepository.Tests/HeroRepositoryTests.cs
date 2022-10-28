using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
  

    [Test]
    public void HeroCTOR()
    {
        string name = "Alex";
        int level = 50;
        Hero hero = new Hero(name, level);

        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }

    [Test]
    public void HeroRepoCTOR()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.IsNotNull(heroRepository.Heroes);
        Assert.AreEqual(0,heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateHeroThowsExceptionForNullHero()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }
    [Test]
    public void CreateHeroThowsExceptionForExcistingHero()
    {
        HeroRepository heroRepository = new HeroRepository();

        Hero hero = new Hero("Alex", 50);
        heroRepository.Create(hero);
        Hero hero2 = new Hero("Alex", 50);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero2));
    }

    [Test]
    public void CreateHeroAddHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.AreEqual(0, heroRepository.Heroes.Count);
        Hero hero = new Hero("Alex", 50);
        heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);
        Hero hero2 = new Hero("Peter", 50);
        heroRepository.Create(hero2);
        Assert.AreEqual(2, heroRepository.Heroes.Count);

    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void RemoveThrowsExcForNullOrWhitespace(string name)
    {
        HeroRepository heroRepository = new HeroRepository();

        Hero hero = new Hero("Alex", 50);
        heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));

    }

    [Test]
    public void RemoveHeroReturnTrue()
    {
        HeroRepository heroRepository = new HeroRepository();

        Hero hero = new Hero("Alex", 50);
        heroRepository.Create(hero);


        Assert.IsTrue(heroRepository.Remove("Alex"));
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void RemoveHeroReturnFalse()
    {
        HeroRepository heroRepository = new HeroRepository();
        string name = "Peter";
        Hero hero = new Hero("Alex", 50);
        heroRepository.Create(hero);


        Assert.IsFalse(heroRepository.Remove(name));
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }
    [Test]
    public void GetHeroWithHighestLevel()
    {
        HeroRepository heroRepository = new HeroRepository();
        
        Hero hero1 = new Hero("Alex", 150);
        Hero hero2 = new Hero("Peter", 50);
        Hero hero3 = new Hero("George",90);
        Hero hero4 = new Hero("Vex", 15);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        Assert.AreEqual(hero1, heroRepository.GetHeroWithHighestLevel());
    }


    [Test]
    public void GetHero()
    {
        HeroRepository heroRepository = new HeroRepository();

        Hero hero1 = new Hero("Alex", 150);
        Hero hero2 = new Hero("Peter", 50);
        Hero hero3 = new Hero("George", 90);
        Hero hero4 = new Hero("Vex", 15);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        Assert.AreEqual(hero1, heroRepository.GetHero("Alex"));
        Assert.AreEqual(hero2, heroRepository.GetHero("Peter"));
        Assert.AreEqual(hero3, heroRepository.GetHero("George"));
        Assert.AreEqual(hero4, heroRepository.GetHero("Vex"));
        Assert.AreEqual(4, heroRepository.Heroes.Count);
    }
    /*Hero GetHero(string name)
    {
        Hero hero = this.data.FirstOrDefault(h => h.Name == name);
        return hero;
    }*/

}