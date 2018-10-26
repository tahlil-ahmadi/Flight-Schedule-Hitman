namespace FlightSchedule.Domain.Model.Flights
{
    public class Route
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        protected Route(){}
        public Route(string origin, string destination)
        {
            origin = origin.ToUpper();
            destination = destination.ToUpper();
            if (origin.Equals(destination)) throw new InvalidRouteException();

            Origin = origin;
            Destination = destination;
        }
    }
}
