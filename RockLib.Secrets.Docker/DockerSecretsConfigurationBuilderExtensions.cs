using System;

namespace RockLib.Secrets.Docker
{
    /// <summary>
    /// Extension methods for secrets configuration builders related to Docker.
    /// </summary>
    public static class DockerSecretsConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an <see cref="DockerSecret"/> to the <see cref="ISecretsConfigurationBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder the secret is beind added to.</param>
        /// <param name="configurationKey">The configuration key for the secret to be leverage</param>
        /// <param name="secretId">The Docker File Name that 'stores' the Docker Secret</param>
        /// <returns>The same <see cref="ISecretsConfigurationBuilder"/>.</returns>
        public static ISecretsConfigurationBuilder AddDockerSecret(this ISecretsConfigurationBuilder builder,
            string configurationKey, string secretId)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return builder.AddSecret(new DockerSecret(configurationKey, secretId));
        }
    }
}
