using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleSim;

namespace RobitSim.Tests
{
    [TestClass]
    public class TurtleTests
    {
        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotBeMoved()
        {
            var Turtle = new Turtle();
            var result = Turtle.Move();
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot move until it has been placed on the table.", Turtle.LastError);
        }

        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotBeTurned()
        {
            var Turtle = new Turtle();
            var result = Turtle.Left();
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot turn until it has been placed on the table.", Turtle.LastError);
        }

        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotReportItsPosition()
        {
            var Turtle = new Turtle();
            var result = Turtle.Report();
            Assert.AreEqual("", result);
            Assert.AreEqual("Turtle cannot report it's position until it has been placed on the table.", Turtle.LastError);
        }

        [TestMethod]
        public void Turtle_PlacedOffTable_CannotBePlaced()
        {
            var Turtle = new Turtle();
            var result = Turtle.Place(-1, 0, Facing.North);
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot be placed there.", Turtle.LastError);

            result = Turtle.Place(0, 6, Facing.North);
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot be placed there.", Turtle.LastError);
        }

        [TestMethod]
        public void Turtle_Placed_CanReportItsPosition()
        {
            var Turtle = new Turtle();
            var result = Turtle.Place(3, 2, Facing.East);
            var position = Turtle.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("", Turtle.LastError);
            Assert.AreEqual("3,2,EAST", position);
        }

        [TestMethod]
        public void Turtle_PlacedAndTurnedLeft_ReportsCorrectPosition()
        {
            var Turtle = new Turtle();
            Turtle.Place(1, 1, Facing.North);
            Turtle.Left();
            Assert.AreEqual("1,1,WEST", Turtle.Report());
        }

        [TestMethod]
        public void Turtle_PlacedAndTurnedRight_ReportsCorrectPosition()
        {
            var Turtle = new Turtle();
            Turtle.Place(1, 1, Facing.North);
            Turtle.Right();
            Assert.AreEqual("1,1,EAST", Turtle.Report());
        }

        [TestMethod]
        public void Turtle_PlacedAndMoved_ReportsCorrectPosition()
        {
            var Turtle = new Turtle();
            Turtle.Place(1, 1, Facing.North);
            Turtle.Move();
            Assert.AreEqual("1,2,NORTH", Turtle.Report());
        }

        [TestMethod]
        public void Turtle_PlacedMovedAndTurned_ReportsCorrectPosition()
        {
            var Turtle = new Turtle();
            Turtle.Place(1, 2, Facing.East);
            Turtle.Move();
            Turtle.Move();
            Turtle.Left();
            Turtle.Move();
            Assert.AreEqual("3,3,NORTH", Turtle.Report());
        }
    }
}
