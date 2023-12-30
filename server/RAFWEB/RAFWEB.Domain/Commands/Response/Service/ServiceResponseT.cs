namespace RAFWEB.Domain.Commands.Response.Service
{
    public class ServiceResponse<TModel>
    {
        public ServiceResponse()
        {
        }

        public ServiceResponse(string error)
        {
            Error = error;
            Success = false;
        }

        public ServiceResponse(TModel modelRequest)
        {
            ModelRequest = modelRequest;
            Success = true;
        }

        public ServiceResponse(ServiceResponse answerRequest)
        {
            Error = answerRequest.Error;
            Success = answerRequest.Success;
        }

        public ServiceResponse ConvertToServiceResponse()
        {
            ServiceResponse serviceResponse;
            if (Success)
            {
                serviceResponse = new ServiceResponse();
            }
            else
            {
                serviceResponse = new ServiceResponse(Error);
            }

            return serviceResponse;
        }

        public bool Success { get; private set; }

        public string Error { get; private set; }

        public TModel ModelRequest { get; private set; }
    }
}
