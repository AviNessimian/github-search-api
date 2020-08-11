namespace GithubSearch.Core.Common
{
    public abstract class ResultBase
    {
        internal ResultBase(bool succeeded) { Succeeded = succeeded; }
        public bool Succeeded { get; set; }
    }

    public class Result : ResultBase
    {
        internal Result(bool succeeded) : base(succeeded) { }
        public static Result Success() => new Result(true);
        public static Result Failure() => new Result(false);
    }

    public class Result<T> : ResultBase where T : class
    {
        internal Result(bool succeeded, T model) : base(succeeded) { Model = model; }
        public T Model { get; set; }
        public static Result<T> Success(T model) => new Result<T>(true, model);
        public static Result<T> Failure() => new Result<T>(false, null);
    }
}
