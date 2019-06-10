namespace DirectlineJabber.Demo.Domain
{
    /// <summary>
    /// Authorization object for DirectLine
    /// </summary>
    public class DirectLineAuthResponse
    {
        /// <summary>
        /// Conversation Id
        /// </summary>
        public string conversationId { get; set; }
        /// <summary>
        /// New token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Expiration
        /// </summary>
        public int expires_in { get; set; }
    }
}
