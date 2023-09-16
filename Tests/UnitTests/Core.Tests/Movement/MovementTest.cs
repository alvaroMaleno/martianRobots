namespace Core.Tests.Movement;
using martianRobots.Core.Movement;
using martianRobots.Core.Movement.Interfaces;
using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;

public class TwoDMovementTests
{
    private readonly IMovement twoDMovement = new TwoDMovement();

    [Theory]
    [InlineData("R", "N", "E")]
    [InlineData("R", "S", "W")]
    [InlineData("R", "E", "S")]
    [InlineData("R", "W", "N")]
    [InlineData("L", "N", "W")]
    [InlineData("L", "S", "E")]
    [InlineData("L", "E", "N")]
    [InlineData("L", "W", "S")]
    public void When_Command_is_X_and_Orientation_is_Y_then_GetNewOrientation_result_is(string command, string orientation, string result)
    {
        Assert.Equal(twoDMovement.GetNewOrientation(orientation, command), result);
    }

    [Theory]
    [InlineData('N', 0, 1)]
    [InlineData('S', 0, -1)]
    [InlineData('E', 1, 0)]
    [InlineData('W', -1, 0)]
    public void GetForwardCommandFromOrientation_returns_coordinates(char orientation, int x, int y)
    {
        var result = twoDMovement.GetForwardCoordinatesFromOrientation(orientation);
        Assert.True(
            result.x == x && 
            result.y == y
            );
    }

    [Fact]
    public void GetNewCoordinates_returns_addition()
    {
        // Given
        var coordinatesToBeAdded = Given_2D_coordinates(1, 2);
        var coordinates = Given_2D_coordinates(2, 3);
        // When
        var result = When_2D_GetNewCoordinates_is_invoked(coordinates, coordinatesToBeAdded);
        // Then
        Then_result_is_the_addition_of_both(coordinates, coordinatesToBeAdded, result);
    }

    private CoordinatesBase Given_2D_coordinates(int x, int y)
    {
        return new TwoDCoordinates(x, y);
    }

    private CoordinatesBase When_2D_GetNewCoordinates_is_invoked(
        CoordinatesBase coordinates,
        CoordinatesBase coordinatesToBeAdded
        )
    {
        return twoDMovement.GetNewCoordinates(coordinates, coordinatesToBeAdded);
    }

    private void Then_result_is_the_addition_of_both(
        CoordinatesBase coordinates,
        CoordinatesBase coordinatesToBeAdded,
        CoordinatesBase result
        )
    {
        Assert.Equal(coordinates.x + coordinatesToBeAdded.x, result.x);
        Assert.Equal(coordinates.y + coordinatesToBeAdded.y, result.y);
    }
}