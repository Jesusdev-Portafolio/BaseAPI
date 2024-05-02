using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
        [Serializable]
        public class NotFoundException : Exception, IServiceException
        {
            private string _errorMessage;
            public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
            public string ErrorMessage => _errorMessage;
      
            public NotFoundException(string name, object key) 
            {
               _errorMessage = $"Entity {name} ({key}) was not found.";
            }
            public NotFoundException(string name, object key, object? data) 
            {
                _errorMessage = $"Entity {name} ({key}) was not found.";
                this.Values = data;
            }
            public object? Values
            {
                get; set;
            }

          
        }
}

