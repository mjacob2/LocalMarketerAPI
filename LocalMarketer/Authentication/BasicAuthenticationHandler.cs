using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using LocalMarketer.ApplicationServices;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.CQRS.Queries.UserQueries;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.Authentication
{
        /// <summary>
        /// The basic authentication handler.
        /// </summary>
        public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
        {
                private readonly IQueryExecutor queryExecutor;

                /// <summary>
                /// Initializes a new instance of the <see cref="BasicAuthenticationHandler"/> class.
                /// </summary>
                /// <param name="options">The options.</param>
                /// <param name="logger">The logger.</param>
                /// <param name="encoder">The encoder.</param>
                /// <param name="clock">The clock.</param>
                /// <param name="queryExecutor">The query executor.</param>
                public BasicAuthenticationHandler(
                    IOptionsMonitor<AuthenticationSchemeOptions> options,
                    ILoggerFactory logger,
                    UrlEncoder encoder,
                    ISystemClock clock,
                    IQueryExecutor queryExecutor)
                    : base(options, logger, encoder, clock)
                {
                        this.queryExecutor = queryExecutor;
                }

                /// <inheritdoc/>
                protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
                {
                        var endpoint = this.Context.GetEndpoint();
                        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                        {
                                return AuthenticateResult.NoResult();
                        }

                        if (!this.Request.Headers.ContainsKey("Authorization"))
                        {
                                return AuthenticateResult.Fail("Missing Authorization Header");
                        }

                        User user = null;
                        try
                        {
                                var authHeader = AuthenticationHeaderValue.Parse(this.Request.Headers["Authorization"]);
                                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                                var emailentered = credentials[0];
                                var passwordEntered = credentials[1];
                                var query = new GetUserByEmailQuery()
                                {
                                        Email = emailentered,
                                };
                                user = await this.queryExecutor.Execute(query);
                                var passwordHashed = Hasher.HashPassword(passwordEntered, user.Salt);
                                passwordEntered = passwordHashed;

                                if (user == null || user.Password != passwordEntered)
                                {
                                        return AuthenticateResult.Fail("Invalid Authorization Header");
                                }
                        }
                        catch
                        {
                                return AuthenticateResult.Fail("Invalid Authorization Header");
                        }

                        var claims = new[]
                        {
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(CultureInfo.InvariantCulture)),
                                new Claim(ClaimTypes.Role, user.Role.ToString()),
                                new Claim(ClaimTypes.AuthorizationDecision, user.AccesDenied.ToString(CultureInfo.InvariantCulture)),
                        };

                        var identity = new ClaimsIdentity(claims, this.Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
                        return AuthenticateResult.Success(ticket);
                }
        }
}
