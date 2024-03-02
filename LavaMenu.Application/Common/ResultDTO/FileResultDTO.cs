using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.ResultDTO
{
    public record FileResultDTO
    {
        public string? FileAddress { get; set; } = null;

        public bool IsSuccess { get; set; } = false;
    }
}
