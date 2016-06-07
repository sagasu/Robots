namespace Robots
{
    public static class CoordinatesValidator
    {
        public static int Parse(string coordiate)
        {
            var parsedCoordinate = int.Parse(coordiate);
            if (parsedCoordinate >= 50)
                throw new IllegalInputException("Coordinates must be smaller then 50");

            return parsedCoordinate;
        }
    }
}
