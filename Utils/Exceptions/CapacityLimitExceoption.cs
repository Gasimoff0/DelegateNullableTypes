namespace Utils.Exceptions
{
    public class CapacityLimitExceoption: Exception
    {
        public CapacityLimitExceoption(string message) 
            :base(message) { }
    }
}
