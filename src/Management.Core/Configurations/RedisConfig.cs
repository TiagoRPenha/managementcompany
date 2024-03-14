// <summary> RedisConfig, Class responsible for obtaining redis configuration data to be used in events </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
namespace Management.Core.Configurations
{
    public class RedisConfig
    {
        public string Url { get; set; }
        public string StreamName { get; set; }
    }
}
