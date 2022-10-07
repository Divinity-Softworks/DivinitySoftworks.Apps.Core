namespace DivinitySoftworks.Apps.Core.Data {

    /// <summary>
    /// Interface for the <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
    /// </summary>
    /// <typeparam name="M">The master content.</typeparam>
    /// <typeparam name="D">The details of the main contents.</typeparam>
    public interface IMainDetailViewModel<M, D>
        where M : IMainDetailContentViewModel<M, D>
        where D : IMainDetailContentViewModel<M, D> {
        /// <summary>
        /// The main, or center, content.
        /// </summary>
        M? Main { get; set; }
        /// <summary>
        /// The details of the main contents.
        /// </summary>
        D? Details { get;set; }
    }

    /// <summary>
    /// Class for the <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
    /// </summary>
    /// <typeparam name="M">The master content.</typeparam>
    /// <typeparam name="D">The details of the main contents.</typeparam>
    public class MainDetailViewModel<M, D> : ViewModel
        where M : IMainDetailContentViewModel<M, D>
        where D : IMainDetailContentViewModel<M, D> {
        
        /// <summary>
        /// Class for the <seealso cref="MainDetailViewModel{M, D}"/> this content belongs to.
        /// </summary>
        public MainDetailViewModel(M main, D details) {
            Main = main;
            Details = details;
        }

        M? _main;
        /// <summary>
        /// The main, or center, content.
        /// </summary>
        public M? Main {
            get {
                return _main;
            }
            set {
                if (value is not null)
                    value.ContentGroup = this;
                _main = value;
            }
        }

        D? _details;
        /// <summary>
        /// The details of the main contents.
        /// </summary>
        public D? Details {
            get {
                return _details;
            }
            set {
                if (value is not null)
                    value.ContentGroup = this;
                _details = value;
            }
        }
    }
}
