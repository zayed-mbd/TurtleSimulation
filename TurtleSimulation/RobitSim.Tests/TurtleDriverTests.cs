using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleSim;

namespace RobitSim.Tests
{
    [TestClass]
    public class TurtleDriverTests
    {
        [TestMethod]
        public void TurtleDriver_InitialisedTurtleDriver_ControlsTurtle()
        {
            var driver = new TurtleDriver(new Turtle());
            Assert.IsNotNull(driver.Turtle);
        }

        [TestMethod]
        public void TurtleDriver_EmptyCommand_ReportsInvalid()
        {
            var driver = new TurtleDriver(new Turtle());
            var response = driver.Command("");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void TurtleDriver_UnrecognisedCommand_ReportsInvalid()
        {
            var driver = new TurtleDriver(new Turtle());
            var response = driver.Command("XXXX");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void TurtleDriver_RecognisedCommand_ReportsValid()
        {
            var driver = new TurtleDriver(new Turtle());
            var response = driver.Command("MOVE");
            Assert.AreEqual("Turtle cannot move until it has been placed on the table.", response);
        }

        [TestMethod]
        public void TurtleDriver_PlaceCommandWithNoArguments_ReportsInvalid()
        {
            var driver = new TurtleDriver(new Turtle());
            var response = driver.Command("PLACE");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void TurtleDriver_PlaceCommandWithInvalidArguments_ReportsInvalid()
        {
            var driver = new TurtleDriver(new Turtle());
            var response = driver.Command("PLACE XXX");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE 1,X,NORTH");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE X,1,NORTH");
            Assert.AreEqual("Invalid command.", response);
            response = driver.Command("PLACE 1,1,XXX");
            Assert.AreEqual("Invalid command.", response);
        }

        [TestMethod]
        public void TurtleDriver_PlacedAndTurnedLeft_ReportsCorrectPosition()
        {
            var driver = new TurtleDriver(new Turtle());
            driver.Command("PLACE 1,1,NORTH");
            driver.Command("LEFT");
            Assert.AreEqual("1,1,WEST", driver.Command("REPORT"));
        }
    }
}
