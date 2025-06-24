using System;
using System.Threading;
using System.Threading.Tasks;
using SignNow.Net.Interfaces;
using SignNow.Net.Internal.Extensions;
using SignNow.Net.Internal.Requests;
using SignNow.Net.Model;
using SignNow.Net.Model.Requests;
using SignNow.Net.Model.Responses;

namespace SignNow.Net.Service
{
    public class DocumentGroupTemplatesService : WebClientBase, IDocumentGroupTemplatesService
    {
        /// <summary>
        /// Creates new instance of <see cref="DocumentGroupTemplatesService"/>
        /// </summary>
        /// <param name="apiBaseUrl">Base signNow API URL</param>
        /// <param name="token">Access token</param>
        /// <param name="signNowClient">signNow Http client</param>
        public DocumentGroupTemplatesService(Uri apiBaseUrl, Token token, ISignNowClient signNowClient) : base(apiBaseUrl, token, signNowClient)
        {
        }

        /// <inheritdoc />
        public async Task<DocumentGroupInfoResponse> CreateDocumentGroupFromTemplateAsync(string documentGroupTemplateId, string documentGroupTemplateName,
            CancellationToken cancellationToken = default)
        {
            Token.TokenType = TokenType.Bearer;
            var requestOptions = new PostHttpRequestOptions
            {
                RequestUrl = new Uri(ApiBaseUrl, $"/v2/document-group-templates/{documentGroupTemplateId.ValidateId()}/document-group"),
                Content = new CreateDocumentGroupFromTemplateRequest(documentGroupTemplateName),
                Token = Token
            };

            return await SignNowClient
                .RequestAsync<DocumentGroupInfoResponse>(requestOptions, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        /// <exception cref="System.ArgumentException">If document group identity is not valid.</exception>
        public async Task<DocumentGroupTemplatesResponse> GetDocumentGroupTemplatesAsync(IQueryToString options, CancellationToken cancellationToken = default)
        {
            if (options.GetType() != typeof(LimitOffsetOptions))
            {
                throw new ArgumentException("Query params does not have 'limit' and 'offset' options. Use \"LimitOffsetOptions\" class.", nameof(options));
            }

            var opts = (LimitOffsetOptions)options;
            if (opts.Limit <= 0 || opts.Limit > 50)
            {
                throw new ArgumentException("Limit must be greater than 0 but less than or equal to 50.", nameof(options));
            }

            if (opts.Offset < 0)
            {
                throw new ArgumentException("Offset must be 0 or greater.", nameof(options));
            }

            var query = options?.ToQueryString();
            var filters = string.IsNullOrEmpty(query)
                ? string.Empty
                : $"?{query}";

            Token.TokenType = TokenType.Bearer;
            var requestOptions = new GetHttpRequestOptions
            {
                RequestUrl = new Uri(ApiBaseUrl, $"/user/documentgroup/templates{filters}"),
                Token = Token
            };

            return await SignNowClient
                .RequestAsync<DocumentGroupTemplatesResponse>(requestOptions, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentException">Limit must be greater than 0 but less than or equal to 50.</exception>
        /// <exception cref="ArgumentException">Offset must be 0 or greater.</exception>
        public async Task<DocumentGroupTemplatesResponse> GetDocumentGroupTemplatesAsync(string teamId, IQueryToString options, CancellationToken cancellationToken = default)
        {
            if (options.GetType() != typeof(LimitOffsetOptions))
            {
                throw new ArgumentException("Query params does not have 'limit' and 'offset' options. Use \"LimitOffsetOptions\" class.", nameof(options));
            }

            var opts = (LimitOffsetOptions)options;
            if (opts.Limit <= 0 || opts.Limit > 50)
            {
                throw new ArgumentException("Limit must be greater than 0 but less than or equal to 50.", nameof(options));
            }

            if (opts.Offset < 0)
            {
                throw new ArgumentException("Offset must be 0 or greater.", nameof(options));
            }

            var query = options?.ToQueryString();
            var filters = string.IsNullOrEmpty(query)
                ? string.Empty
                : $"?{query}";

            Token.TokenType = TokenType.Bearer;
            var requestOptions = new GetHttpRequestOptions
            {
                RequestUrl = new Uri(ApiBaseUrl, $"/team/{teamId}/documentgroup/templates{filters}"),
                Token = Token
            };

            return await SignNowClient
                .RequestAsync<DocumentGroupTemplatesResponse>(requestOptions, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
