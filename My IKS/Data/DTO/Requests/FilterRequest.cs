using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain.Enumerations;

namespace My_IKS.Data.DTO.Requests
{
    public class FilterRequest
    {
        public string SearchBy { get; set; }
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
