// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Authentication configuration.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record AuthenticationOptions
{
    /// <summary>
    /// Identity Provider. Default is StaticWebApps.
    /// With EasyAuth and Simulator, no Audience or Issuer are expected.
    /// </summary>
    public string Provider { get; set; } = nameof(EasyAuthType.StaticWebApps);

    /// <summary>
    /// Settings enabling validation of the received JWT token.
    /// Required only when Provider is other than EasyAuth.
    /// </summary>
    public JwtOptions? Jwt { get; set; }

    public const string SIMULATOR_AUTHENTICATION = "Simulator";
    public const string CLIENT_PRINCIPAL_HEADER = "X-MS-CLIENT-PRINCIPAL";
    public const string NAME_CLAIM_TYPE = "name";
    public const string ROLE_CLAIM_TYPE = "roles";

    /// <summary>
    /// Returns whether the configured Provider matches an
    /// EasyAuth authentication type.
    /// </summary>
    /// <returns>True if Provider is an EasyAuth type.</returns>
    public bool IsEasyAuthAuthenticationProvider() => Enum.GetNames(typeof(EasyAuthType)).Any(x => x.Equals(Provider, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns whether the configured Provider value matches the simulator authentication type.
    /// </summary>
    /// <returns>True when development mode should authenticate all requests.</returns>
    public bool IsAuthenticationSimulatorEnabled() => Provider.Equals(SIMULATOR_AUTHENTICATION, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// A shorthand method to determine whether JWT is configured for the current authentication provider.
    /// </summary>
    /// <returns>True if the provider is enabled for JWT, otherwise false.</returns>
    public bool IsJwtConfiguredIdentityProvider() => !IsEasyAuthAuthenticationProvider() && !IsAuthenticationSimulatorEnabled();

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationOptions"/> class.
    /// </summary>
    /// <param name="provider">Identity Provider. Default is StaticWebApps.
    /// With EasyAuth and Simulator, no Audience or Issuer are expected.</param>
    /// <param name="jwt">Settings enabling validation of the received JWT token.
    /// Required only when Provider is other than EasyAuth.</param>
    public AuthenticationOptions(string Provider = nameof(EasyAuthType.StaticWebApps), JwtOptions? Jwt = null)
    {
        this.Provider = Provider;
        this.Jwt = Jwt;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationOptions"/> class.
    /// </summary>
    public AuthenticationOptions()
    {
        Provider = default!;
        Jwt = null;
    }
}
