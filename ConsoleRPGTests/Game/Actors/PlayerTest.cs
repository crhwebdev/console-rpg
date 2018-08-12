using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game.Actors
{
    public class PlayerTest
    {
        [Fact]
        public void CanInstantiateAPlayerWithAName()
        {
            var name = "Testy Tess";
            var player = new Player(name);

            Assert.Equal(name, player.Name);
        }


        // DROP METHOD
        [Fact]
        public void PlayerDropMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var playerLocation = new MockLocation("Test Area");
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);

            player.Location = playerLocation;
            player.Inventory.Add(itemTarget);

            // player displays correct error message when passing empty target string
            var playerDropText = player.Drop("").ToString();
            Assert.Equal("There is nothing to drop!", playerDropText);

            //player displays correct error message when getting an item that doesn't exist
            playerDropText = player.Drop("wtf").ToString();
            Assert.Equal("You don't have that item!", playerDropText);

            // player displays correct text when dropping item
            playerDropText = player.Drop(itemTargetName).ToString();
            Assert.Equal(player.Name + " drops the " + itemTarget.Name, playerDropText);

            // player successfully removes item from inventory
            Assert.Empty(player.Inventory);

            // Item Location is set to area Location
            Assert.Equal(playerLocation, itemTarget.Location);

            // player succesfully adds item to Location.Items list
            Assert.Single(playerLocation.Items, itemTarget);

            // sends correct error message if player tries to drop an item that is equiped
            player.EquipSlotMainWeapon = itemTarget;

            playerDropText = player.Drop(itemTargetName).ToString();

            Assert.Equal("You cannot drop an equiped item!", playerDropText);

        }

        //EQUIP METHOD
        [Fact]
        public void PlayerEquipMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var player = new Player(name);
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);
            itemTarget.Location = null;

            player.Inventory.Add(itemTarget);



            var playerEquipText = player.Equip("").ToString();
            Assert.Equal("There is nothing to equip!", playerEquipText);

            playerEquipText = player.Equip("Not A Thing").ToString();
            Assert.Equal("That does not exist in your inventory!", playerEquipText);


            playerEquipText = player.Equip(itemTargetName).ToString();
            Assert.Equal(player.Name + " equips the " + itemTarget.Name, playerEquipText);

            Assert.Empty(player.Inventory);
            Assert.Equal(itemTarget, player.EquipSlotMainWeapon);
            
        }

        //GET METHOD
        [Fact]
        public void PlayerGetMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var playerLocation = new MockLocation("Test Area");
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);
            itemTarget.Location = playerLocation;

            player.Location = playerLocation;
            playerLocation.Items.Add(itemTarget);

            // player displays correct error message when passing empty target string
            var playerGetText = player.Get("").ToString();
            Assert.Equal("There is nothing to get!", playerGetText);

            //player displays correct error message when getting an item that doesn't exist
            playerGetText = player.Get("wtf").ToString();
            Assert.Equal("You cannot get that!", playerGetText);

            // player displays correct text when getting item 
            playerGetText = player.Get(itemTargetName).ToString();
            Assert.Equal(player.Name + " gets the " + itemTarget.Name, playerGetText);

            // player successfully removed item from location
            Assert.Empty(playerLocation.Items);

            // item's Location is set to null
            Assert.Null(itemTarget.Location);

            // player succesfully added item to inventory
            Assert.Single(player.Inventory, itemTarget);
        }

        //SHOWINVENTORY METHOD
        [Fact]
        public void PlayerShowInventoryMethodReturnsAppropriateText()
        {
            var playerName = "Testy Tess";
            var player = new Player(playerName);
            var inventoryItemNames = new List<string>
            {
                "Thing",
                "Other Thing"
            };

            var inventoryItems = new List<MockItemTarget>();

            foreach(var name in inventoryItemNames)
            {
                inventoryItems.Add(new MockItemTarget(name));
            }

            //show player's inventory with no items
            var playerInventoryText = player.ShowInventory().ToString();
            Assert.Equal("You have nothing in your pack, Master./r/nYour equiped items: (head) Empty, (main weapon) Empty, (body) Empty, (hands) Empty, (feet) Empty", playerInventoryText);

            //show player's inventory with one item
            player.Inventory.Add(inventoryItems[0]);
            playerInventoryText = player.ShowInventory().ToString(); 
            Assert.Equal("Master, you have: " + inventoryItems[0].Name + "./r/nYour equiped items: (head) Empty, (main weapon) Empty, (body) Empty, (hands) Empty, (feet) Empty", playerInventoryText);


            //show player's inventory with more than one item
            player.Inventory.Add(inventoryItems[1]);
            playerInventoryText = player.ShowInventory().ToString();
            Assert.Equal("Your Inventory, Master: " + inventoryItems[0].Name + ", " + inventoryItems[1].Name + "./r/nYour equiped items: (head) Empty, (main weapon) Empty, (body) Empty, (hands) Empty, (feet) Empty", playerInventoryText);

            //show player's inventory with an equiped item
            player.EquipSlotMainWeapon = inventoryItems[1];
            player.Inventory.Remove(inventoryItems[1]);
            player.Inventory.Remove(inventoryItems[1]);
            playerInventoryText = player.ShowInventory().ToString();
            Assert.Equal("Master, you have: " + inventoryItems[0].Name + "./r/nYour equiped items: (head) Empty, (main weapon) " + inventoryItems[1].Name + ", (body) Empty, (hands) Empty, (feet) Empty", playerInventoryText);
        }


        // LOOK METHOD
        [Fact]
        public void PlayerLookMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var viewedLocation = new MockLocation("Test Area");
            player.Location = viewedLocation;
            
            //player displays correct text for location as view target
            Assert.Equal(player.Name + " looks around...", player.Look("").ToString());

            //player displays correct text when looking at an Actor as view target            
            var viewedActorTargetName = "View Target";
            var viewedActorTarget = new MockActorTarget(viewedActorTargetName);

            player.Location.Actors.Add(viewedActorTarget);

            Assert.Equal(player.Name + " looks at " + viewedActorTarget.Name, player.Look(viewedActorTargetName).ToString());
        }

        
        // MOVE METHOD
        [Fact]
        public void PlayerMoveMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";          
            var player = new Player(name);
            var startLocation = new MockLocation("Start Area");
            var destinationLocation = new MockLocation("Destination Area");            
            player.Location = startLocation;
            startLocation.ExitNorth = destinationLocation;

            //move to exit without link to new location
            Assert.Equal(player.Name + " cannot move there!", player.Move("south").ToString());
            player.Location = startLocation;

            //no target given
            Assert.Equal(player.Name + " cannot move there!", player.Move("").ToString());
            player.Location = startLocation;

            //move to exit with link to new location
            Assert.Equal(player.Name + " moves...", player.Move("north").ToString());                        
        }


        // SAY METHOD
        [Fact]
        public void PlayerSayMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var sayText = "Hello World!";
            var player = new Player(name);

            Assert.Equal(player.Name + " says: '" + sayText + "'", player.Say(sayText).ToString());
        }

        // UNEQUIP METHOD
        [Fact]
        public void PlayerUnequipMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var player = new Player(name);
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);
            itemTarget.Location = null;

            player.EquipSlotMainWeapon = itemTarget;


            var playerUnequipText = player.Unequip("").ToString();
            Assert.Equal("There is nothing to unequip!", playerUnequipText);

            playerUnequipText = player.Unequip("Not A Thing").ToString();
            Assert.Equal("That is not equiped!", playerUnequipText);


            playerUnequipText = player.Unequip(itemTargetName).ToString();
            Assert.Equal(player.Name + " unequips the " + itemTarget.Name, playerUnequipText);

            Assert.Null(player.EquipSlotMainWeapon);
            Assert.Single(player.Inventory, itemTarget);            
        }
    }

    public class MockActorTarget : Actor
    {
        
        public MockActorTarget(string name) : base(name) {}

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }
    }

    public class MockItemTarget : Item
    {
        public MockItemTarget(string name) : base(name) {}

        public override DisplayText Taken()
        {
            return new DisplayText();
        }

        public override DisplayText Dropped()
        {
            return new DisplayText();
        }
    }

    public class MockLocation : Location
    {        
        public MockLocation(string name) : base(name) {}

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }

        public override DisplayText Enter(Actor actor)
        {            
            //get description of location and add to DisplayText to be returned
            var enterDisplayText = new DisplayText();
            
            return enterDisplayText;
        }
    }
}
