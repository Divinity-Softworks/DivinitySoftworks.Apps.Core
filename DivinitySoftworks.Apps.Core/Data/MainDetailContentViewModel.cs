namespace DivinitySoftworks.Apps.Core.Data {
    /// <summary>
    /// Interface for the <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
    /// </summary>
    /// <typeparam name="M">The main content.</typeparam>
    /// <typeparam name="D">The details of the main contents.</typeparam>
    public interface IMainDetailContentViewModel<M, D>
        where M : IMainDetailContentViewModel<M, D>
        where D : IMainDetailContentViewModel<M, D> {
        /// <summary>
        /// The <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
        /// </summary>
        MainDetailViewModel<M, D> ContentGroup { get; set; }
    }

    /// <summary>
    /// Interface for the <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
    /// </summary>
    /// <typeparam name="M">The main content.</typeparam>
    /// <typeparam name="D">The details of the main contents.</typeparam>
    public class MainDetailContentViewModel<M, D> : ViewModel, IMainDetailContentViewModel<M, D>
        where M : IMainDetailContentViewModel<M, D>
        where D : IMainDetailContentViewModel<M, D> {

        private MainDetailViewModel<M, D>? _contentGroup;
        /// <inheritdoc/>
        public MainDetailViewModel<M, D> ContentGroup {
            get {
                return _contentGroup ?? throw new System.NullReferenceException(nameof(ContentGroup));
            }
            set {
                _contentGroup = value;
            }
        }
    }
}
