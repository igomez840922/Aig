using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Domain.Common
{
    public class Result : IResult
    {
        public Result() { }
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }
        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }
        public static IResult Fail(List<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }
        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }
        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }
        public static Task<IResult> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }
        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }
        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }
        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }
        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
    }
    public class Result<T> : Result, IResult<T>
    {

        public Result() { }

        public T Data { get; set; }
        public new static Result<T> Fail()
        {
            return new Result<T> { Succeeded = false };
        }
        public new static Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
        }
        public new static Result<T> Fail(List<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }
        public new static Task<Result<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }
        public new static Task<Result<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }
        public new static Task<Result<T>> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }
        public new static Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }
        public new static Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }
        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }
        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }
        public static Result<T> Success(T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = messages };
        }
        public new static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }
        public new static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }
        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }
    }
    public class PaginatedResult<T> : Result
    {
        public PaginatedResult()
        {
            Data = new List<T>();
            CurrentPage = 1;
            PageSize = 10;
        }
        public PaginatedResult(List<T> data)
        {
            Data = data;
            CurrentPage = 1;
            PageSize = 10;
        }

        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public int StartIndex => (CurrentPage - 1) * PageSize;
        public int EndIndex => Math.Min(StartIndex + PageSize - 1, TotalCount - 1);

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
      

    }
}
