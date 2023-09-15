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
    [InlineData("R", "S", "O")]
    [InlineData("R", "E", "S")]
    [InlineData("R", "O", "N")]
    [InlineData("L", "N", "O")]
    [InlineData("L", "S", "E")]
    [InlineData("L", "E", "N")]
    [InlineData("L", "O", "S")]
    public void When_Command_is_X_and_Orientation_is_Y_then_GetNewOrientation_result_is(string command, string orientation, string result)
    {
        Assert.Equal(twoDMovement.GetNewOrientation(orientation, command), result);
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

    private ICoordinatesBase Given_2D_coordinates(int x, int y)
    {
        return new TwoDCoordinates(x, y);
    }

    private ICoordinatesBase When_2D_GetNewCoordinates_is_invoked(
        ICoordinatesBase coordinates,
        ICoordinatesBase coordinatesToBeAdded
        )
    {
        return twoDMovement.GetNewCoordinates(coordinates, coordinatesToBeAdded);
    }

    private void Then_result_is_the_addition_of_both(
        ICoordinatesBase coordinates,
        ICoordinatesBase coordinatesToBeAdded,
        ICoordinatesBase result
        )
    {
        Assert.Equal(coordinates.x + coordinatesToBeAdded.x, result.x);
        Assert.Equal(coordinates.y + coordinatesToBeAdded.y, result.y);
    }
}