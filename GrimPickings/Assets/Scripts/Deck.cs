using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    //defining what info a card has
    public class Card
    {
        public string name;
        public string bodyPart;
        public string rarity;
        public int health;
        public int attack;
        public int speed;
        public string tagLine;
        public string gatherAbility;
        public string attackAbility;
        public string curse;
        public string type;
        public Sprite img;
        public string gesture;

        public Card(string nameVal, string bodyPartVal, string rarityVal, int healthVal, int attackVal, int speedVal, string tagLineVal, string gatherAbilityVal, string attackAbilityVal, string curseVal, string typeVal, Sprite imgVal, string gestureVal)
        {
            name = nameVal;
            bodyPart = bodyPartVal;
            rarity = rarityVal;
            health = healthVal;
            attack = attackVal;
            speed = speedVal;
            tagLine = tagLineVal;
            gatherAbility = gatherAbilityVal;
            attackAbility = attackAbilityVal;
            curse = curseVal;
            type = typeVal;
            img = imgVal;
            gesture = gestureVal;
        }
    }

    public List<Card> partsCardDeck = new List<Card>();
    //Image Sprites for each card
    [SerializeField] private Sprite DragonHead, Tentacle, GorgonHead, HorseLeg, WolfClaws, Wings, GiantEye, CrabClaw, WerewolfHead, DeathsHood, PorcelainArm, DullahansGreaves, DullahansGauntlets, LichsArm, MidasHand, VenusFlyTrap, JiangshiLeg, 
        RabbitsFoot, SpiderLegs, SlimyCenter, Egg, ShadowyCenter, KappaShell, StoneyChest, AngelsHead, StrawHead, StickLeg, MushroomCap, IcyLeg, HedgehogQuills, CrystallineTorso, MirrorHead, ExsArm, MetalArm, BrainInAJar, CentipedeLegs, LionArm, 
        CatHead, BoarsHead, TrollLeg, MoltenTorso, InfernalClaws, MonkeysPaw, EldritchVoid, Snake, SasquatchLeg, Pumkin, JackOLantern, ClownHead, BigShoe, TrollTorso, GlassCannon;

    void Awake()
    {
        createDeck();
    }

    //this runs on awake becuase it uses image references and can't be initalized before the game is started
    void createDeck()
    {
        partsCardDeck = new List<Card>() {
            new Card("Angel's Head", "Head", "Rare", 0, 0, 0, "You've got someone watching over you", "Get rid of two body part curses", "Get a random curse and apply it to the opponent. Accuracy : 10", "None", "Divine", AngelsHead, "None"),
            new Card("Big Shoe", "Leg", "Rare", 0, 5, -2, "A shoe this big is a labor of love", "Add 4 to your movement roll", "Kick your opponent for 10 damage. Accuracy 13", "None", "Shoe", BigShoe, "None"),
            new Card("Boar's Head", "Head", "Uncommon", -2, 2, 2, "Ramming Speed!", "Head straight for a \"Grave Site\"", "Deal 20 damage to opponent. Accuracy 10", "None", "Creature", BoarsHead, "None"),
            new Card("Brain in a Jar", "Head", "Rare", 0, 0, 0, "Alright brainiac...", "You may use 2 abilities in one turn as long as you do not move during that turn. You outsmarted your opponent, move 5-7 hexagons spaces behind the opponent. Accuracy 9", "You may use 2 abilities in one turn as long as you do not move during that turn. You outsmarted your opponent, move 5-7 hexagons spaces behind the opponent. Accuracy 9", "None", "Magical", BrainInAJar, "None"),
            new Card("Cat Head", "Head", "Uncommon", 0, 2, 0, "Here kitty kitty", "Increase speed by 2 for one turn", "Increase your attack by 1 for a single turn. Accuracy 18", "None", "Creature", CatHead, "None"),
            new Card("Centipede Leg", "Leg", "Uncommon", 0, -1, 1, "Just 299 legs short of a millipede.", "Gain an extra 3 speed for 1 turn. Accuracy 15", "Gain an extra 3 speed for 1 turn. Accuracy 15", "None", "Creature", CentipedeLegs, "None"),
            new Card("Clown Head", "Head", "Rare", -5, 5, 0, "Why are you laughing? This is serious!", "If you pull \"Angry Raccoon,\" \"Bandit,\" or \"Grave Keeper\" curse cards, ignore them. Lower your oppoenents next accuracy roll by 4. Accuracy of 12", "Lower your oppoenents next accuracy roll by 4. Accuracy of 12", "None", "Person", ClownHead, "None"),
            new Card("Crab Claw", "Arm", "Uncommon", 0, 0, 0, "Protector of the sands", "Reduce your opponent's speed by 2 until the start of your next turn.", "Melee attack that deals 14 damage. Target gains -2 penalty to speed rolls until your next turn. Accuracy: 9", "None", "Creature", CrabClaw, "None"),
            new Card("Crystalline Torso", "Torso", "Rare", 17, 0, -3, "Shine on you crazy diamond", "If forced to drop a body part, you may instead offer part of your crystal, lowering your max health by 7", "Reduce damage from an opponents attack by 3 for 1 turn", "None", "Crystal", CrystallineTorso, "None"),
            new Card("Death's Hood", "Head", "Legendary", 3, 0, 3, "One step closer...", "You may ignore an effect that causes you to lose body parts once. Use this to teleport to a empty \"Grave.\"", "You may teleport to the nearest available item space. Accuracy 12", "This head automatically equips and cannot be removed as long as this curse is active", "Divine", DeathsHood, "None"),
            new Card("Dragon Head", "Head", "Rare", 0, 0, 0, "I am a dragon, hear me roar!", "Light three hexagans on fire around the map", "Combat Phase: Gain a fire breath that shoots 3 hexagons forward for 15 attack. Accuracy: 13 ", "None", "Mythical", DragonHead, "None"),
            new Card("Dullahan's Gauntlets", "Arm", "Rare", 0, 5, 0, "One has to take risks to get ahead", "Paralyze one of the legs from the opponent.  Accuracy 10", "Paralyze one of the legs from the opponent.  Accuracy 10", "You may not carry a head", "Dullahan", DullahansGauntlets, "None"),
            new Card("Dullahan's Greaves", "Leg", "Rare", 15, 0, -1, "A curse is worth getting a leg up on the competition", "Paralyze one of the legs from the opponent.  Accuracy 10", "Paralyze one of the legs from the opponent.  Accuracy 10", "You may not carry a head", "Dullahan", DullahansGreaves, "None"),
            new Card("Egg", "Torso", "Uncommon", -6, 4, 0, "Which came first?",  "Throw egg at enemy, just to reduce his speed by 1 for one turn", "If 2 hexagons away, throw part of egg at opponent, dealing 4 damage. Accuracy 18", "If this ability is used three times, discard the body part and ability.", "Creature", Egg, "None"),
            new Card("Eldritch Void", "Torso", "Rare", 0, 0, 0, "Look into it, and you'll find something looking back at you", "Discard one held body part or item and draw a card to replace it.", "Discard one held body part or item and draw a card to replace it.", "None", "Mythical", EldritchVoid, "None"),
            new Card("Ex's Arm", "Arm", "Rare", 0, 2, 0, "Hit'em with the flowers!", "Throw the flowers at the opponent and causing them to lose their head.", "Deal 20 damage as a melee attack. Accuracy: 8", "Basic attacks deal 1 self damage", "Person", ExsArm, "None"),
            new Card("Giant Eye", "Head", "Rare", 0, 0, 0, "I... see... everything!", "Draw an extra card when exhuming a resting site. Choose one ability that the opponent has that is not on cooldown, they may only use that ability next turn. Range 6, Accuracy 7", "Choose one ability that the opponent has that is not on cooldown, they may only use that ability next turn. Range 6, Accuracy 7", "None", "Divine", GiantEye, "None"),
            new Card("Glass Cannon", "Arm", "Rare", -4, 2, 0, "Caution: Fragile", "You use your cannon and destroy the enemies body part of your choice. Range of 3 Hexagons fires attack for 14 damage. Accuracy 12", "Gain a ranged attack with a range of 3 hexagons for 18 damage, Accuracy 12, but you will lose 4 health when using this ability.", "None", "Mythical", GlassCannon, "None")
            new Card("Gorgon Head", "Head", "Rare", 0, 0, 0, "At least let me get into a pose", "None", "Opponent gains -3 penalty to speed and attack dice rolls until your next turn. Accuracy: 15", "Upon obtaining, lose any other heads in inventory", "Mythical", GorgonHead, "None"),
            new Card("Hedgehog Quills", "Torso", "Uncommon", 0, -2, 2, "Gotta go fast!", "Deal 1 damage to opponent when they hit you with a melee attack. Increase your speed to max for one turn. Accuracy 10", "Deal 1 damage to opponent when they hit you with a melee attack. Increase your speed to max for one turn. Accuracy 10", "None", "Creature", HedgehogQuills, "None"),
            new Card("Horse Leg", "Leg", "Uncommon", -5, 0, 3, "Giddyup!", "While moving, increase speed by 3", "have a small chance to nullify or stun a body part from the opponent. Accuracy: 7", "None", "Mythical", HorseLeg, "None"),
            new Card("Icy Leg", "Leg", "Rare", -3, 0, 6, "Stay cool", "Reduce opponents speed by 3 for 1 turn. Accuracy 13", "Reduce opponents speed by 3 for 1 turn. Accuracy 13", "None", "Elemental", IcyLeg, "None"),
            new Card("Infernal Claws", "Arm", "Rare", 0, 0, 0, "Great for parties!", "Hurl a fireball at your enemy disentegrating a body part of thier choice", "Hitting opponent sets them on fire, dealing 1 damage for 3 turns. Ranged Fireball for 15 damage. Range: 5 Hexagons Accuracy 12", "None", "Magical", InfernalClaws, "None"),
            new Card("Jack o' Lantern", "Head", "Uncommon", 12, 1, -2, "Trick or treat!", "If you pull \"Angry Raccoon,\" \"Bandit,\" or \"Grave Keeper\" curse cards, ignore them otherwise, increase speed by 3 for one turn", "If two hexagons away, Throw part of your pumpkin head at the  enemy for 11 damage. Accuracy 11", "Plant", "None", JackOLantern, "None"),
            new Card("Jiangshi Leg", "Leg", "Rare", -5, 3, 0, "These revenants are known for their unusual agility", "Climb over an obstacle", "After a basic attack, you can use this ability to move 5 spaces", "None", "Mythical", JiangshiLeg, "None"),
            new Card("Kappa Shell", "Torso", "Rare", 15, 0, -4, "Take a bow. Or don't...", "Throw a small Kappa at the enemy that steals a item of your choice", "So, you like turtles huh? Go into your shell and take no damage. Accuracy 6", "None", "Creature/Divine", KappaShell, "None"),
            new Card("Lich's Arm", "Arm", "Legendary", 0, 0, 0, "The runes etched in the bone are the key to its otherwordly power", "Lob dark energy at your foe slowing thier speed by 4 for the next turn", "Gain a dark magic range attack. Range: 5 hexes, Attack: 15, Accuracy: 10", "None", "Skeleton", LichsArm, "None"),
            new Card("Lion Arm", "Arm", "Rare", 7, 7, 0, "Hear me roar!", "Disable one of your opponent's abilities of your choice as if they had used it", "Take thorn out of your paw. Healing for 10 health. Accuracy 10", "If basic attack, lost 1 health for 2 turns", "Creature", LionArm, "None"),
            new Card("Metal Arm", "Arm", "Uncommon", 0, 2, -1, "The best technology money can buy", "If head to head in gathering face, punch the enemy and stun him for one turn", "You punch the opponent so hard, that they take 30 damage. Accuracy 7", "None", "Mythical", MetalArm, "None"),
            new Card("Midas' Hand", "Arm", "Legendary", 4, 4, 4, "All that gliters, is in fact, gold", "Gain an extra item from your next dig", "Change your opponents arms to gold. (Stunning) Accuracy: 9", "While this part is equipped, all other equipped parts have their stats and abilities replaced with this bodypart's stats", "Divine", MidasHand, "None"),
            new Card("Mirror Head", "Head", "Legendary", 0, 0, 0, "Look at you, look at me, what do you see?", "Use one of your opponent's abilities", "Use one of your opponent's abilities", "None", "Mythical", MirrorHead, "None"),
            new Card("Molten Torso", "Torso", "Rare", 10, 0, 0, "Let your worries melt away...", "If 5 hexagons away from enemy player, apply a random curse on the enemy", "Damage melee attackers by 1 damage per hit. Accuracy 16", "None", "Magical", MoltenTorso, "None"),
            new Card("Monkey's Paw", "Arm", "Legendary", 0, 0, 0, "Careful what you wish for...", "Increase a stat of your choice by 5. Draw an extra car from your nedxt dig and discard one card of your choice", "Reduce the opponent's attack or speed, your choice, by 5 for one turn. Accuracy 14", "Decrease each other stat by 2", "Mythical", MonkeysPaw, "None"),
            new Card("Mushroom Cap", "Head", "Common", 1, 1, 1, "This massive fungus leaves mushroom for improvement", "Pull part of the mushroom out and eat it. Granting you increased speed by 2, only used in one turn.", "Use this ability to lower the enemies attack by 5 for 1 turn. Accuracy 16", "None", "Plant", MushroomCap, "None"),
            new Card("Porcelain Arm", "Arm", "Uncommon", -5, 0, 2, "This thing's a liability...", "You may attempt to swap this arm with one of your opponenets. Range of 1, Accuracy 7", "Deal 12 damage as a melee attack, but take 3 damage. Accuracy 17", "None", "Doll", PorcelainArm, "None"),
            new Card("Pumpkin", "Head", "Common", 12, -2, 0, "Plump, ripe and orange", "Lob this head at the enemy cancelling thier next turn but lose this item", "Pumpkin seed ranged attack for 10 damage. Accuracy 15", "None", "Plant", Pumkin, "None"),
            new Card("Rabbit's Foot", "Leg", "Uncommon", 0, -2, 0, "Lucky you!", "Draw 1 item when discovered. Climb over an obstacle.", "If there is an item cache 5-7 hexagons, use this to get to the item cache. Accuracy 16", "None", "Creature", RabbitsFoot, "None"),
            new Card("Sasquatch Leg", "Leg", "Rare", 14, -2, 0, "You never could sit still for the camera", "Gain 5 speed for one turn.", "Gain 5 speed for one turn.", "None", "Creature", SasquatchLeg, "None"),
            new Card("Shadowy Center", "Torso", "Rare", 15, -3, 0, "Dark... darker... yet darker", "Go to an empty \"grave site\" of your choice", "Increase your next basic attack by 10. ", "None", "Mythical", ShadowyCenter, "None"),
            new Card("Slimy Center", "Torso", "Legendary", 30, 0, 0, "Gross",  "If 6 hexagons away, throw a small slime at opponent target, choosing to disable one ability of your choice for one turn. Accuracy: 8", "If 6 hexagons away, throw a small slime at opponent target, choosing to disable one ability of your choice, for one turn in combat phase. Accuracy: 8", "Lose 2 items", "Magical", SlimyCenter, "None"),
            new Card("Snake", "Arm", "Common", -5, 2, 0, "Your victims are HISS-tory", "Lay down a trap on one of the grave sites. If site is diggest, that person loses a equipped body part of their choice", "You gain a melee attack that deal 7 damage and poisons your opponent, which deals 2 damage for 3 turns. Accuracy 12", "None", "Creature", Snake, "None"),
            new Card("Spider Leg", "Leg", "Uncommon", 7, 3, 1, "Great for creeping and crawling", "Climb over an obstacle OR Gain a web shot that lowers your opponent's speed by 3. Range of 5, Accuracy 14.", "Climb over an obstacle OR Gain a web shot that lowers your opponent's speed by 3. Range of 5, Accuracy 14.", "None", "Creature", SpiderLegs, "None"),
            new Card("Stick Leg", "Leg", "Common", -9, 0, 2, "Stick with this, and it'll take you where you need to go", "If your speed is lower than 6, use this to increase your speed by 3, otherwise increase by 1","If your speed is lower than 6, use this to increase your speed by 3, otherwise increase by 1", "None", "Scarecrow", StickLeg, "None"),
            new Card("Stoney Chest", "Torso", "Rare", 16, 0, -1, "For those hard of heart, and in tune with the earth", "None", "If head to head against opponent, give him a chest bump dealing 30 damage. Accuracy 8", "None", "Elemental", StoneyChest, "None"),
            new Card("Straw Head", "Head", "Common", -4, 2, 0, "Never underestimate the scarecrow", "Go to the nearest mound, works on both \"digged\" or not", "If your attack is lower than 7, increase next attack by 10, if not lower than 7, increase attack by 3. Accuracy 12", "None", "Scarecrow", StrawHead, "None"),
            new Card("Tentacle", "Arm", "Common", 0, 0, 0, "Calamari, anyone?", "If in a mound, draw an extra card", "Slap them in the face from afar based on your attack.  Accuracy: 12", "None", "Creature", Tentacle, "None"),
            new Card("Troll Leg", "Leg", "Rare", 15, 0, -2, "Who need weapon? Troll chase down prey", "Use those troll muscles and increase speed by 5 for one turn", "Use mighty Stomp to attack for 15. Accuracy 13", "None", "Mythical", TrollLeg, "None"),
            new Card("Troll Torso", "Torso", "Rare", 18, 0, -2, "Troll strong, like bear. Smell like bear too", "Troll the enemy and move him to an empty grave site", "You go so crazy that you somehow hit the opponent for 14 damage. Range of 1, Accuracy of 14.", "None", "Mythical", TrollTorso, "None"),
            new Card("Venus Fly Trap", "Arm", "Common", 0, 2, 0, "This thing eats more than just flies", "Lay \"Beetles\", \"Leechs\" or \"Worms\" curse on a burial site of your choice as a trap that automatically attaches to the next player that digs the site", "You gain a melee attack which deals 10 damage and lowers their speed by 4. Accuracy of 12", "None", "Creature", VenusFlyTrap, "None"),
            new Card("Werewolf Head", "Head", "Legendary", 10, 0, 2, "Looks like meat's back on the menu!", "You may consume 1 body part per turn to increase health by 10. Accuracy: 16", "You may consume 1 body part per turn to increase health by 10. Accuracy: 16", "None", "Mythical", WerewolfHead, "None"),
            new Card("Wings", "Torso", "Rare", 0, 0, 0, "Take to the skies!", "Can pass over obstacles without using an action. Push the enemy 4 hexagons in any direction", "If 5 hexagons away, use range wind attack that deals 12 damage. Accuracy: 10. Otherwise, use wind attack based off your attack. Accuracy: 8", "None", "Mythical", Wings, "None"),
            new Card("Wolf Claws", "Arm", "Common", 0, 2, 0, "Rip and tear!", "None", "If head to head, use this ability to deal 12 damage. Accurary: 12", "None", "Creature", WolfClaws, "None"),    
        };
    }
}
