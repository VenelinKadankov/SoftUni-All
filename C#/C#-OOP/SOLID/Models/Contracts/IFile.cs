namespace Logger.Models.Conflicts
{
    public interface IFile
    {
        //ILayout Layout { get; }
        string Path { get; }

        long Size { get; }

        string Write(ILayout layout, IError error);
    }
}
