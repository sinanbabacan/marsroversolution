using System;
using Xunit;
using ConsoleApp;

namespace MarsRoverTests
{
    public class RoverTests
    {
        Plateau plateau = new Plateau(5, 5);

        [Fact]
        public void SpinLeft_Direction_W_Should_Direction_S()
        {
            // arrange
            var rover = new Rover(plateau, "1 2 W");

            // act
            rover.SpinLeft();

            // assert
            Assert.Equal(Direction.S, rover.Position.Direction);
        }

        [Fact]
        public void SpinRight_Direction_W_Should_Direction_N()
        {
            // arrange
            var rover = new Rover(plateau, "1 2 W");

            // act
            rover.SpinRight();

            // assert
            Assert.Equal(Direction.N, rover.Position.Direction);
        }

        [Fact]
        public void MoveForward_Xis1_Should_Xis0()
        {
            // arrange
            var rover = new Rover(plateau, "1 2 W");

            // act
            rover.MoveForward();

            // assert
            Assert.Equal(0, rover.Position.X);
        }

        [Fact]
        public void MoveForward_Yis2_Should_Yis3()
        {
            // arrange
            var rover = new Rover(plateau, "1 2 N");

            // act
            rover.MoveForward();

            // assert
            Assert.Equal(3, rover.Position.Y);
        }

        [Fact]
        public void ExecuteInstructions_12N_LMLMLMLMM_Should_13N()
        {
            // arrange
            var rover = new Rover(plateau, "1 2 N");

            // act
            rover.ExecuteInstructions("LMLMLMLMM");

            // assert
            Assert.Equal("1 3 N", rover.PositionResult());
        }

        [Fact]
        public void ExecuteInstructions_33E_MMRMMRMRRM_Should_51E()
        {
            // arrange
            var rover = new Rover(plateau, "3 3 E");

            // act
            rover.ExecuteInstructions("MMRMMRMRRM");

            // assert
            Assert.Equal("5 1 E", rover.PositionResult());
        }

        [Fact]
        public void Deploy_33E_Should_33E()
        {
            // arrange
            var rover = new Rover(plateau);

            // act
            rover.Deploy("3 3 E", plateau.XMax, plateau.YMax, plateau.XMin, plateau.YMin);

            // assert
            Assert.Equal("3 3 E", rover.PositionResult());
        }

        [Fact]
        public void Deploy_36E_ShouldThrowException()
        {
            // arrange
            var rover = new Rover(plateau);

            // act
            Action act = () => rover.Deploy("3 6 E", plateau.XMax, plateau.YMax, plateau.XMin, plateau.YMin);

            //assert
            PositionException exception = Assert.Throws<PositionException>(act);

            Assert.Equal("Rover Y coordinate higher from plateau yMax coordinate", exception.Message);
        }

        [Fact]
        public void Deploy_14E_ShouldTrowExcepiton()
        {
            // arrange
            var rover = new Rover(plateau);

            // act
            Action act = () => rover.Deploy("-1 4 E", plateau.XMax, plateau.YMax, plateau.XMin, plateau.YMin);

            //assert
            PositionException exception = Assert.Throws<PositionException>(act);

            Assert.Equal("Rover X coordinate lower from plateau xMin coordinate", exception.Message);
        }
    }
}
