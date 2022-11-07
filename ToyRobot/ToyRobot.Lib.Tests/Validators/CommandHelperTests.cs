using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Lib.Models;
using ToyRobot.Lib.Validators;

namespace ToyRobot.Lib.Tests.Validators
{
    public class CommandHelperTests
    {
        [Fact]
        public void IsValidCommand()
        {
            Assert.True(CommandHelpers.IsValidCommand("PLACE", true));
            Assert.False(CommandHelpers.IsValidCommand("MOVE", true));
            Assert.True(CommandHelpers.IsValidCommand("MOVE", false));
            Assert.True(CommandHelpers.IsValidCommand("RIGHT", false));
            Assert.True(CommandHelpers.IsValidCommand("LEFT", false));
            Assert.True(CommandHelpers.IsValidCommand("REPORT", false));
        }

        [Fact]
        public void IsValidParam()
        {
            Assert.True(CommandHelpers.IsValidParam("1,2,NORTH", true));
            Assert.True(CommandHelpers.IsValidParam("1,2", false));
            Assert.False(CommandHelpers.IsValidParam("1,2", true));
            Assert.False(CommandHelpers.IsValidParam("1", false));
            Assert.False(CommandHelpers.IsValidParam("X,Y", false));
            Assert.False(CommandHelpers.IsValidParam("7,8", false));
            Assert.False(CommandHelpers.IsValidParam("1,2,COOL", false));
            Assert.False(CommandHelpers.IsValidParam("1,2,NORTH,1", false));
        }

        [Fact]
        public void IsValidPosition()
        {
            Assert.True(CommandHelpers.IsValidPosition(1,2));
            Assert.False(CommandHelpers.IsValidPosition(-11,2));
            Assert.False(CommandHelpers.IsValidPosition(1,-2));
            Assert.False(CommandHelpers.IsValidPosition(11,12));
        }

        [Fact]
        public void ParseCommandParams()
        {
            var position = CommandHelpers.ParseCommandParams("1,2,NORTH");
            Assert.Equal(1, position.X);
            Assert.Equal(2, position.Y);
            Assert.Equal(Direction.NORTH, position.Direction);

            position = CommandHelpers.ParseCommandParams("3,4");
            Assert.Equal(3, position.X);
            Assert.Equal(4, position.Y);
            Assert.Null(position.Direction);
        }
    }
}
