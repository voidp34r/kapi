namespace Service.Kapi.API.Models
{
    /// <summary>
    /// User type
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// Owner
        /// </summary>
        Owner = 0,
        /// <summary>
        /// Admin
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Editor
        /// </summary>
        Editor = 2,
        /// <summary>
        /// Reader
        /// </summary>
        Reader = 3,
    }
}
