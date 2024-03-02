using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.ResultDTO
{
    public record GlobalResultDTO<T>
    {
        public T Value { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
    public record GlobalResultDTO
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
