namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void RobotPropertiesShouldWorkProperly()
        {
            var robot = new Robot("Pesho", 20);
            var name = robot.Name;
            var battery = robot.Battery;
            Assert.AreEqual(name, robot.Name);
            Assert.AreEqual(battery, robot.Battery);
            Assert.AreEqual(battery, robot.MaximumBattery);
        }

        [Test]
        public void RobotManagerShouldInitializeProperly()
        {
            var robotmanager = new RobotManager(20);
            Assert.AreEqual(robotmanager.Capacity, 20);
        }
        
        [Test]
        public void RobotManagerShouldThrowArgumentExceptionWhenIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var robotmanager = new RobotManager(-1);
            });
        }

        [Test]
        public void RobotManagerAddShouldThrowInvalidOperationExceptionWhenTryToAddRobotWithNameThatAllreadyExist()
        {
            var robot = new Robot("Pesho", 20);

            var RobotManager = new RobotManager(2);

            RobotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager.Add(robot);
            }, $"There is already a robot with name {robot.Name}!");
        }

        [Test]
        public void RobotManagerAddShouldThrowInvalidOperationExceptionWhenCapacityIsFull()
        {
            var robot = new Robot("Pesho", 20);

            var RobotManager = new RobotManager(1);

            RobotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager.Add(robot);
            }, "Not enough capacity!");
        }

        [Test]
        public void RobotManagerAddShouldWorkProperly()
        {
            var robot = new Robot("Pesho", 20);

            var RobotManager = new RobotManager(1);

            RobotManager.Add(robot);

            Assert.AreEqual(1, RobotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveShouldThrowInvalidOperationExceptionWhenThereIsNoRobotWithThatName()
        {
            var robotmanager = new RobotManager(1);
            var robotname = "Ivan";
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotmanager.Remove(robotname);
            }, $"Robot with the name {robotname} doesn't exist!");
        }

        [Test]
        public void RobotManagerRemoveShouldWorkProperly()
        {
            var robotmanager = new RobotManager(1);
            var robotname = "Ivan";
            var robot = new Robot(robotname, 20);
            robotmanager.Add(robot);
            robotmanager.Remove(robotname);
            Assert.AreEqual(0, robotmanager.Count);
        }

        [Test]
        public void RobotManagerWorkShouldThrowInvalidOperationExceptionWhenRobotIsNull()
        {
            var rm = new RobotManager(1);
            var robotname = "Ivan";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rm.Work(robotname, "", 15);
            }, $"Robot with the name {robotname} doesn't exist!");
        }

        [Test]
        public void RobotManagerWorkShouldThrowInvalidOperationExceptionWhenRobotBattryIsNotEnaufForTheJob()
        {
            var rm = new RobotManager(1);
            var robotname = "Ivan";
            var robot = new Robot(robotname, 14);
            rm.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                rm.Work(robotname, "", 15);
            }, $"{robot.Name} doesn't have enough battery!");
        }

        [Test]
        public void RobotManagerWorkShouldWorkProperly()
        {
            var rm = new RobotManager(1);
            var robotname = "Ivan";
            var robot = new Robot(robotname, 14);
            rm.Add(robot);
            rm.Work(robotname, "", 14);
            Assert.AreEqual(0, robot.Battery);
        }

        [Test]
        public void RobotManagerChargeShouldThrowInvalidOperationExceptionWhenRobotIsNull()
        {
            var rb = new RobotManager(1);
            var robotname = "Ivan";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rb.Charge(robotname);
            }, $"Robot with the name {robotname} doesn't exist!");
        }

        [Test]
        public void RobotManagerChargeShouldWorkProperly()
        {
            var rb = new RobotManager(1);
            var robotname = "Ivan";
            var robot = new Robot(robotname, 20);
            rb.Add(robot);
            rb.Work(robotname, "", 20);
            rb.Charge(robotname);
            Assert.AreEqual(20, robot.Battery);
        }
    }
}
