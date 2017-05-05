namespace SVS.DP.Singleton
{
    public class Singleton
    {
        private Property _property { get; set; }

        public Property GetProperty()
        {
            if (_property == null)
                _property = new Property();

            return _property;
        }
    }
}
