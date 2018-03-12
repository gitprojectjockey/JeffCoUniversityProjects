using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace JeffCoUniversity.API.Helpers
{
    public class ActionResultBuilder
    {
        public class CreateActionResult<T> : IHttpActionResult
        {
            private readonly HttpRequestMessage _request;
            private readonly T _value;
            private readonly HttpStatusCode _statusCode;
            private HttpResponseMessage _response;

            public CreateActionResult(HttpRequestMessage request, T value, HttpStatusCode statusCode)
            {
                _request = request;
                _value = value;
                _statusCode = statusCode;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var formatter = new JsonMediaTypeFormatter();
                formatter.Indent = true;

                if (_value != null)
                {
                    _response = new HttpResponseMessage(_statusCode)
                    {
                        Content = new ObjectContent(_value.GetType(), _value, formatter),
                        RequestMessage = _request,
                    };
                }
                else
                {
                    _response = new HttpResponseMessage(_statusCode)
                    {
                        RequestMessage = _request,
                    };
                }

                _response.Headers.Date = DateTime.UtcNow;
                _response.Headers.Location = new Uri(_request.RequestUri.AbsoluteUri);

                return Task.FromResult(_response);
            }
        }
    }
}
