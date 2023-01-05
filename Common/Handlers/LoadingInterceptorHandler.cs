using Common.Services;

namespace Common.Handlers
{
    public class LoadingInterceptorHandler : DelegatingHandler
    {
        private readonly SpinnerService _spinnerService;

        public LoadingInterceptorHandler(SpinnerService spinnerService)
        {
            _spinnerService = spinnerService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerService.Show();

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            _spinnerService.Hide();

            return response;
        }
    }
}
