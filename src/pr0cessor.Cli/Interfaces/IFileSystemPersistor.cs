using CSharpFunctionalExtensions;

namespace pr0cessor.Interfaces {
  public interface IFileSystemPersistor<T> {
    string FileName { get; }

    Result Store(T dataToPersist);
    Result<Maybe<T>> Read();
  }
}
