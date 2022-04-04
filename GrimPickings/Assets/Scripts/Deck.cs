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
        public string ability;
        public string curse;
        public string type;
        public Sprite img;
        public string gesture;

        public Card(string nameVal, string bodyPartVal, string rarityVal, int healthVal, int attackVal, int speedVal, string abilityVal, string curseVal, string typeVal, Sprite imgVal, string gestureVal)
        {
            name = nameVal;
            bodyPart = bodyPartVal;
            rarity = rarityVal;
            health = healthVal;
            attack = attackVal;
            speed = speedVal;
            ability = abilityVal;
            curse = curseVal;
            type = typeVal;
            img = imgVal;
            gesture = gestureVal;
        }
    }

    public List<Card> partsCardDeck = new List<Card>();
    //Image Sprites for each card
    [SerializeField] private Sprite DragonHead, Tentacle, GorgonHead, HorseLeg, WolfClaws, Wings, GiantEye, CrabClaw, VampireHead, WerewolfHead, MinotaurHead, JackalopeHead, DeathsHood, PorcelainArm, PorcelainLeg, PorcelainTorso, KnightsGreaves, KnightsGauntlets, 
        KnightsChestPlate, LichsArm, BearClaws, MidasHand, VenusFlyTrap, JiangshiLeg, RabbitsFoot, SandyLeg, SpiderLegs, ImpishLeg, SlimyCenter, Egg, ShadowyCenter, KappaShell, StoneyChest, AngelsHead, StrawHead, StrawBody, StrawArm, StickLeg, MushroomCap, IcyLeg, 
        FireArm, WindyLeg, HedgehogQuills, CrystallineTorso, MirrorHead, ExsArm, FeatherBody, FeatherLeg, MetalArm, MetalBody, BrainInAJar, Globe, CentipedeLegs, CentipedeBody, LionArm, CatHead, CatLegs, LizardHead, LizardBody, LizardArm, BoarsHead, LampreyArm, 
        ChitonousTorso, ChitonousLeg, TrollLeg, MoltenTorso, InfernalClaws, MonkeysPaw, EldritchVoid, Snake, SasquatchLeg, Pumkin, JackOLantern, ClownHead, BigShoe, PhotonegativeHead, SnowGlobe, TrollTorso, GlassCannon;

    void Awake()
    {
        createDeck();
    }

    //this runs on awake becuase it uses image references and can't be initalized before the game is started
    void createDeck()
    {
        partsCardDeck = new List<Card>() {
            new Card("Dragon Head", "Head", "Rare", 0, 0, 0, "So, what kind of dragon are you? Gathering Phase: Light three hexagans on fire around the map. Combat Phase: Gain a fire breath that shoots 3 hexagons forward for 15 attack. Accuracy: 13 ", "None", "Mythical", DragonHead, "None"),
            new Card("Tentacle", "Arm", "Common", 0, 0, 0, "What is wrong with you? Gathering Phase: if in a mound, draw an extra card. Combat Phase: Slap them in the face from afar based on your attack.  Accuracy: 12", "None", "Creature", Tentacle, "None"),
            new Card("Gorgon Head", "Head", "Rare", 0, 0, 0, "Let me at least get into a pose. Opponent gains -3 penalty to speed and attack dice rolls until your next turn. Accuracy: 15", "Upon obtaining, lose any other heads in inventory", "Upon obtaining, lose any other heads in held inventory", GorgonHead, "None"),
            new Card("Horse Leg", "Leg", "Uncommon", -5, 0, 3, " What the...In gathering phase, while moving, increase speed by 3. In combat have a small chance to nullify or stun a body part from the opponent. Accuracy: 7", "None", "Mythical", HorseLeg, "None"),
            new Card("Wolf Claws", "Arm", "Common", 0, 2, 0, "Those look pretty sharp. If head to head, use this ability to deal 12 damage. Accurary: 12", "None", "Creature", WolfClaws, "None"),
            new Card("Wings", "Torso", "Rare", 0, 0, 0, "Can pass over obstacles without using an action, Angels be with me. Gathering Phase: push the enemy 4 hexagons in any direction. Combat Phase: If 5 hexagons away, use range wind attack that deals 12 damage. Accuracy: 10. Otherwise, use wind attack based off your attack. Accuracy: 8", "None", "Mythical", Wings, "None"),
            new Card("Giant Eye", "Head", "Rare", 0, 0, 0, "Draw an extra card when exhuming a resting site, In both Gathering phase and combat phase: Stare deep into the soul of your opponent. Choose one ability that the opponent has that is not on cooldown, they may only use that ability next turn. Range 6, Accuracy 7", "None", "Divine", GiantEye, "None"),
            new Card("Crab Claw", "Arm", "Uncommon", 0, 0, 0, "What are you going to do with that? Gathering Phase: Just a -2  speed on opponent. Combat Phase: Melee attack that deals 14 damage. Target gains -2 penalty to speed rolls until your next turn. Accuracy: 9", "None", "Creature", CrabClaw, "None"),
            new Card("Vampire Head", "Head", "Rare", 0, 0, 0, "What kind of blood type are you? Melee attack that deals 10 damage and heals self for 4 health. Accuracy: 14", "None", "Mythical", VampireHead, "None"),
            new Card("Werewolf Head", "Head", "Legendary", 10, 0, 2, "Someone's hungry. Gathering and Combat Phase: you may consume 1 body part per turn to increase health by 10. Accuracy: 16", "None", "Mythical", WerewolfHead, "None"),
            new Card("Minotaur Head", "Head", "Uncommon", 0, 3, 0, "In combat phase, increase your attack by 2 if you move all of your movement in a straight line, I'm not a bull alright! Melee attack that does 15 damage. Accuracy: 12", "None", "Mythical", MinotaurHead, "None"),
            new Card("Jackalope Head", "Head", "Common", 0, 0, 2, "Halloween FOREVER! If you pull \"Leech,\" \"Beetles,\" or \"Worms,\" curse, use this to discard them. In combat, if the opponent player attacks counter with your glare, which reduces the speed by 1 for their next turn. Accuracy 15", "None", "Mythical", JackalopeHead, "None"),
            new Card("Death's Hood", "Head", "Legendary", 3, 0, 3, "You may ignore an effect that causes you to lose body parts once, You must use this head, One step closer. In gathering phase, use this to teleport to a empty \"Grave.\" In battle phase, you may teleport to the nearest available item space. Accuracy 12", "This head automatically equips and cannot be removed as long as this curse is active", "Divine", DeathsHood, "None"),
            new Card("Porcelain Arm", "Arm", "Uncommon", -5, 0, 2, "Your arm is pretty fragile, but that won't stop you. Gathering Phase: You may attempt to swap this arm with one of your opponenets. Range of 1, Accuracy 7. Combat Phase: Deal 12 damage as a melee attack, but take 3 damage. Accuracy 17", "None", "Doll", PorcelainArm, "None"),
            new Card("Porcelain Leg", "Leg", "Uncommon", -5, 0, 2, "Your leg is pretty fragile, but that won't stop you. Deal 14 damage as a melee attack, but take 4 damage. Accuracy 17", "None", "Doll", PorcelainLeg, "None"),
            new Card("Porcelain Torso", "Torso", "Uncommon", -3, 0, 7, "Apply either \"Leech\", \"Worms\", or  \"Beetles\". on the opponent. Accuracy: 13", "None", "Doll", PorcelainTorso, "None"),
            new Card("Knight's Greaves", "Leg", "Rare", 15, 0, -1, "Gathering and Combat Phase:  paralyze one of the legs from the opponent.  Accuracy 10", "You may not carry a head", "Dullahan", KnightsGreaves, "None"),
            new Card("Knight's Gauntlets", "Arm", "Rare", 0, 5, 0, "Gathering and Combat Phase: paralyze one of the arms from the opponent. Accuracy 10", "You may not carry a head", "Dullahan", KnightsGauntlets, "None"),
            new Card("Knight's Chest Plate", "Torso", "Rare", 12, 0, -1, "In combat phase, paralyze the torso from the opponent. Accurarcy 9", "You may not carry a head", "Dullahan", KnightsChestPlate, "None"),
            new Card("Lich's Arm", "Arm", "Legendary", 0, 0, 0, "Gathering: Lob dark energy at your foe slowing thier speed by 4 for the next turn. Combat: Gain a dark magic range attack. Range: 5 hexes, Attack: 15, Accuracy: 10", "None", "Skeleton", LichsArm, "None"),
            new Card("Bear Claws", "Arm", "Uncommon", 0, 3, 0, "If you use a basic attack, enemy loses 3 health at beginning of their next turn", "None", "Creature", BearClaws, "None"),
            new Card("Midas' Hand", "Arm", "Legendary", 4, 4, 4, "Gathering: Gain an extra item from your next dig Combat:Change your opponents arms to gold. (Stunning) Accuracy: 9", "While this part is equipped, all other equipped parts have their stats and abilities replaced with this bodypart's stats", "Divine", MidasHand, "None"),
            new Card("Venus Fly Trap", "Arm", "Common", 0, 2, 0, "You won't let your prey get away.  Gathering Phase: Lay \"Beetles\", \"Leechs\" or \"Worms\" curse on a burial site of your choice as a trap that automatically attaches to the next player that digs the site. Combat Phase: You gain a melee attack which deals 10 damage and lowers their speed by 4. Accuracy of 12", "None", "Creature", VenusFlyTrap, "None"),
            new Card("Jiangshi Leg", "Leg", "Rare", -5, 3, 0, "Gathering Phase: Climb over an obstacle. Combat Phase: After a basic attack, you can use this ability to move 5 spaces", "None", "Mythical", JiangshiLeg, "None"),
            new Card("Rabbit's Foot", "Leg", "Uncommon", 0, -2, 0, "Draw 1 item when discovered, Gathering Phase: Climb over an obstacle. Combat Phase: If there is an item cache 5-7 hexagons, use this to get to the item cache. Accuracy 16", "None", "Creature", RabbitsFoot, "None"),
            new Card("Sandy Leg", "Leg", "Common", 7, 0, 0, "Gain a wave of sand that limits your opponents speed to 1 for a single turn. Range of 3, Accuracy 11", "None", "Magical", SandyLeg, "None"),
            new Card("Spider Legs", "Leg", "Uncommon", 7, 3, 1, "Gathering and Combat Phase: Climb over an obstacle. OR Gain a web shot that lowers your opponent's speed by 3. Range of 5, Accuracy 14.", "None", "Creature", SpiderLegs, "None"),
            new Card("Impish Leg", "Leg", "Common", 7, 1, 0, "You're a tricky one. Force your opponent to drop an item of your choice. Range of 3, Accuracy of 7", "None", "Magical", ImpishLeg, "None"),
            new Card("Slimy Center", "Torso", "Legendary", 30, 0, 0, "You're so slimy! Gathering and Combat Phase: if 6 hexagons away, throw a small slime at opponent target, choosing to disable one ability of your choice, for one turn in combat phase. Accuracy: 8", "Lose 2 items", "Magical", SlimyCenter, "None"),
            new Card("Egg", "Torso", "Uncommon", -6, 4, 0, "You're such a chicken, you know that? Gathering Phase: Throw egg at enemy, just to reduce his speed by 1 for one turn. Combat Phase: If 2 hexagons away, throw part of egg at opponent, dealing 4 damage. Accuracy 18", "If this ability is used three times, discard the body part and ability.", "Creature", Egg, "None"),
            new Card("Shadowy Center", "Torso", "Rare", 15, -3, 0, "Wha what, where are you? During the gathering phase, use this to go to an empty \"grave site\" of your choice. In combat, use this to increase your next basic attack by 10. ", "None", "Mythical", ShadowyCenter, "None"),
            new Card("Kappa Shell", "Torso", "Rare", 15, 0, -4, "Gathering Phase: throw a small Kappa at the enemy that steals a item of your choice. Combat Phase: So, you like turtles huh? Go into your shell and take no damage. Accuracy 6", "None", "Creature/Divine", KappaShell, "None"),
            new Card("Stoney Chest", "Torso", "Rare", 16, 0, -1, "If head to head against opponent, give him a chest bump dealing 30 damage. Accuracy 8", "None", "Elemental", StoneyChest, "None"),
            new Card("Angel's Head", "Head", "Rare", 0, 0, 0, "You may ignore one curse from a body part, During gathering phase, use ability to get rid of two body part curses. In combat phase, use this ability to get a random curse and apply it to the opponent. Accuracy : 10", "None", "Divine", AngelsHead, "None"),
            new Card("Straw Head", "Head", "Common", -4, 2, 0, "Gathering Phase: go to the nearest mound, works on both \"digged\" or not.  Combat phase: If your attack is lower than 7, increase next attack by 10, if not lower than 7, increase attack by 3. Accuracy 12", "None", "Scarecrow", StrawHead, "None"),
            new Card("Straw Body", "Torso", "Common", -3, 0, 2, "If you are lower than 50% health use this to recover 15 heatlh, if not lower, increase health by 5. Accuracy 13", "None", "Scarecrow", StrawBody, "None"),
            new Card("Straw Arm", "Arm", "Common", -3, 0, 2, "Look what I found! Throw a needle at the opponent that deals 13 damage. Accuracy 15", "None", "Scarecrow", StrawArm, "None"),
            new Card("Stick Leg", "Leg", "Common", -9, 0, 2, "If your speed is lower than 6, use this to increase your speed by 3, otherwise increase by 1. Can be used in both gathering phase and combat phase.", "None", "Scarecrow", StickLeg, "None"),
            new Card("Mushroom Cap", "Head", "Common", 1, 1, 1, "Gathering Phase: Pull part of the mushroom out and eat it. Granting you increased speed by 2, only used in one turn. Combat Phase: Use this ability to lower the enemies attack by 5 for 1 turn. Accuracy 16", "None", "Plant", MushroomCap, "None"),
            new Card("Icy Leg", "Leg", "Rare", -3, 0, 6, "Gathering and Combat Phase: Reduce opponents speed by 3 for 1 turn. Accuracy 13", "None", "Elemental", IcyLeg, "None"),
            new Card("Fire Arm", "Arm", "Rare", -3, 6, 0, "Shoot a fireball. Range: 6 hexes. Damage: 15. Accuracy: 13", "None", "Elemental", FireArm, "None"),
            new Card("Windy Leg", "Leg", "Uncommon", 0, 0, 4, "You blow people away. Shoot a tornado at your opponent, sending them back 7 spaces. Range of 4, Accuarcy of 12", "None", "Elemental", WindyLeg, "None"),
            new Card("Hedgehog Quills", "Torso", "Uncommon", 0, -2, 2, "Deal 1 damage to opponent when they hit you with a melee attack, Gathering and Combat Phase:Increase your speed to max for one turn. Accuracy 10", "None", "Creature", HedgehogQuills, "None"),
            new Card("Crystalline Torso", "Torso", "Rare", 17, 0, -3, "Gathering Phase: If forced to drop a body part, you may instead offer part of your crystal, lowering your max health by 7. Combat Phase: Reduce damage from an opponents attack by 3 for 1 turn", "None", "Crystal", CrystallineTorso, "None"),
            new Card("Mirror Head", "Head", "Legendary", 0, 0, 0, "Use one of your opponent's abilities", "None", "Mythical", MirrorHead, "None"),
            new Card("Ex's Arm", "Arm", "Rare", 0, 2, 0, "Hit'em with the flowers! Gathering Phase: Throw the flowers at the opponent and that opponent loses his head. Combat Phase: Deal 20 damage as a melee attack. Accuracy: 8", "Basic attacks deal 1 self damage", "Person", ExsArm, "None"),
            new Card("Feather Body", "Torso", "Common", -3, 0, 1, "You can chicken out an go back to the hub and move from there. In combat phase, use this to return to where you started, Accuracy 18, however, if you don't want to move, then use this card to increase basic attack by 5.", "None", "Creature", FeatherBody, "None"),
            new Card("Feather Leg", "Leg", "Common", -3, 0, 1, "You move like a chicken, but are very fast. In gathering phase, increase speed by 3. Combat, increase speed by 2 for one turn. Accuracy 13", "None", "Creature", FeatherLeg, "None"),
            new Card("Metal Arm", "Arm", "Uncommon", 0, 2, -1, "In gathering phase: If head to head in gathering face, punch the enemy and stun him for one turn.  Combat Phase:You punched the dude so hard, that he took 30 damage. Accuracy 7", "None", "Mythical", MetalArm, "None"),
            new Card("Metal Body", "Torso", "Uncommon", 3, 0, -1, "You shined your body so much, that you gained 15 health. ", "None", "Mythical", MetalBody, "None"),
            new Card("Brain in a Jar", "Head", "Rare", 0, 0, 0, "You may use 2 abilities in one turn as long as you do not move during that turn, Gathering and Combat Phase: You outsmarted your opponent, move 5-7 hexagons spaces behind the opponent. Accuracy 9", "None", "Magical", BrainInAJar, "None"),
            new Card("Globe", "Torso", "Legendary", 0, 6, -5, "During combat phase, end your turn. This ability cannot be used if you have moved this turn. Deal 10 extra damage for your next attack. This cannot be stacked.", "If equipped you can only use rare body parts. ", "Divine", Globe, "None"),
            new Card("Centipede Legs", "Leg", "Uncommon", 0, -1, 1, "Gathering and Combat Phase: How fragile you are. Gain an extra 3 speed for 1 turn. Accuracy 15", "None", "Creature", CentipedeLegs, "None"),
            new Card("Centipede Body", "Torso", "Uncommon", 0, -1, 1, "Deflect all damage from one attack but discard this part. Accuracy 13", "None", "Creature", CentipedeBody, "None"),
            new Card("Lion Arm", "Arm", "Rare", 7, 7, 0, "Gathering: Negate an opponents attack Combat: Take thorn out of your paw. Healing for 10 health. Accuracy 10", "If basic attack, lost 1 health for 2 turns", "Creature", LionArm, "None"),
            new Card("Cat Head", "Head", "Uncommon", 0, 2, 0, "Awwwhhhh. Gathering Phase: Increase speed by 2 for one turn. Combat Phase: Increase your attack by 1 for a single turn. Accuracy 18", "None", "Creature", CatHead, "None"),
            new Card("Cat Legs", "Leg", "Uncommon", 0, 0, 2, "You go some moves. Increase your speed by 1 for a single turn. Accuracy 18", "None", "Creature", CatLegs, "None"),
            new Card("Lizard Head", "Head", "Common", 0, 0, 1, "Regenerate for 15 health. Accuracy 14", "Lose a leg of your choice", "Creature", LizardHead, "None"),
            new Card("Lizard Body", "Torso", "Common", 0, 0, 1, "Regenerate for 15 health. Accuracy 14", "Lose a leg of your choice", "Creature", LizardBody, "None"),
            new Card("Lizard Arm", "Arm", "Common", 0, 0, 1, "Regenerate for 15 health. Accuracy 14", "Lose a leg of your choice", "Creature", LizardArm, "None"),
            new Card("Boar's Head", "Head", "Uncommon", -2, 2, 2, "Ramming Speed! Gathering Phase: Head straight for a \"Grave Site\" Combat Phase: Deal 20 damage to opponent. Accuracy 10", "None", "Creature", BoarsHead, "None"),
            new Card("Lamprey Arm", "Arm", "Rare", 0, 0, 0, "Steal 2 health on attack, Latch onto opponent a draining 15 heath and reducing thier speed by 2 for 1 turn. Accuracy 12", "None", "Mythical", LampreyArm, "None"),
            new Card("Chitonous Torso", "Torso", "Uncommon", 10, 0, -1, "Increase strength by 5 for one turn. Lose 5 Health. Accuracy 16", "None", "Mythical", ChitonousTorso, "None"),
            new Card("Chitonous Leg", "Leg", "Uncommon", 10, 0, -1, "Increase Attack by 5 for one turn. Lose 5 Health. Accuracy 16", "None", "Mythical", ChitonousLeg, "None"),
            new Card("Troll Leg", "Leg", "Rare", 15, 0, -2, "Gathering: Use those troll muscles and increase speed by 5 for one turn Combat: Use mighty Stomp to attack for 15. Accuracy 13", "None", "Mythical", TrollLeg, "None"),
            new Card("Molten Torso", "Torso", "Rare", 10, 0, 0, "Gathering Phase: if 5 hexagons away from enemy player, apply a random curse on the enemy. Combat Phase:Damage melee attackers by 1 damage per hit. Accuracy 16", "None", "Magical", MoltenTorso, "None"),
            new Card("Infernal Claws", "Arm", "Rare", 0, 0, 0, "Hitting opponent sets them on fire, dealing 1 damage for 3 turns, Gathering: Hurl a fireball at your enemy disentegrating a body part of thier choice. Combat: Ranged Fireball for 15 damage. Range: 5 Hexagons Accuracy 12", "None", "Magical", InfernalClaws, "None"),
            new Card("Monkey's Paw", "Arm", "Legendary", 0, 0, 0, "Increase a stat of your choice by 5, Gathering: Draw an extra car from your nedxt dig and discard one card of your choice. In combat phase, reduce the opponent's attack or speed, your choice, by 5 for one turn. Accuracy 14", "Decrease each other stat by 2", "Mythical", MonkeysPaw, "None"),
            new Card("Eldritch Void", "Torso", "Rare", 0, 0, 0, "Discard one held body part or item and draw a card to replace it.", "None", "Mythical", EldritchVoid, "None"),
            new Card("Snake", "Arm", "Common", -5, 2, 0, "You always were a snake in the grass. Gathering Phase: lay down a trap on one of the grave sites. If site is diggest, that person loses a equipped body part of their choice.  Combat Phase: You gain a melee attack that deal 7 damage and poisons your opponent, which deals 2 damage for 3 turns. Accuracy 12", "None", "Creature", Snake, "None"),
            new Card("Sasquatch Leg", "Leg", "Rare", 14, -2, 0, "You never could sit still for the camera. Gathering and Combat Phase: Gain 5 speed for one turn.", "None", "Creature", SasquatchLeg, "None"),
            new Card("Pumpkin", "Head", "Common", 12, -2, 0, "Gathering: Lob this head at the enemy cancelling thier next turn but lose this item. Combat: Pumpkin seed ranged attack for 10 damage. Accuracy 15", "None", "Plant", Pumkin, "None"),
            new Card("Jack o' Lantern", "Head", "Uncommon", 12, 1, -2, "Gathering Phase: If you pull \"Angry Raccoon,\" \"Bandit,\" or \"Grave Keeper\" curse cards, ignore them otherwise, increase speed by 3 for one turn. Combat Phase: If two hexagons away, Throw part of your pumpkin head at the  enemy for 11 damage. Accuracy 11", "Plant", "None", JackOLantern, "None"),
            new Card("Clown Head", "Head", "Rare", -5, 5, 0, "If you pull \"Angry Raccoon,\" \"Bandit,\" or \"Grave Keeper\" curse cards, ignore them, Gathering and Combat Phase: Why are you laughing, this is serious. Lower your oppoenents next accuracy roll by 4. Accuracy of 12", "None", "Person", ClownHead, "None"),
            new Card("Big Shoe", "Leg", "Rare", 0, 5, -2, "Gathering Phase: Add 4 to your movement roll. Combat Phase: Kick your opponent for 10 damage. Accuracy 13", "None", "Shoe", BigShoe, "None"),
            new Card("Photonegative Head", "Head", "Legendary", 0, 0, 0, "Invert all stat changes from other body parts, You're always so negative. Lower your opponents attack by 3 for one turn. Range of 5, Accuracy of 13", "None", "Divine", PhotonegativeHead, "None"),
            new Card("Snow Globe", "Torso", "Common", 0, 0, 0, "Increase damage dealt by 1 if you move during your turn, You make it start to snow, somehow. Lower your opponents speed by 2. ", "None", "Divine", SnowGlobe, "None"),
            new Card("Troll Torso", "Torso", "Rare", 18, 0, -2, "Gathering Phase: Troll the enemy and move him to an empty grave site. Combat Phase: You go so crazy that you somehow hit the opponent for 14 damage. Range of 1, Accuracy of 14.", "None", "Mythical", TrollTorso, "None"),
            new Card("Glass Cannon", "Arm", "Rare", -4, 2, 0, "Gathering Phase: You use your cannon and destroy the enemies body part of your choice. Range of 3 Hexagons fires attack for 14 damage. Accuracy 12. During Combat Phase, gain a ranged attack with a range of 3 hexagons for 18 damage, Accuracy 12, but you will lose 4 health when using this ability.", "None", "Mythical", GlassCannon, "None")
        };
    }
}
