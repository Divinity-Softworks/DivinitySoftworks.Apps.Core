namespace System {
    /// <summary>
    /// Extentions for the <seealso langword="string"/> type.
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// Modifies the string to a valid string to be used as file name.
        /// </summary>
        /// <param name="fileName">The original file name.</param>
        /// <returns>A valid string to be used as file name</returns>
        public static string ToValidFileName(this string fileName) {
            foreach (char c in IO.Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '_');
            return fileName;
        }
    }
}
