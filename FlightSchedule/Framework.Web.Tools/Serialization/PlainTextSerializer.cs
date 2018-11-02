namespace Framework.Web.Tools.Serialization
{
    public class PlainTextSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return objectToSerialize.ToString();
        }
    }
}